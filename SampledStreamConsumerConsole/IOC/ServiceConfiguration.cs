using Microsoft.Extensions.DependencyInjection;
using SampledStreamConsumerConsole.AppControls;
using SampledStreamConsumerConsole.AppControls.Abstractions;
using SampledStreamConsumerConsole.Clients;
using SampledStreamConsumerConsole.Clients.Abstractions;
using SampledStreamConsumerConsole.ConsoleMessaging;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;
using SampledStreamConsumerConsole.ConstantsConfigsSettings;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.IOC.Abstractions;
using SampledStreamConsumerConsole.ProgramExecution;
using SampledStreamConsumerConsole.ProgramExecution.Abstractions;
using SampledStreamConsumerConsole.Queueing;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using SampledStreamConsumerConsole.Statistics;
using SampledStreamConsumerConsole.Statistics.Abstractions;
using SampledStreamConsumerConsole.StreamProcessors;
using SampledStreamConsumerConsole.StreamProcessors.Abstractions;

namespace SampledStreamConsumerConsole.IOC
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public IServiceCollection ConfigureServices(string configFileName, string bearerToken)
        {
            IServiceCollection servicesCollection = new ServiceCollection();

            servicesCollection.AddSingleton<IControlInputs, ControlInputs>();
            servicesCollection.AddSingleton<IAppSettings>(new AppSettings(configFileName, bearerToken));
            servicesCollection.AddSingleton<ITweetResponseQueue, TweetResponseQueue>();
            servicesCollection.AddSingleton<ISampledTweetStreamProcessor, SampledTweetStreamProcessor>();
            servicesCollection.AddSingleton<IStatisticsCalculator, StatisticsCalculator>();
            servicesCollection.AddSingleton<IStatisticsReporter, StatisticsReporter>();
            servicesCollection.AddSingleton<IStatisticsProcessor, StatisticsProcessor>();
            servicesCollection.AddSingleton<ITweetInfoWriter, TweetInfoWriter>();
            servicesCollection.AddSingleton<IMessageWriter, MessageWriter>();
            servicesCollection.AddSingleton<ICustomHttpClient, CustomHttpClient>();

            servicesCollection.AddTransient<IConsoleApplicationRunner, ConsoleApplicationRunner>();

            return servicesCollection;
        }
    }
}
