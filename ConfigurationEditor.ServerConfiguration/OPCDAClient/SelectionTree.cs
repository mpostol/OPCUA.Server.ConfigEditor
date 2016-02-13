//<summary>
//  Title   : Selection Tree 
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

using System;
using System.Windows.Forms;
using CAS.DataPorter.Configurator;
using CAS.UA.Server.ServerConfiguration.Controls;
using CAS.UA.Server.ServerConfiguration.OPCDAClient.TreeNodes;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient
{
  internal partial class SelectionTree: UserControl, IEnableOK
  {
    #region constructor
    public SelectionTree()
    {
      InitializeComponent();
      this.m_PropertyGrid.SelectedObject = null;
    } 
    #endregion

    #region public
    public OPCCliConfiguration Configuration
    {
      set
      {
        foreach ( OPCCliConfiguration.ServersRow item in value.Servers )
          m_TreeView.Nodes.Add( new ServerTreeNode( item ) );
        m_TreeView.Refresh();
        m_SplitContainer.Refresh();
      }
    }
    public OPCItemIdentifier Selection
    {
      get
      {
        ItemTreeNode item = m_TreeView.SelectedNode as ItemTreeNode;
        if ( item == null )
          return null;
        return item.GetIdentifier();
      }
    }
    #endregion

    #region IEnableOK Members
    public event EventHandler<OKButtonEventArgs> OnStateChanged;
    #endregion

    #region private
    private void m_TreeView_AfterSelect( object sender, TreeViewEventArgs e )
    {
      I4SelectionHandler selectedNode = e.Node as I4SelectionHandler;
      if ( selectedNode != null )
      {
        m_PropertyGrid.SelectedObject = selectedNode.WrapperForPropertyGrid;
        if ( OnStateChanged != null )
          OnStateChanged( sender, new OKButtonEventArgs( selectedNode.CanBeAccepted ) );
      }
      else
        m_PropertyGrid.SelectedObject = null;
    }
    #endregion
  }
}
