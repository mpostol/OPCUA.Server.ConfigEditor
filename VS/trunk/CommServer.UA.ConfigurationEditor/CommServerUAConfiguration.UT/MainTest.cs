
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAS.UA.Server.ServerConfiguration;

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
      Assert.IsNull(Main.EntryPoint);
      Main _serverConfiguartion = new Main();
      Assert.IsNotNull(Main.EntryPoint);
      Assert.IsNotNull(_serverConfiguartion);
      Assert.IsNull(_serverConfiguartion.Configuration);
      Assert.IsFalse(string.IsNullOrEmpty(_serverConfiguartion.DefaultFileName));
      bool _isDisposed = false;
      _serverConfiguartion.Disposed += (object sender, System.EventArgs e) => _isDisposed = true;
      _serverConfiguartion.Dispose();
      Assert.IsTrue(_isDisposed);
      Assert.IsNull(Main.EntryPoint);
    }
    [TestMethod()]
    public void DefaultConfigurationTest()
    {
      using (Main _serverConfiguartion = new Main())
      {
        Assert.IsNotNull(_serverConfiguartion);
        Assert.IsNull(_serverConfiguartion.Configuration);
        _serverConfiguartion.CreateDefaultConfiguration();
        Assert.IsNotNull(_serverConfiguartion.Configuration);
      }
    }
    [TestMethod()]
    public void OPCDAClienteEntryPointTest()
    {
      bool _isDisposed = false;
      using (Main _serverConfiguartion = new Main())
      {
        Assert.IsNotNull(_serverConfiguartion.OPCDAClienteEntryPoint);
        _serverConfiguartion.CommServerEntryPoint.Disposed += (object sender, System.EventArgs e) => _isDisposed = true;
      }
      Assert.IsTrue(_isDisposed);
    }
    [TestMethod()]
    public void CommServerEntryPointTest()
    {
      bool _isDisposed = false;
      using (Main _serverConfiguartion = new Main())
      {
        Assert.IsNotNull(_serverConfiguartion.CommServerEntryPoint);
        _serverConfiguartion.CommServerEntryPoint.Disposed += (object sender, System.EventArgs e) => _isDisposed = true;
      }
      Assert.IsTrue(_isDisposed);
    }
  }
}