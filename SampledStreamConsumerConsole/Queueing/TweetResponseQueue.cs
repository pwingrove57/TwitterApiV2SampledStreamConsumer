using SampledStreamConsumerConsole.Models;
using System;
using System.Collections.Concurrent;
using System.Linq;
using SampledStreamConsumerConsole.Models.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;

namespace SampledStreamConsumerConsole.Queueing
{
    /// <summary>
    /// TweetResponseQueue - Provides a thread-safe FIFO queue for capturing sampled tweets
    /// </summary>
    public class TweetResponseQueue : ConcurrentQueue<IRawTweetResponse>, ITweetResponseQueue
    {
        private readonly object _propertyLock = new object();

        private DateTime _startTime;
        public DateTime StartTime
        {
            get
            {
                lock (_propertyLock)
                {
                    return _startTime;
                }
            }
            set
            {
                lock (_propertyLock)
                {
                    // New start time clears the queue
                    if (Count > 0)
                    {
                        Clear();
                    }
                    _startTime = value;
                }
            }
        }

        public IRawTweetResponse GetRawTweetResponseByIndex(int tweetIndex)
        {
            return tweetIndex < 0 || tweetIndex > this.Count - 1
                ? new RawTweetResponse($"Index out of bounds: {tweetIndex}", DateTime.Now)
                : this.ElementAt(tweetIndex);
        }
    }
}
