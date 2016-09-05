using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.EmbeddedResources;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests
{
  [TestClass]
  public class ResourcesManagementUnitTest
  {
    [TestMethod]
    public void GetDefaultServerConfigurationFileMethod()
    {
      Stream _defaultConfigurationFile = ResourcesManagement.GetDefaultServerConfigurationFile();
      Assert.IsNotNull(_defaultConfigurationFile);
    }
  }
}
