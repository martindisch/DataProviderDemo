namespace DataProviderDemo;

public class AuthorDataLoader : BatchDataLoader<int, AuthorModel>
{
    public AuthorDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    { }

    protected override async Task<IReadOnlyDictionary<int, AuthorModel>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

        var authorsById = keys
            .Select(id => new AuthorModel(id, $"Author {id}", $"Author {id} lived a long and happy life."))
            .ToDictionary(authorModel => authorModel.Id);

        return authorsById;
    }
}

public record AuthorModel(int Id, string Name, string Bio)
{
    public Author ToAuthor() => new(Id, Name, Bio);
}