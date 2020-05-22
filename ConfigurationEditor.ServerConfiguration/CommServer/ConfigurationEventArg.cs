//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using UAOOI.ProcessObserver.Configuration;

namespace CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.CommServer
{
  internal class ConfigurationEventArg
  {
    public ComunicationNet Configuration { get; private set; }

    public ConfigurationEventArg(ComunicationNet config)
    {
      Configuration = config;
    }
  }
}