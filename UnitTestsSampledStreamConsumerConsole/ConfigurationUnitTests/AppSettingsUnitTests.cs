using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampledStreamConsumerConsole.ConstantsConfigsSettings;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using UnitTestsSampledStreamConsumerConsole.UnitTestUtilities;

namespace UnitTestsSampledStreamConsumerConsole.ConfigurationUnitTests
{
    [TestClass]
    public class AppSettingsUnitTests
    {
        [TestMethod]
        public void VerifyThatAppSettingsConstructorCorrectlyResolvesGoodConfigurationPropertyValues()
        {
            IAppSettings appSettings = new AppSettings(UnitTestConstants.AppSettingsConfigFileName, "anotherString");

            Assert.AreEqual(UnitTestConstants.UnitTestConfigUrlOne, appSettings.TwitterApiV2SampledStreamUrl);
            Assert.AreEqual((uint)10, appSettings.ConnectionTimeoutSeconds);
            Assert.AreEqual((uint)4, appSettings.NextConnectionAttemptPauseSeconds);
            Assert.AreEqual((uint)4, appSettings.MaxConnectionAttempts);
            Assert.AreEqual((uint)3, appSettings.SecondsBeforeStatisticsReports);
            Assert.AreEqual("Verbose", appSettings.ConsoleDisplayVerbosity);
        }

        [TestMethod]
        public void VerifyThatAppSettingsConstructorCorrectlyResolvesInvalidConfigurationPropertyValues()
        {
            IAppSettings appSettings = new AppSettings(UnitTestConstants.AppSettingsInvalidConfigValuesFileName, "anotherString");

            Assert.AreEqual(UnitTestConstants.UnitTestConfigUrlOne, appSettings.TwitterApiV2SampledStreamUrl);
            Assert.AreEqual((uint)10, appSettings.ConnectionTimeoutSeconds);
            Assert.AreEqual((uint)4, appSettings.NextConnectionAttemptPauseSeconds);
            Assert.AreEqual(ApplicationConstants.DefaultMaxConnectionAttempts, appSettings.MaxConnectionAttempts);
            Assert.AreEqual((uint)3, appSettings.SecondsBeforeStatisticsReports);
            Assert.AreEqual(ApplicationConstants.ConsoleDisplayVerbosityNone, appSettings.ConsoleDisplayVerbosity);
        }

        [TestMethod]
        public void VerifyThatAppSettingsConstructorCorrectlyResolvesMissingConfigurationPropertyValues()
        {
            IAppSettings appSettings = new AppSettings(UnitTestConstants.AppSettingsMissingConfigElementsFileName, "anotherString");

            Assert.AreEqual(UnitTestConstants.UnitTestConfigUrlOne, appSettings.TwitterApiV2SampledStreamUrl);
            Assert.AreEqual((uint)10, appSettings.ConnectionTimeoutSeconds);
            Assert.AreEqual(ApplicationConstants.DefaultConnectionAttemptPauseSeconds, appSettings.NextConnectionAttemptPauseSeconds);
            Assert.AreEqual((uint)4, appSettings.MaxConnectionAttempts);
            Assert.AreEqual((uint)3, appSettings.SecondsBeforeStatisticsReports);
            Assert.AreEqual(ApplicationConstants.ConsoleDisplayVerbosityNone, appSettings.ConsoleDisplayVerbosity);
        }
    }
}