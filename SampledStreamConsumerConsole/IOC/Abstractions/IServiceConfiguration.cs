using Microsoft.Extensions.DependencyInjection;

namespace SampledStreamConsumerConsole.IOC.Abstractions
{
    public interface IServiceConfiguration
    {
        IServiceCollection ConfigureServices(string configFileName, string bearerToken);
    }
}