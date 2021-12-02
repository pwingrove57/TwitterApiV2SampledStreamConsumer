using SampledStreamConsumerConsole.Clients.Abstractions;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.Models;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;
using SampledStreamConsumerConsole.StreamProcessors.Abstractions;

namespace SampledStreamConsumerConsole.StreamProcessors
{
    public class SampledTweetStreamProcessor : ISampledTweetStreamProcessor
    {
        public async Task ProcessTwitterStream(ICustomHttpClient customHttpClient, 
            ITweetResponseQueue tweetResponseQueue, IAppSettings appSettings, ITweetInfoWriter tweetInfoWriter, IMessageWriter messageWriter)
        {
            messageWriter.WriteMessageLine($@"{Environment.NewLine}Establishing Twitter Connection");

            using (var streamReader = new StreamReader(await customHttpClient.GetStreamAsync(appSettings.TwitterApiV2SampledStreamUrl)))
            {
                // Start time marks when the Twitter connection was established, and clears the queue of any
                // tweets that may be left over from previous runs
                tweetResponseQueue.StartTime = DateTime.Now;

                messageWriter.WriteMessageLine($@"{Environment.NewLine}Twitter Connection Established");
                messageWriter.WriteMessageLine($@"Enqueue Start Time Mark: {tweetResponseQueue.StartTime:yyyy-MM-dd HH:mm:ss.fffffff}");
                messageWriter.WriteMessageLine($@"Enqueue Start Time Ticks: {tweetResponseQueue.StartTime.Ticks}");

                while (!streamReader.EndOfStream)
                {
                    var message = await streamReader.ReadLineAsync();

                    var rawTweetResponse = new RawTweetResponse(message, DateTime.Now);

                    tweetResponseQueue.Enqueue(rawTweetResponse);

                    tweetInfoWriter.WriteTweetInfo(appSettings, tweetResponseQueue, rawTweetResponse);
                }
            }
        }
    }
}
