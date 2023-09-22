namespace DataProviderDemo;

public class Query
{
    [NodeResolver]
    public async Task<Author> GetAuthorByIdAsync(int id, AuthorDataLoader authorDataLoader)
    {
        var authorModel = await authorDataLoader.LoadAsync(id);
        return authorModel.ToAuthor();
    }
}