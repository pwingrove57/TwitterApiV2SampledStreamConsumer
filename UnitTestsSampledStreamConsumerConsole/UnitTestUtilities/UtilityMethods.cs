using SampledStreamConsumerConsole.Models;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace UnitTestsSampledStreamConsumerConsole.UnitTestUtilities
{
    /// <summary>
    /// UtilityMethods - Should be excluded from code coverage. It contains
    /// methods and properties used by the unit tests in this solution.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class UtilityMethods
    {
        public void PopulateTweetResponseQueue(ITweetResponseQueue tweetResponseQueue, uint numItems)
        {
            for (int tweetIndex = 0; tweetIndex < numItems; tweetIndex++)
            {
                var rawTweetResponse = new RawTweetResponse($"This is tweet # {tweetIndex + 1}, having queue index # {tweetIndex}", DateTime.Now);
                tweetResponseQueue.Enqueue(rawTweetResponse);
            }
        }
    }
}
