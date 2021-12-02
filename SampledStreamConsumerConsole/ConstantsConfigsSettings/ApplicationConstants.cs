using System.Collections.Generic;

namespace SampledStreamConsumerConsole.ConstantsConfigsSettings
{
    public static class ApplicationConstants
    {
        public static readonly string AppSettingsConfigFileName = "Config.json";
        public static readonly uint DefaultTimeoutSeconds = 5;
        public static readonly uint DefaultMaximumTimeoutSeconds = 60;
        public static readonly uint DefaultConnectionAttemptPauseSeconds = 5;
        public static readonly uint DefaultMaxConnectionAttempts = 5;
        public static readonly uint DefaultSecondsBeforeStatisticsReports = 1;
        public static readonly string ConsoleDisplayVerbosityNone = "None";
        public static readonly string ConsoleDisplayVerbosityNormal = "Normal";
        public static readonly string ConsoleDisplayVerbosityDetailed = "Detailed";
        public static readonly string ConsoleDisplayVerbosityVerbose = "Verbose";

        public static readonly List<string> ConsoleDisplayVerbosityLevels = new List<string>
        {
            ConsoleDisplayVerbosityNormal,
            ConsoleDisplayVerbosityDetailed,
            ConsoleDisplayVerbosityVerbose
        };
    }
}
