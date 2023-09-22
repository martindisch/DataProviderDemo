namespace DataProviderDemo;

public class Query
{
    [NodeResolver]
    public Author GetAuthorById(int id) => new(id);
}