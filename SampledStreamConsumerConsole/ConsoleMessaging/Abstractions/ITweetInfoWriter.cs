using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.Models.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;

namespace SampledStreamConsumerConsole.ConsoleMessaging.Abstractions
{
    public interface ITweetInfoWriter
    {
        void WriteTweetInfo(IAppSettings appSettings, ITweetResponseQueue tweetResponseQueue, IRawTweetResponse rawTweetResponse);
    }
}