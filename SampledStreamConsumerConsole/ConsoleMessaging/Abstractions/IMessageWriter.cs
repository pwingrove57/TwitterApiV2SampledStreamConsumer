namespace SampledStreamConsumerConsole.ConsoleMessaging.Abstractions
{
    public interface IMessageWriter
    {
        void WriteMessageLine(string message);
    }
}