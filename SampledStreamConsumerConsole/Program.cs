using Microsoft.Extensions.DependencyInjection;
using SampledStreamConsumerConsole.Authentication;
using SampledStreamConsumerConsole.ConstantsConfigsSettings;
using SampledStreamConsumerConsole.IOC;
using SampledStreamConsumerConsole.ProgramExecution.Abstractions;
using System.Threading.Tasks;

namespace SampledStreamConsumerConsole
{
    internal class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static async Task Main(string[] args)
        {
            var servicesCollection = new ServiceConfiguration().ConfigureServices(ApplicationConstants.AppSettingsConfigFileName,
                                                                                  GetBearerTokenFromTokenFile());

            var servicesProvider = servicesCollection.BuildServiceProvider();

            // ReSharper disable once PossibleNullReferenceException
            await servicesProvider.GetService<IConsoleApplicationRunner>().RunTheApplication();
        }

        private static string GetBearerTokenFromTokenFile()
        {
            BearerTokenRetriever tokenRetriever = new BearerTokenRetriever($@"C:\GitHub\SecretsAndStuff\Authentication.json");

            return tokenRetriever.BearerToken;
        }
    }
}
