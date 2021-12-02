using SampledStreamConsumerConsole.Models.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using SampledStreamConsumerConsole.Statistics.Abstractions;
using System;

namespace SampledStreamConsumerConsole.Statistics
{
    public class StatisticsCalculator : IStatisticsCalculator
    {
        private int _totalTweetCount;
        private double _averageTweetsPerMinute;
        private double _averageTweetsPerSecond;
        private long _fifoItemTicksOnReceipt;
        private long _newestItemTicksOnReceipt;
        private TimeSpan _timeSpan;

        public int TotalTweetCount => _totalTweetCount;
        public long FifoItemReceiptTicks => _fifoItemTicksOnReceipt;
        public long NewestItemReceiptTicks => _newestItemTicksOnReceipt;

        public double AverageTweetsPerMinute => _averageTweetsPerMinute;
        public double AverageTweetsPerSecond => _averageTweetsPerSecond;
        public double TimeSpanTotalHours => _timeSpan.TotalHours;
        public double TimeSpanTotalMinutes => _timeSpan.TotalMinutes;
        public double TimeSpanTotalSeconds => _timeSpan.TotalSeconds;

        public void CalculateStats(ITweetResponseQueue tweetResponseQueue)
        {
            _totalTweetCount = tweetResponseQueue.Count;
            if (_totalTweetCount > 0)
            {
                // Get key items (first item queued, newest item queued as of this method call) to report on
                tweetResponseQueue.TryPeek(out IRawTweetResponse fifoItem);
                _fifoItemTicksOnReceipt = fifoItem.TicksOnReceipt;

                var newestItem = tweetResponseQueue.GetRawTweetResponseByIndex(_totalTweetCount - 1);
                _newestItemTicksOnReceipt = newestItem.TicksOnReceipt;

                _timeSpan = TimeSpan.FromTicks(newestItem.TicksOnReceipt - fifoItem.TicksOnReceipt);

                _averageTweetsPerMinute = _totalTweetCount / _timeSpan.TotalMinutes;
                _averageTweetsPerSecond = _totalTweetCount / _timeSpan.TotalSeconds;
            }
        }
    }
}
