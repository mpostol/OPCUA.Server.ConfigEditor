//<summary>
//  Title   : Subsription Tree Node
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

using CAS.UA.Server.ServerConfiguration.OPCDAClient.Wrappers;
using CAS.DataPorter.Configurator;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient.TreeNodes
{
  class SubscriptionTreeNodes: BaseTreeNode<SubscriptionWrapperForPropertyGrid>
  {
    public SubscriptionTreeNodes( OPCCliConfiguration.SubscriptionsRow subscription )
      : base( new SubscriptionWrapperForPropertyGrid( subscription ), subscription.Name )
    {
      foreach ( OPCCliConfiguration.ItemsRow item in subscription.GetItemsRows() )
        this.Nodes.Add( new ItemTreeNode( item ) );
    }
    protected override void FillUpIdentifier( OPCItemIdentifier ret )
    {
      ret.SubscriptionName = MyWrapper.Name;
      base.FillUpIdentifier( ret );
    }
  }
}
