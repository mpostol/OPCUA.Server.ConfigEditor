
using CAS.UA.Server.ServerConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OPCFSDKConfig.UT
{

  /// <summary>
  ///This is a test class for MainTest and is intended
  ///to contain all MainTest Unit Tests
  ///</summary>
  [TestClass()]
  public class MainTest
  {

    /// <summary>
    ///A test for Main Constructor
    ///</summary>
    [TestMethod()]
    public void MainConstructorTest()
    {
      using (Main _serverConfiguration = new Main())
      {
        Assert.IsNotNull(Main.EntryPoint);
        Assert.IsNull(_serverConfiguration.Configuration);
        Assert.IsFalse(string.IsNullOrEmpty(_serverConfiguration.DefaultFileName));
        bool _isDisposed = false;
        _serverConfiguration.Disposed += (object sender, System.EventArgs e) => _isDisposed = true;
        _serverConfiguration.Dispose();
        Assert.IsTrue(_isDisposed);
        Assert.IsNull(Main.EntryPoint);
      }
    }
    [TestMethod()]
    public void DefaultConfigurationTest()
    {
      using (Main _serverConfiguration = new Main())
      {
        Assert.IsNotNull(_serverConfiguration);
        Assert.IsNull(_serverConfiguration.Configuration);
        _serverConfiguration.CreateDefaultConfiguration();
        Assert.IsNotNull(_serverConfiguration.Configuration);
      }
    }
    [TestMethod()]
    public void OPCDAClientEntryPointTest()
    {
      bool _isDisposed = false;
      using (Main _serverConfiguration = new Main())
      {
        Assert.IsNotNull(_serverConfiguration.OPCDAClienteEntryPoint);
        _serverConfiguration.CommServerEntryPoint.Disposed += (object sender, System.EventArgs e) => _isDisposed = true;
      }
      Assert.IsTrue(_isDisposed);
    }
    [TestMethod()]
    public void CommServerEntryPointTest()
    {
      bool _isDisposed = false;
      using (Main _serverConfiguration = new Main())
      {
        Assert.IsNotNull(_serverConfiguration.CommServerEntryPoint);
        _serverConfiguration.CommServerEntryPoint.Disposed += (object sender, System.EventArgs e) => _isDisposed = true;
      }
      Assert.IsTrue(_isDisposed);
    }

  }
}