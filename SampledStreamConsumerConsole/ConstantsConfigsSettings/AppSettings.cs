using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;

namespace SampledStreamConsumerConsole.ConstantsConfigsSettings
{
    public class AppSettings : IAppSettings
    {
        public string BearerToken { get; }
        public string ConfigFilePath { get; }
        public string ConfigFileName { get; }
        public string TwitterApiV2SampledStreamUrl { get; }
        public uint ConnectionTimeoutSeconds { get; }
        public uint NextConnectionAttemptPauseSeconds { get; }
        public uint MaxConnectionAttempts { get; }
        public uint SecondsBeforeStatisticsReports { get; }
        public string ConsoleDisplayVerbosity { get; }

        public AppSettings(string configFileName, string bearerToken)
        {
            BearerToken = bearerToken;

            ConfigFilePath = Directory.GetCurrentDirectory();
            ConfigFileName = configFileName;

            var builder = new ConfigurationBuilder()
                .SetBasePath(ConfigFilePath)
                .AddJsonFile(ConfigFileName, optional: false);

            IConfiguration config = builder.Build();

            TwitterApiV2SampledStreamUrl = config.GetSection("AppSettings")["TwitterApiV2SampledStreamUrl"].Trim();

            ConnectionTimeoutSeconds =
                UInt32.TryParse(config.GetSection("AppSettings")["ConnectionTimeoutSeconds"], out var numResult)
                    ? numResult
                    : ApplicationConstants.DefaultTimeoutSeconds;

            NextConnectionAttemptPauseSeconds =
                UInt32.TryParse(config.GetSection("AppSettings")["NextConnectionAttemptPauseSeconds"], out numResult)
                    ? numResult
                    : ApplicationConstants.DefaultConnectionAttemptPauseSeconds;

            MaxConnectionAttempts =
                UInt32.TryParse(config.GetSection("AppSettings")["MaxConnectionAttempts"], out numResult)
                    ? numResult
                    : ApplicationConstants.DefaultMaxConnectionAttempts;

            SecondsBeforeStatisticsReports =
                UInt32.TryParse(config.GetSection("AppSettings")["SecondsBeforeStatisticsReports"], out numResult)
                    ? numResult
                    : ApplicationConstants.DefaultSecondsBeforeStatisticsReports;

            string verbosityValue;
            ConsoleDisplayVerbosity = 
                ConsoleDisplayVerbosityValueIsValid(verbosityValue = config.GetSection("AppSettings")["ConsoleDisplayVerbosity"])
                    ? verbosityValue
                    : ApplicationConstants.ConsoleDisplayVerbosityNone;
        }

        private bool ConsoleDisplayVerbosityValueIsValid(string configValue)
        {
            return ApplicationConstants.ConsoleDisplayVerbosityLevels.Contains(configValue);
        }
    }
}
