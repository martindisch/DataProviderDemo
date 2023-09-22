using DataProviderDemo;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .ModifyRequestOptions(o => o.IncludeExceptionDetails = true)
    .AddGlobalObjectIdentification()
    .AddQueryType<Query>();

var app = builder.Build();
app.MapGraphQL();

app.Run();
