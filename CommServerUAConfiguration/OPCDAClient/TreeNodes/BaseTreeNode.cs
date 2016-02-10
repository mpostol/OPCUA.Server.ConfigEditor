//<summary>
//  Title   : Base Tree Node
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

using System.Data;
using System.Windows.Forms;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient.TreeNodes
{
  internal interface I4SelectionHandler
  {
    bool CanBeAccepted { get; }
    object WrapperForPropertyGrid { get; }
  }
  internal class BaseTreeNode<type>: BaseTreeNode, I4SelectionHandler
    where type: class
  {
    protected type MyWrapper { get; private set; }
    internal BaseTreeNode( type row, string text )
    {
      MyWrapper = row;
      Text = text;
    }
    internal new type Tag { get { return base.Tag as type; } set { base.Tag = value; } }

    #region I4SelectionHandler Members
    public virtual bool CanBeAccepted
    {
      get { return false; }
    }
    /// <summary>
    /// Gets the wrapper to be dispalied in the propertu grid.
    /// </summary>
    /// <value>The wrapper2 dispaly.</value>
    public virtual object WrapperForPropertyGrid { get { return MyWrapper; } }
    #endregion

  }
  /// <summary>
  /// Base Tree Node
  /// </summary>
  internal class BaseTreeNode: TreeNode
  {
    protected virtual void FillUpIdentifier( OPCItemIdentifier ret )
    {
      if ( Parent == null )
        return;
      ( (BaseTreeNode)Parent ).FillUpIdentifier( ret );
    }
  }
}