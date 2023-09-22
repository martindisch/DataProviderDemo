namespace DataProviderDemo;

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