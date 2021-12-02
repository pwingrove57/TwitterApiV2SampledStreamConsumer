namespace SampledStreamConsumerConsole.Models.Abstractions
{
    public interface IRawTweetResponse
    {
        long TicksOnReceipt { get; }
        string RawMessage { get; }
    }
}