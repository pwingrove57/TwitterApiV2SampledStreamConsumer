using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampledStreamConsumerConsole.Queueing;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using SampledStreamConsumerConsole.Statistics;
using SampledStreamConsumerConsole.Statistics.Abstractions;
using UnitTestsSampledStreamConsumerConsole.UnitTestUtilities;

namespace UnitTestsSampledStreamConsumerConsole.StatisticsUnitTests
{
    [TestClass]
    public class StatisticsCalculatorUnitTests
    {
        private readonly UtilityMethods _utilityMethods = new UtilityMethods();

        [TestMethod]
        public void VerifyThatCalculateStatsAccuratelyCalculatesAverageTweetsPerMinuteFor100Tweets()
        {
            ITweetResponseQueue tweetResponseQueue = new TweetResponseQueue();
            IStatisticsCalculator statisticsCalculator = new StatisticsCalculator();

            _utilityMethods.PopulateTweetResponseQueueWithSetTimes(tweetResponseQueue, 100, 
                                                                   DateTime.Now, (long)20,
                                                                   (long)2021);

            statisticsCalculator.CalculateStats(tweetResponseQueue);

            Assert.AreEqual(Math.Round(2.00, 2), Math.Round(statisticsCalculator.TimeSpanTotalSeconds, 2));
            Assert.AreEqual(Math.Round(50.00, 2), Math.Round(statisticsCalculator.AverageTweetsPerSecond, 2));
            Assert.AreEqual(Math.Round(2999.99, 2), Math.Round(statisticsCalculator.AverageTweetsPerMinute, 2));
        }

        [TestMethod]
        public void VerifyThatCalculateStatsAccuratelyCalculatesAverageTweetsPerMinuteFor10000Tweets()
        {
            ITweetResponseQueue tweetResponseQueue = new TweetResponseQueue();
            IStatisticsCalculator statisticsCalculator = new StatisticsCalculator();

            _utilityMethods.PopulateTweetResponseQueueWithSetTimes(tweetResponseQueue, 10000,
                DateTime.Now, (long)20,
                (long)20);

            statisticsCalculator.CalculateStats(tweetResponseQueue);

            Assert.AreEqual(Math.Round(200.00, 2), Math.Round(statisticsCalculator.TimeSpanTotalSeconds, 2));
            Assert.AreEqual(Math.Round(50.00, 2), Math.Round(statisticsCalculator.AverageTweetsPerSecond, 2));
            Assert.AreEqual(Math.Round(3000.00, 2), Math.Round(statisticsCalculator.AverageTweetsPerMinute, 2));
        }

        [TestMethod]
        public void VerifyThatCalculateStatsAccuratelyCalculatesAverageTweetsPerMinuteFor100000Tweets()
        {
            ITweetResponseQueue tweetResponseQueue = new TweetResponseQueue();
            IStatisticsCalculator statisticsCalculator = new StatisticsCalculator();

            _utilityMethods.PopulateTweetResponseQueueWithSetTimes(tweetResponseQueue, 100000,
                DateTime.Now, (long)20,
                (long)2);

            statisticsCalculator.CalculateStats(tweetResponseQueue);

            Assert.AreEqual(Math.Round(2000.00, 2), Math.Round(statisticsCalculator.TimeSpanTotalSeconds, 2));
            Assert.AreEqual(Math.Round(50.00, 2), Math.Round(statisticsCalculator.AverageTweetsPerSecond, 2));
            Assert.AreEqual(Math.Round(3000.00, 2), Math.Round(statisticsCalculator.AverageTweetsPerMinute, 2));
        }

        [TestMethod]
        public void VerifyThatCalculateStatsAccuratelyCalculatesAverageTweetsPerMinuteFor1000000Tweets()
        {
            ITweetResponseQueue tweetResponseQueue = new TweetResponseQueue();
            IStatisticsCalculator statisticsCalculator = new StatisticsCalculator();

            _utilityMethods.PopulateTweetResponseQueueWithSetTimes(tweetResponseQueue, 1000000,
                DateTime.Now, (long)20,
                (long)1);

            statisticsCalculator.CalculateStats(tweetResponseQueue);

            Assert.AreEqual(Math.Round(20000.08, 2), Math.Round(statisticsCalculator.TimeSpanTotalSeconds, 2));
            Assert.AreEqual(Math.Round(50.00, 2), Math.Round(statisticsCalculator.AverageTweetsPerSecond, 2));
            Assert.AreEqual(Math.Round(2999.99, 2), Math.Round(statisticsCalculator.AverageTweetsPerMinute, 2));
        }
    }
}
