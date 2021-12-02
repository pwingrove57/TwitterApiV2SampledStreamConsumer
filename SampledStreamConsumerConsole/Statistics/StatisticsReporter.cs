using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;
using SampledStreamConsumerConsole.Statistics.Abstractions;
using System;

namespace SampledStreamConsumerConsole.Statistics
{
    public class StatisticsReporter : IStatisticsReporter
    {
        public void ReportStats(IStatisticsCalculator statisticsCalculator, IMessageWriter messageWriter)

        {
            DisplayStatsOnConsole(statisticsCalculator, messageWriter);
        }

        private void DisplayStatsOnConsole(IStatisticsCalculator statisticsCalculator, IMessageWriter messageWriter)
        {
            if (statisticsCalculator.TotalTweetCount > 0)
            {
                messageWriter.WriteMessageLine($@"{Environment.NewLine}Statistics Tweet Count: {statisticsCalculator.TotalTweetCount}");
                messageWriter.WriteMessageLine($@"FIFO Item Ticks on Receipt: {statisticsCalculator.FifoItemReceiptTicks}");
                messageWriter.WriteMessageLine($@"Newest Item Ticks on Receipt: {statisticsCalculator.NewestItemReceiptTicks}");
                messageWriter.WriteMessageLine($@"Time Span Total Hours: {statisticsCalculator.TimeSpanTotalHours}");
                messageWriter.WriteMessageLine($@"Time Span Total Minutes: {statisticsCalculator.TimeSpanTotalMinutes}");
                messageWriter.WriteMessageLine($@"Time Span Total Seconds: {statisticsCalculator.TimeSpanTotalSeconds}");
                messageWriter.WriteMessageLine($@"Average Tweets Per Minute: {statisticsCalculator.AverageTweetsPerMinute}");
                messageWriter.WriteMessageLine($@"Average Tweets per Second: {statisticsCalculator.AverageTweetsPerSecond}{Environment.NewLine}");
            }
            else
            {
                messageWriter.WriteMessageLine($@"{Environment.NewLine}Current Tweet Count: {statisticsCalculator.TotalTweetCount}, No Stats Currently Available{Environment.NewLine}");
            }
        }
    }
}
