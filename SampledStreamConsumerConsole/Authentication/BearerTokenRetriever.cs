using System.IO;
using Microsoft.Extensions.Configuration;

namespace SampledStreamConsumerConsole.Authentication
{
    public class BearerTokenRetriever
    {
        public string BearerToken { get; }

        public BearerTokenRetriever(string tokenFilePath)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(tokenFilePath, optional: false);

            IConfiguration config = builder.Build();

            BearerToken = config.GetSection("Tokens")["TwitterApiBearerToken"].Trim();
        }
    }
}
