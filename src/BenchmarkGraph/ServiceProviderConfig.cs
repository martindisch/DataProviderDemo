using HotChocolate.Execution.Configuration;

namespace BenchmarkGraph;

public static class ServiceProviderConfig
{
    public static IRequestExecutorBuilder AddBenchmarkGraph(this IRequestExecutorBuilder requestExecutorBuilder)
    {
        return requestExecutorBuilder
            .ModifyRequestOptions(o => o.IncludeExceptionDetails = true)
            .AddGlobalObjectIdentification()
            .AddQueryType<Query>();
    }
}