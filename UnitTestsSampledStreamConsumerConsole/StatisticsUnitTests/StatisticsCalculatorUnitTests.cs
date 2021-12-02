using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampledStreamConsumerConsole.Queueing;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using SampledStreamConsumerConsole.Statistics;
using UnitTestsSampledStreamConsumerConsole.UnitTestUtilities;

namespace UnitTestsSampledStreamConsumerConsole.StatisticsUnitTests
{
    [TestClass]
    public class StatisticsCalculatorUnitTests
    {
        private readonly UtilityMethods _utilityMethods = new UtilityMethods();

        [TestMethod]
        public void VerifyThatCalculateStatsAccuratelyCalculatesAverageTweetsPerMinute()
        {
            ITweetResponseQueue tweetResponseQueue = new TweetResponseQueue();
            StatisticsCalculator statisticsCalculator = new StatisticsCalculator();

            _utilityMethods.PopulateTweetResponseQueue(tweetResponseQueue, 5700);

            statisticsCalculator.CalculateStats(tweetResponseQueue);

            Assert.Fail();
        }
    }
}
