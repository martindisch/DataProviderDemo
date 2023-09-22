namespace DataProviderDemo;

public class BooksByAuthorDataLoader : GroupedDataLoader<int, BookModel> {
    public BooksByAuthorDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
    { }

    protected override Task<ILookup<int, BookModel>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        var booksByAuthorId = keys
            .SelectMany(authorId => Enumerable.Range(1, 10).Select(bookId => new BookModel(bookId, $"Author{authorId}Book{bookId}", authorId)))
            .ToLookup(book => book.AuthorId);

        return Task.FromResult(booksByAuthorId);
    }
}

public class BookModel
{
    public BookModel(int id, string title, int authorId)
    {
        Id = id;
        Title = title;
        AuthorId = authorId;
    }

    public int Id { get; }

    public string Title { get; }

    public int AuthorId { get; }

    public Book ToBook() => new(Id, Title, AuthorId);
}