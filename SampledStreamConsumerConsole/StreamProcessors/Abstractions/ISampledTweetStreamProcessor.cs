using System.Threading.Tasks;
using SampledStreamConsumerConsole.Clients.Abstractions;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;

namespace SampledStreamConsumerConsole.StreamProcessors.Abstractions
{
    public interface ISampledTweetStreamProcessor
    {
        Task ProcessTwitterStream(ICustomHttpClient customHttpClient, 
            ITweetResponseQueue tweetResponseQueue, IAppSettings appSettings, ITweetInfoWriter tweetInfoWriter, IMessageWriter messageWriter);
    }
}