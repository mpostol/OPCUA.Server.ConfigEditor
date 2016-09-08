
using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.EmbeddedResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests
{
  [TestClass]
  public class ResourcesManagementUnitTest
  {
    [TestMethod]
    public void GetDefaultServerConfigurationFileMethod()
    {
      using (Stream _defaultConfigurationFile = ResourcesManagement.GetDefaultServerConfigurationFile())
      {
        Assert.IsNotNull(_defaultConfigurationFile);
      }
    }
  }
}
