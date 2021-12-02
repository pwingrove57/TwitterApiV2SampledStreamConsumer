using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;

namespace SampledStreamConsumerConsole.AppControls.Abstractions
{
    public interface IControlInputs
    {
        /// <summary>
        /// MonitorKeyPress - Waits for the user to press the [ESC] key, and calls Environment.Exit() to terminate the program
        /// </summary>
        void MonitorKeyPress(IMessageWriter messageWriter);
    }
}