using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAS.UA.Server.ServerConfiguration;

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
  }
}
