using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.Models.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using System;

namespace SampledStreamConsumerConsole.ConsoleMessaging
{
    public class TweetInfoWriter : ITweetInfoWriter
    {
        public void WriteTweetInfo(IAppSettings appSettings, ITweetResponseQueue tweetResponseQueue, IRawTweetResponse rawTweetResponse)
        {
            switch (appSettings.ConsoleDisplayVerbosity)
            {
                case "Normal":
                    Console.WriteLine($@"Queued Tweet Count: {tweetResponseQueue.Count}");
                    break;

                case "Detailed":
                    Console.WriteLine($@"Queued Tweet Count: {tweetResponseQueue.Count}, Ticks on Receipt: {rawTweetResponse.TicksOnReceipt}");
                    break;

                case "Verbose":
                    Console.WriteLine(
                        $@"Queued Tweet Count: {tweetResponseQueue.Count}, Ticks on Receipt: {rawTweetResponse.TicksOnReceipt}, Tweet Message: {rawTweetResponse.RawMessage}");
                    break;
            }
        }
    }
}
