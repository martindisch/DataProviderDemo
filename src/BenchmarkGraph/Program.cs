using BenchmarkGraph;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddGraphQLServer()
    .AddBenchmarkGraph();

var app = builder.Build();
app.MapGraphQL();

app.Run();