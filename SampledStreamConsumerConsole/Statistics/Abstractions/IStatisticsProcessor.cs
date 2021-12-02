using System.Threading.Tasks;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;

namespace SampledStreamConsumerConsole.Statistics.Abstractions
{
    public interface IStatisticsProcessor
    {
        Task GenerateAndDisplayStatistics(IAppSettings appSettings, ITweetResponseQueue tweetResponseQueue, 
            IStatisticsCalculator statisticsCalculator, IStatisticsReporter statisticsReporter, IMessageWriter messageWriter);
    }
}