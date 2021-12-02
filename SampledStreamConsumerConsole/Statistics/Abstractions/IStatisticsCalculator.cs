using SampledStreamConsumerConsole.Queueing.Abstractions;

namespace SampledStreamConsumerConsole.Statistics.Abstractions
{
    public interface IStatisticsCalculator
    {
        int TotalTweetCount { get; }
        long FifoItemReceiptTicks { get; }
        long NewestItemReceiptTicks { get; }
        double AverageTweetsPerMinute { get; }
        double AverageTweetsPerSecond { get; }
        double TimeSpanTotalHours { get; }
        double TimeSpanTotalMinutes { get; }
        double TimeSpanTotalSeconds { get; }
        void CalculateStats(ITweetResponseQueue tweetResponseQueue);
    }
}