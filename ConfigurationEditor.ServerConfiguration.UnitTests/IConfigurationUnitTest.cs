//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.UA.IServerConfiguration;
using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
