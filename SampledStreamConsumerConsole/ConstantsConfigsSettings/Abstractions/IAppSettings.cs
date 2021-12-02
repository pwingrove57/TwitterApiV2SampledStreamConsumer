namespace SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions
{
    public interface IAppSettings
    {
        string BearerToken { get; }
        string ConfigFilePath { get; }
        string ConfigFileName { get; }
        string TwitterApiV2SampledStreamUrl { get; }
        uint ConnectionTimeoutSeconds { get; }
        uint NextConnectionAttemptPauseSeconds { get; }
        uint MaxConnectionAttempts { get; }
        uint SecondsBeforeStatisticsReports { get; }
        string ConsoleDisplayVerbosity { get; }
    }
}