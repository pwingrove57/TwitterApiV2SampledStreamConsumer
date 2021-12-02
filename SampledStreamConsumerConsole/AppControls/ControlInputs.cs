using System;
using SampledStreamConsumerConsole.AppControls.Abstractions;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;

namespace SampledStreamConsumerConsole.AppControls
{
    /// <summary>
    /// AppControls - Static class that provides application program control methods
    /// </summary>
    public class ControlInputs : IControlInputs
    {
        /// <summary>
        /// MonitorKeyPress - Waits for the user to press the [ESC] key, and calls Environment.Exit() to terminate the program
        /// </summary>
        public void MonitorKeyPress(IMessageWriter messageWriter)
        {
            do
            { // Wait here for the ESC key press
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            messageWriter.WriteMessageLine($@"{Environment.NewLine}<ESC> Pressed, Application Will Terminate{Environment.NewLine}");

            Environment.Exit(0);
        }
    }
}
