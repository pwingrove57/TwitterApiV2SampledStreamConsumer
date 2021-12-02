using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using SampledStreamConsumerConsole.Statistics.Abstractions;
using System;
using System.Threading.Tasks;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;

namespace SampledStreamConsumerConsole.Statistics
{
    /// <summary>
    /// StatisticsProcessor - Executes methods that generate and display statistics on the console
    /// </summary>
    public class StatisticsProcessor : IStatisticsProcessor
    {
        public async Task GenerateAndDisplayStatistics(IAppSettings appSettings, ITweetResponseQueue tweetResponseQueue, 
            IStatisticsCalculator statisticsCalculator, IStatisticsReporter statisticsReporter, IMessageWriter messageWriter)
        {
            while (true)
            {
                await Task.Run(async delegate
                {
                    await Task.Delay(TimeSpan.FromSeconds(appSettings.SecondsBeforeStatisticsReports));
                    return 0;
                });
                statisticsCalculator.CalculateStats(tweetResponseQueue);
                statisticsReporter.ReportStats(statisticsCalculator, messageWriter);
            }

            // ReSharper disable once FunctionNeverReturns
            // This method should run as long as the application is running as expected
        }
    }
}
