using System;
using SampledStreamConsumerConsole.Models.Abstractions;

namespace SampledStreamConsumerConsole.Models
{
    public class RawTweetResponse : IRawTweetResponse
    {
        public long TicksOnReceipt { get; }

        public string RawMessage { get; }

        public RawTweetResponse(string rawMessage, DateTime timeOfReceipt)
        {
            TicksOnReceipt = timeOfReceipt.Ticks;
            RawMessage = rawMessage;
        }
    }
}
