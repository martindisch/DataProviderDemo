namespace DataProviderDemo;

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