# DataProviderDemo

Let's imagine a simple authors + books example, as prepared in commit
[600380b](https://github.com/martindisch/DataProviderDemo/commit/600380bec7209e514ce1c7032691443ab0958df2).

We have a basic author in our schema.

```csharp
public class Author
{
    public Author(int id, string name, string bio)
    {
        Id = id;
        Name = name;
        Bio = bio;
    }

    public int Id { get; }

    public string Name { get; }

    public string Bio { get; }

    [UsePaging]
    public async Task<IEnumerable<Book>> GetBooksAsync(BooksByAuthorDataLoader booksByAuthorDataLoader)
    {
        var bookModels = await booksByAuthorDataLoader.LoadAsync(Id);
        return bookModels.Select(bookModel => bookModel.ToBook());
    }
}
```

This author can be queried

```csharp
public class Query
{
    [NodeResolver]
    public async Task<Author> GetAuthorByIdAsync(int id, AuthorDataLoader authorDataLoader)
    {
        var authorModel = await authorDataLoader.LoadAsync(id);
        return authorModel.ToAuthor();
    }
}
```

where the database model is loaded with a DataLoader.

Everything works fine, we can fetch some data with

```graphql
query everything {
  authorById(id: "QXV0aG9yCmkx") {
    name
    bio
    books(first: 3) {
      nodes {
        title
      }
    }
  }
}
```

and immediately get the response

```json
{
  "data": {
    "authorById": {
      "name": "Author 1",
      "bio": "Author 1 lived a long and happy life.",
      "books": {
        "nodes": [
          {
            "title": "Author1Book1"
          },
          {
            "title": "Author1Book2"
          },
          {
            "title": "Author1Book3"
          }
        ]
      }
    }
  }
}
```

Now let's imagine that for some reason, loading personal information such as
the name and bio is expensive. Since we don't have a database in our example
and the DataLoaders simulate the DB, we'll just introduce a delay in
`AuthorDataLoader` with commit
[b404c6b](https://github.com/martindisch/DataProviderDemo/commit/b404c6be1e78e25f03b7ed3efc0db569a1d965f8).

The query from above now takes one second, no surprises there. But what if for
our use case, we weren't even interested in personal information, but would
only want to load the titles of the author's books.

```graphql
query booksOnly {
  authorById(id: "QXV0aG9yCmkx") {
    books(first: 3) {
      nodes {
        title
      }
    }
  }
}
```

Theoretically this query could be unaffected by the slow authors database. In
practice it still is, because before we can access the (fast) `Author.books`
resolver we have to pass through the delayed `Query.authorById` resolver which
loads the full author.

```csharp
public class Query
{
    [NodeResolver]
    public async Task<Author> GetAuthorByIdAsync(int id, AuthorDataLoader authorDataLoader)
    {
        var authorModel = await authorDataLoader.LoadAsync(id);
        return authorModel.ToAuthor();
    }
}
```

With this setup we have to load the author first before we can access any of
its fields, even if that field has no data dependency on this preloaded
information. This also means we can't load the author's books in parallel with
their personal information if we wanted to fetch everything, instead it's done
sequentially.

To remedy this, we could remodel our author to load its fields on-demand, as
demonstrated in commit
[f09ad62](https://github.com/martindisch/DataProviderDemo/commit/f09ad62bf0d770f670260f470a996103d59a4cf0).
The only required field on the author is its ID, all others have been turned
into resolvers that use the DataLoader to obtain the DB model and return the
respective property they represent.

```csharp
public class Author
{
    public Author(int id)
    {
        Id = id;
    }

    public int Id { get; }

    public async Task<string> GetNameAsync(AuthorDataLoader authorDataLoader) => (await authorDataLoader.LoadAsync(Id)).Name;

    public async Task<string> GetBioAsync(AuthorDataLoader authorDataLoader) => (await authorDataLoader.LoadAsync(Id)).Bio;

    [UsePaging]
    public async Task<IEnumerable<Book>> GetBooksAsync(BooksByAuthorDataLoader booksByAuthorDataLoader)
    {
        var bookModels = await booksByAuthorDataLoader.LoadAsync(Id);
        return bookModels.Select(bookModel => bookModel.ToBook());
    }
}
```

Now the `Query.authorById` resolver has become trivial and is able to complete
instantly, meaning if we don't want to load personal information, we don't have
to. And if we would, the books could be loaded in parallel with the other
fields.

```csharp
public class Query
{
    [NodeResolver]
    public Author GetAuthorById(int id) => new(id);
}
```

As an added benefit, it has become exceedingly easy to return an author
wherever we want to in the schema (for example on `Book.author` to link back),
since we no longer have to load anything and can simply instantiate the object
with its ID.

While there are some nice advantages to the pattern, we're wondering about the
downsides. Is it ergonomic to have lots of resolvers like `(await
authorDataLoader.LoadAsync(Id)).Name` instead of simple instance properties?
Does this scale performance-wise when we have hundreds of such fields returned
in a single response or does it lead to massive instruction bloat due to the
number of async state machines generated?

We'll do a benchmark to determine that last point, but are interested in
general perspectives and advice on how to deal with such a situation.

## License

[MIT License](LICENSE)
