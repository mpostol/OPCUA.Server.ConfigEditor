//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.UA.IServerConfiguration;
using CAS.UA.Server.ServerConfiguration;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CAS.CommServer.UA.Server.ServerConfiguration.UnitTests.Instrumentation
{
  internal class ServiceLocation : ServiceLocatorImplBase
  {
    internal static IServiceLocator ServiceLocationSingleton()
    {
      if (m_ServiceLocation == null)
      {
        m_ServiceLocation = new ServiceLocation();
        ServiceLocator.SetLocatorProvider(() => m_ServiceLocation);
      }
      return m_ServiceLocation;
    }
    protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
    {
      throw new NotImplementedException();
    }
    /// <summary>
    /// When implemented by inheriting classes, this method will do the actual work of resolving
    /// the requested service instance.
    /// </summary>
    /// <param name="serviceType">Type of instance requested.</param>
    /// <param name="key">Name of registered service you want. May be null.</param>
    /// <returns>The requested service instance.</returns>
    /// <exception cref="System.NotImplementedException">
    /// key
    /// or
    /// Only IConfiguration is supported
    /// </exception>
    protected override object DoGetInstance(Type serviceType, string key)
    {
      if (!String.IsNullOrEmpty(key))
        throw new NotImplementedException($"{nameof(key)} must bu null or empty");
      if (serviceType != typeof(IConfiguration))
        throw new NotImplementedException("Only IConfiguration is supported");
      return CreateInstance(typeof(Main).Assembly);
    }
    /// <summary>
    /// Creates the instance.
    /// </summary>
    /// <param name="pluginAssembly">The plugin assembly.</param>
    /// <returns>IConfiguration.</returns>
    /// <exception cref="System.ArgumentNullException">pluginAssembly</exception>
    private static IConfiguration CreateInstance(Assembly pluginAssembly)
    {
      if (pluginAssembly == null)
        throw new ArgumentNullException(nameof(pluginAssembly));
      IConfiguration _serverConfiguration = null;
      string iName = typeof(IConfiguration).ToString();
      foreach (Type pluginType in pluginAssembly.GetExportedTypes())
        //Only look at public types
        if (pluginType.IsPublic && !pluginType.IsAbstract && pluginType.GetInterface(iName) != null)
        {
          _serverConfiguration = (IConfiguration)Activator.CreateInstance(pluginType);
          break;
        }
      return _serverConfiguration;
    }
    private static ServiceLocation m_ServiceLocation;

  }
}
