//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.UA.Server.ServerConfiguration.CommServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests
{
  [TestClass]
  public class CommServerConfigurationMainUnitTest
  {
    [TestMethod]
    public void ConstructorTest()
    {
      CommServerConfigurationMain _new = null;
      using (IContainer _components = new Container())
      {
        Assert.IsNotNull(_components.Components);
        Assert.AreEqual<int>(0, _components.Components.Count);
        _new = new CommServerConfigurationMain(_components);
        Assert.AreEqual<int>(1, _components.Components.Count);
        Assert.AreEqual<int>(1, _new.Container.Components.Count);
        Assert.AreSame(_components.Components[0], _new.Container.Components[0]);
        Assert.IsNotNull(_new.OpenFileDialog);
        Assert.IsNotNull(_new.Configuartion);
        Assert.AreEqual<string>(@"CommServerConfiguration", _new.DefaultFileName);
      }
      Assert.IsNull(_new.OpenFileDialog);
      Assert.IsNull(_new.Configuartion);
    }
  }
}