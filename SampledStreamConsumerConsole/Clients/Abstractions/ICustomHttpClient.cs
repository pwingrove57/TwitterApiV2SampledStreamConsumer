using System.IO;
using System.Threading.Tasks;

namespace SampledStreamConsumerConsole.Clients.Abstractions
{
    public interface ICustomHttpClient
    {
        Task<Stream> GetStreamAsync(string requestUri);
    }
}