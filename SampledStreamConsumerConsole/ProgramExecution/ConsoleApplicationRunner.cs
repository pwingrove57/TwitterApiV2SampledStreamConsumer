using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SampledStreamConsumerConsole.AppControls.Abstractions;
using SampledStreamConsumerConsole.Clients.Abstractions;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.ProgramExecution.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using SampledStreamConsumerConsole.Statistics.Abstractions;
using SampledStreamConsumerConsole.StreamProcessors.Abstractions;

#pragma warning disable 4014

namespace SampledStreamConsumerConsole.ProgramExecution
{
    public class ConsoleApplicationRunner : IConsoleApplicationRunner
    {
        private readonly IControlInputs _controlInputs;
        private readonly IAppSettings _appSettings;
        private readonly ICustomHttpClient _customHttpClient;
        private readonly ITweetResponseQueue _tweetResponseQueue;
        private readonly ISampledTweetStreamProcessor _tweetStreamProcessor;
        private readonly IStatisticsCalculator _statsCalculator;
        private readonly IStatisticsReporter _statsReporter;
        private readonly IStatisticsProcessor _statsProcessor;
        private readonly ITweetInfoWriter _tweetInfoWriter;
        private readonly IMessageWriter _messageWriter;

        public ConsoleApplicationRunner(IControlInputs controlInputs,
                                  IAppSettings appSettings,
                                  ICustomHttpClient customHttpClient,
                                  ITweetResponseQueue tweetResponseQueue,
                                  ISampledTweetStreamProcessor tweetStreamProcessor,
                                  IStatisticsCalculator statsCalculator,
                                  IStatisticsReporter statsReporter,
                                  IStatisticsProcessor statsProcessor,
                                  ITweetInfoWriter tweetInfoWriter,
                                  IMessageWriter messageWriter)

        {
            _controlInputs = controlInputs;
            _appSettings = appSettings;
            _customHttpClient = customHttpClient;
            _tweetResponseQueue = tweetResponseQueue;
            _tweetStreamProcessor = tweetStreamProcessor;
            _statsCalculator = statsCalculator;
            _statsReporter = statsReporter;
            _statsProcessor = statsProcessor;
            _tweetInfoWriter = tweetInfoWriter;
            _messageWriter = messageWriter;
        }

    public async Task RunTheApplication()
    {
            var connectAttemptCount = 0;

            // We don't need to wait for this task to complete - by design, it blocks until a key is pressed (disable warning 4014)
            Task.Run(() => { _controlInputs.MonitorKeyPress(_messageWriter); });

            // Allows a number (configured) of attempts to connect when connection attempts fail
            while (true)
            {
                try
                {
                    var tasks = new List<Task>
                    {
                        _tweetStreamProcessor.ProcessTwitterStream(_customHttpClient, _tweetResponseQueue, _appSettings, _tweetInfoWriter, _messageWriter),
                        _statsProcessor.GenerateAndDisplayStatistics(_appSettings, _tweetResponseQueue, _statsCalculator, _statsReporter, _messageWriter)
                    };

                    await Task.WhenAll(tasks);
                }
                catch (Exception ex)
                {
                    _messageWriter.WriteMessageLine($@"Error: {ex.Message}");
                    _messageWriter.WriteMessageLine($@"Connection Attempts: {++connectAttemptCount}");

                    if (connectAttemptCount >= _appSettings.MaxConnectionAttempts)
                    {
                        _messageWriter.WriteMessageLine(
                            $@"{Environment.NewLine}Max Connection Attempts Reached, Application Will Terminate After {connectAttemptCount} Attempts{Environment.NewLine}");

                        // Breaks out of the while (true) loop and ends the program
                        break;
                    }

                    _messageWriter.WriteMessageLine($@"Attempting to Connect Again in {_appSettings.NextConnectionAttemptPauseSeconds} Seconds");

                    await Task.Delay(TimeSpan.FromSeconds(_appSettings.NextConnectionAttemptPauseSeconds));
                }
            }
        }
    }
}
