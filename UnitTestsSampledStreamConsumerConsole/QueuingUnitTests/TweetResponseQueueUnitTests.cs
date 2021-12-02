using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampledStreamConsumerConsole.Queueing;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using System;
using UnitTestsSampledStreamConsumerConsole.UnitTestUtilities;

namespace UnitTestsSampledStreamConsumerConsole.QueuingUnitTests
{
    [TestClass]
    public class TweetResponseQueueUnitTests
    {
        private readonly UtilityMethods _utilityMethods = new UtilityMethods();

        [TestMethod]
        public void VerifyThatGetRawTweetResponseByIndexMethodReturnsTheCorrectTweet()
        {
            ITweetResponseQueue tweetResponseQueue = new TweetResponseQueue();

            _utilityMethods.PopulateTweetResponseQueue(tweetResponseQueue, 300);

            Assert.AreEqual("This is tweet # 1, having queue index # 0",
                tweetResponseQueue.GetRawTweetResponseByIndex(0).RawMessage);

            Assert.AreEqual("This is tweet # 178, having queue index # 177",
                tweetResponseQueue.GetRawTweetResponseByIndex(177).RawMessage);

            Assert.AreEqual("This is tweet # 300, having queue index # 299", 
                tweetResponseQueue.GetRawTweetResponseByIndex(299).RawMessage);
        }

        [TestMethod]
        public void VerifyThatGetRawTweetResponseByIndexMethodReturnsIndexOutOfBoundsTweetWhenIndexOutOfBounds()
        {
            ITweetResponseQueue tweetResponseQueue = new TweetResponseQueue();

            _utilityMethods.PopulateTweetResponseQueue(tweetResponseQueue, 300);

            Assert.AreEqual("Index out of bounds: -1", 
                tweetResponseQueue.GetRawTweetResponseByIndex(-1).RawMessage);

            Assert.AreEqual("Index out of bounds: 300", 
                tweetResponseQueue.GetRawTweetResponseByIndex(300).RawMessage);

            Assert.AreEqual("Index out of bounds: 777", 
                tweetResponseQueue.GetRawTweetResponseByIndex(777).RawMessage);
        }

        [TestMethod]
        public void VerifyThatSettingNewQueueStartTimeClearsTheQueue()
        {
            ITweetResponseQueue tweetResponseQueue = new TweetResponseQueue();

            tweetResponseQueue.StartTime = DateTime.Now;
            _utilityMethods.PopulateTweetResponseQueue(tweetResponseQueue, 444);

            tweetResponseQueue.StartTime = DateTime.Now;

            Assert.AreEqual(0, tweetResponseQueue.Count);
        }
    }
}
