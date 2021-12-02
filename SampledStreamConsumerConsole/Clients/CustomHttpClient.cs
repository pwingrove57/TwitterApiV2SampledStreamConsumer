using System;
using System.Net.Http;
using System.Net.Http.Headers;
using SampledStreamConsumerConsole.Clients.Abstractions;
using SampledStreamConsumerConsole.ConstantsConfigsSettings;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;

namespace SampledStreamConsumerConsole.Clients
{
    public class CustomHttpClient : HttpClient, ICustomHttpClient
    {
        public string Url { get; }

        public CustomHttpClient(IAppSettings appSettings)
        {
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", appSettings.BearerToken);

            Url = appSettings.TwitterApiV2SampledStreamUrl;
            Timeout = (appSettings.ConnectionTimeoutSeconds > 5 && appSettings.ConnectionTimeoutSeconds <= ApplicationConstants.DefaultMaximumTimeoutSeconds)
                ? TimeSpan.FromSeconds(appSettings.ConnectionTimeoutSeconds)
                : TimeSpan.FromSeconds(ApplicationConstants.DefaultMaximumTimeoutSeconds);
        }
    }
}
