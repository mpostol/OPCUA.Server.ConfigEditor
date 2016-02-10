//<summary>
//  Title   : Item Tree Node
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
  class ItemTreeNode: BaseTreeNode<ItemWrapperForPropertyGrid>
  {
    public ItemTreeNode( OPCCliConfiguration.ItemsRow item )
      : base( new ItemWrapperForPropertyGrid( item ), item.Name )
    { }
    public override bool CanBeAccepted
    {
      get { return true; }
    }
    internal OPCItemIdentifier GetIdentifier()
    {
      OPCItemIdentifier ret = new OPCItemIdentifier();
      FillUpIdentifier( ret );
      return ret;
    }
    protected override void FillUpIdentifier( OPCItemIdentifier ret )
    {
      ret.ItemName = MyWrapper.Name;
      base.FillUpIdentifier( ret );
    }
  }
}
