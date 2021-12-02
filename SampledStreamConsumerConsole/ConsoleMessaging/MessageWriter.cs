using System;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;

namespace SampledStreamConsumerConsole.ConsoleMessaging
{
    public class MessageWriter : IMessageWriter
    {
        public void WriteMessageLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
