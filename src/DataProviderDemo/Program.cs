using DataProviderDemo;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .AddDemo();

var app = builder.Build();
app.MapGraphQL();

app.Run();
