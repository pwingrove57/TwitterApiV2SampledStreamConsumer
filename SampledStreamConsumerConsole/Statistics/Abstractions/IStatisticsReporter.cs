using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;

namespace SampledStreamConsumerConsole.Statistics.Abstractions
{
    public interface IStatisticsReporter
    {
        void ReportStats(IStatisticsCalculator statisticsCalculator, IMessageWriter messageWriter);
    }
}