namespace BenchmarkGraph;

public class DataProductDataLoader : BatchDataLoader<int, DataProduct>
{
    public DataProductDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(
        batchScheduler, options)
    {
    }

    protected override async Task<IReadOnlyDictionary<int, DataProduct>> LoadBatchAsync(IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        var dataProductsById = keys.Select(id => new DataProduct(id,
                "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42,
                true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!",
                42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true,
                "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42,
                true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!",
                42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true,
                "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42,
                true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!",
                42, true, "Hello, world!", 42, true, "Hello, world!", 42, true, "Hello, world!", 42, true))
            .ToDictionary(dataProduct => dataProduct.Id);

        return await Task.FromResult(dataProductsById);
    }
}