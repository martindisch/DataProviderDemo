using HotChocolate.Execution.Configuration;

namespace DataProviderDemo;

public static class ServiceProviderConfig
{
    public static IRequestExecutorBuilder AddDemo(this IRequestExecutorBuilder requestExecutorBuilder)
    {
        return requestExecutorBuilder
            .ModifyRequestOptions(o => o.IncludeExceptionDetails = true)
            .AddGlobalObjectIdentification()
            .AddQueryType<Query>();
    }
}