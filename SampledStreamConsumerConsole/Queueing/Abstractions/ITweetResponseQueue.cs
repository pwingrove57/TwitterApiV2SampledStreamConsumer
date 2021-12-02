using SampledStreamConsumerConsole.Models.Abstractions;
using System;

namespace SampledStreamConsumerConsole.Queueing.Abstractions
{
    public interface ITweetResponseQueue
    {
        DateTime StartTime { get; set; }
        int Count { get; }
        IRawTweetResponse GetRawTweetResponseByIndex(int tweetIndex);
        void Enqueue(IRawTweetResponse item);
        bool TryPeek(out IRawTweetResponse result);
    }
}