//<summary>
//  Title   : Server Tree Node
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.DataPorter.Configurator;
using CAS.UA.Server.ServerConfiguration.OPCDAClient.Wrappers;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient.TreeNodes
{
  internal class ServerTreeNode: BaseTreeNode<ServerWrapperForPropertyGrid>
  {
    public ServerTreeNode( OPCCliConfiguration.ServersRow server )
      : base( new ServerWrapperForPropertyGrid( server ), server.Name )
    {
      foreach ( OPCCliConfiguration.SubscriptionsRow item in server.GetSubscriptionsRows() )
        this.Nodes.Add( new SubscriptionTreeNodes( item ) );
    }
    protected override void FillUpIdentifier( OPCItemIdentifier ret )
    {
      ret.ServerName = MyWrapper.Name;
      base.FillUpIdentifier( ret );
    }
  }
}
