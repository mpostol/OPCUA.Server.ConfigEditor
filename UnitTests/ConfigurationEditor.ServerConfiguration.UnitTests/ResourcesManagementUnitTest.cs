using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.EmbeddedResources;
using CAS.UA.Server.ServerConfiguration;
using Opc.Ua;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests
{
  [TestClass]
  [DeploymentItem(m_Path, m_Path)]
  public class ResourcesManagementUnitTest
  {
    [TestMethod]
    public void GetDefaultServerConfigurationFileMethod()
    {
      Stream _defaultConfigurationFile = ResourcesManagement.GetDefaultServerConfigurationFile();
      Assert.IsNotNull(_defaultConfigurationFile);
    }
    [TestMethod]
    public void DeploymentTest()
    {
      FileInfo file = new FileInfo(FilePath);
      Assert.IsTrue(file.Exists);
    }
    [TestMethod]
    public void LoadTestMethod()
    {
      using (Main _MAIN = new Main())
      {
        FileInfo _FileInfo = new FileInfo(FilePath);
        CASConfiguration _configuration = CASConfiguration.Load(_FileInfo, ApplicationType.Server, typeof(CASConfiguration), false);
        Assert.IsNotNull(_configuration);
      }
    }
    private string FilePath { get { return Path.Combine(m_Path, m_ConfigurationFileName); } }
    private const string m_Path = @"EmbeddedExample\DemoConfiguration";
    private const string m_ConfigurationFileName = @"BoilerExample.uasconfig";

  }
}
