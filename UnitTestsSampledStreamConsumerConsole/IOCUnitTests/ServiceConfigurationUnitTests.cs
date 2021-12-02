using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampledStreamConsumerConsole.AppControls.Abstractions;
using SampledStreamConsumerConsole.Clients.Abstractions;
using SampledStreamConsumerConsole.ConsoleMessaging.Abstractions;
using SampledStreamConsumerConsole.ConstantsConfigsSettings.Abstractions;
using SampledStreamConsumerConsole.IOC;
using SampledStreamConsumerConsole.ProgramExecution.Abstractions;
using SampledStreamConsumerConsole.Queueing.Abstractions;
using SampledStreamConsumerConsole.Statistics.Abstractions;
using SampledStreamConsumerConsole.StreamProcessors.Abstractions;
using UnitTestsSampledStreamConsumerConsole.UnitTestUtilities;

namespace UnitTestsSampledStreamConsumerConsole.IOCUnitTests
{
    [TestClass]
    public class ServiceConfigurationUnitTests
    {
        [TestMethod]
        public void VerifyThatServiceConfigurationProperlyConfiguresAllServices()
        {
            var servicesCollection = new ServiceConfiguration().ConfigureServices(UnitTestConstants.AppSettingsConfigFileName,
                                                                                  UnitTestConstants.UnitTestBearerToken);

            var servicesProvider = servicesCollection.BuildServiceProvider();

            Assert.AreEqual(11, servicesCollection.Count);

            Assert.IsNotNull(servicesProvider.GetService<IControlInputs>());
            Assert.IsNotNull(servicesProvider.GetService<IAppSettings>());
            Assert.IsNotNull(servicesProvider.GetService<ICustomHttpClient>());
            Assert.IsNotNull(servicesProvider.GetService<ITweetResponseQueue>());
            Assert.IsNotNull(servicesProvider.GetService<ISampledTweetStreamProcessor>());
            Assert.IsNotNull(servicesProvider.GetService<IStatisticsCalculator>());
            Assert.IsNotNull(servicesProvider.GetService<IStatisticsReporter>());
            Assert.IsNotNull(servicesProvider.GetService<IStatisticsProcessor>());
            Assert.IsNotNull(servicesProvider.GetService<ITweetInfoWriter>());
            Assert.IsNotNull(servicesProvider.GetService<IMessageWriter>());
            Assert.IsNotNull(servicesProvider.GetService<IConsoleApplicationRunner>());
        }
    }
}
