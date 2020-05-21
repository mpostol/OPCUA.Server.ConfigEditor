//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.CommServer.UA.Server.ServerConfiguration.UnitTests.Instrumentation;
using CAS.UA.Server.ServerConfiguration;
using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests
{
  [TestClass]
  [DeploymentItem(m_Path, m_Path)]
  public class AssemblyInitializeClass
  {
    internal static string FilePath { get { return Path.Combine(m_Path, m_ConfigurationFileName); } }
    internal const string m_Path = @"EmbeddedExample\DemoConfiguration";
    internal const string m_ConfigurationFileName = @"BoilerExample.uasconfig";
    private static TestContext m_Context;

    [AssemblyInitialize()]
    public static void AssemblyInitializeMethod(TestContext context)
    {
      m_Context = context;
      IServiceLocator _serviceLocator = ServiceLocation.ServiceLocationSingleton();
      Assert.IsNotNull(ServiceLocation.ServiceLocationSingleton());
      Assert.AreSame(_serviceLocator, ServiceLocation.ServiceLocationSingleton());
    }
    [ClassCleanup]
    public static void ClassCleanupMethod()
    {
      if (Main.EntryPoint == null)
        throw new System.ApplicationException($"Program error {nameof(Main.EntryPoint)} is empty.");
    }
    [TestMethod]
    public void DeploymentTest()
    {
      FileInfo file = new FileInfo(FilePath);
      Assert.IsTrue(file.Exists);
      Assert.IsNotNull(m_Context);
    }
  }
}
