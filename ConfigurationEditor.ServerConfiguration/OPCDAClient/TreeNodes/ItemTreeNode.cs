//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.DataPorter.Configurator;
using CAS.UA.Server.ServerConfiguration.OPCDAClient.Wrappers;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient.TreeNodes
{
  internal class ItemTreeNode : BaseTreeNode<ItemWrapperForPropertyGrid>
  {
    public ItemTreeNode(OPCCliConfiguration.ItemsRow item) : base(new ItemWrapperForPropertyGrid(item), item.Name)
    {
    }

    public override bool CanBeAccepted => true;

    internal OPCItemIdentifier GetIdentifier()
    {
      OPCItemIdentifier ret = new OPCItemIdentifier();
      FillUpIdentifier(ret);
      return ret;
    }

    protected override void FillUpIdentifier(OPCItemIdentifier ret)
    {
      ret.ItemName = MyWrapper.Name;
      base.FillUpIdentifier(ret);
    }
  }
}