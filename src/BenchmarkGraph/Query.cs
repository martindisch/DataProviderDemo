namespace BenchmarkGraph;

public class Query
{
    [NodeResolver]
    public async Task<DataProduct> GetDataProductById(int id, DataProductDataLoader dataLoader) => await dataLoader.LoadAsync(id);

    [NodeResolver]
    public LazyProduct GetLazyProductById(int id) => new(id);
}