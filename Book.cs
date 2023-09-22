namespace DataProviderDemo;

public class Book
{
    public Book(int id, string title, int authorId)
    {
        Id = id;
        Title = title;
        AuthorId = authorId;
    }

    public int Id { get; }

    public string Title { get; }

    public async Task<Author> GetAuthorAsync(AuthorDataLoader authorDataLoader)
    {
        var authorModel = await authorDataLoader.LoadAsync(AuthorId);
        return authorModel.ToAuthor();
    }

    internal int AuthorId { get; }
}