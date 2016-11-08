using CAS.UA.Server.ServerConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opc.Ua;
using System.IO;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests
{

  [TestClass]
  public class CASConfigurationUnitTest
  {

    [TestMethod]
    public void ConstructorTestMethod()
    {
      CASConfiguration _newConfiguration = new CASConfiguration();
      Assert.IsNull(_newConfiguration.CASExtension);
    }
    [TestMethod]
    public void LoadTestMethod()
    {
      using (Main _MAIN = new Main())
      {
        FileInfo _FileInfo = new FileInfo(AssemblyInitializeClass.FilePath);
        CASConfiguration _configuration = CASConfiguration.Load(_FileInfo, ApplicationType.Server, typeof(CASConfiguration), false);
        Assert.IsNotNull(_configuration);
      }
    }

  }
}
