
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.ServiceLocation;
using CAS.UA.IServerConfiguration;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests
{
  [TestClass]
  public class IConfigurationUnitTest
  {
    [TestMethod]
    public void CreateInstanceTestMethod()
    {
      Assert.IsTrue(ServiceLocator.IsLocationProviderSet);
      IConfiguration _newInstance = ServiceLocator.Current.GetInstance<IConfiguration>();
      Assert.IsNotNull(_newInstance);
    }
  }
}
