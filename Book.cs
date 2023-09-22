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

    public Author GetAuthor() => new(AuthorId);

    internal int AuthorId { get; }
}