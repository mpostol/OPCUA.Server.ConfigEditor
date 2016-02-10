//<summary>
//  Title   : Server Wrapper for Property Grid
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20090608: mzbrzezny - created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System.ComponentModel;
using CAS.DataPorter.Configurator;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient.Wrappers
{
  [ReadOnly( true )]
  internal class ServerWrapperForPropertyGrid
  {
    [Description( "Name of the server" )]
    public string Name
    {
      get
      {
        if ( this.mServer.IsNameNull() )
          return null;
        return this.mServer.Name;
      }
      set
      {
        this.mServer.Name = value;
      }
    }
    [Description( "The URL of the server" )]
    public string URL
    {
      get
      {
        return this.mServer.URL;
      }
      set
      {
        this.mServer.URL = value;
      }
    }
    [Description( "The Preferred Specification of the connection" )]
    public global::Opc.Specification PreferedSpecyfication
    {
      get
      {
        return this.mServer.PreferedSpecification;
      }
    }
    [Description( "The locale setting rate for the server" )]
    public string Locale
    {
      get
      {
        if ( this.mServer.IsLocaleNull() )
          return null;
        return this.mServer.Locale;
      }
      set
      {
        this.mServer.Locale = value;
      }
    }
    internal ServerWrapperForPropertyGrid( OPCCliConfiguration.ServersRow server )
    {
      this.mServer = server;
    }
    private OPCCliConfiguration.ServersRow mServer;
  }
}
