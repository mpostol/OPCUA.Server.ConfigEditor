//<summary>
//  Title   : Selection Tree For CommServer
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
using CAS.NetworkConfigLib;
using CAS.UA.Server.ServerConfiguration.Controls;
using System.Collections.Generic;
using System.Drawing;
using CAS.UA.Server.ServerConfiguration.Properties;

namespace CAS.UA.Server.ServerConfiguration.CommServer
{
  internal partial class SelectionTreeForCommServer: UserControl, IEnableOK
  {
    #region constructor
    public SelectionTreeForCommServer()
    {
      InitializeComponent();
    } 
    #endregion

    #region public
    public ComunicationNet Configuration
    {
      set
      {
        ImageList il = new ImageList();
        il.Images.Add( Resources.tag_element_48_full );
        il.Images.Add( Resources.Folder_Open );
        m_TreeView.ImageList = il;
        string[] completeTagPath;
        List<string> listOfProperPathElements;
        string[] splittedTagPath;
        char[] charsplit = Resources.SplitSignForCommServerTag.ToCharArray();
        for ( int idx = 0; idx < value.Tags.Count;idx++ )
        {
          listOfProperPathElements = new List<string>();
          CAS.NetworkConfigLib.ComunicationNet.TagsRow tr = value.Tags[ idx ];
          splittedTagPath = tr.Name.Split( charsplit[ 0 ] );
          for ( int px = 0; px < splittedTagPath.Length; px++ )
            if ( !( String.IsNullOrEmpty( splittedTagPath[ px ] ) ) )
              listOfProperPathElements.Add( splittedTagPath[ px ] );
          completeTagPath = listOfProperPathElements.ToArray();
          TreeNode lastNode = null;
          TreeNode[] currentNodeArray;
          TreeNodeCollection tnc;
          string partOfTheTagPath; 
          for ( int levelCounter = 0; levelCounter < completeTagPath.Length; levelCounter++ )
          {
            partOfTheTagPath = completeTagPath[ levelCounter ];
              if ( levelCounter == 0 )
                tnc = m_TreeView.Nodes;
              else
                tnc = lastNode.Nodes;
              currentNodeArray = tnc.Find( partOfTheTagPath, false );
              if ( currentNodeArray == null || currentNodeArray.Length == 0 || currentNodeArray[ 0 ] == null )
              {
                lastNode = new TreeNode( partOfTheTagPath );
                lastNode.Name = partOfTheTagPath;
                if ( levelCounter == completeTagPath.Length - 1 )
                {
                  lastNode.Tag = tr.Name;
                  lastNode.ImageIndex = 0;
                  lastNode.SelectedImageIndex = 0;
                }
                else
                {
                  lastNode.ImageIndex = 1;
                  lastNode.SelectedImageIndex = 1;
                }
                tnc.Add( lastNode );
              }
              else
                lastNode = currentNodeArray[ 0 ];
          }
        }
        m_TreeView.Refresh();
      }
    }

    public string Selection
    {
      get
      {
        TreeNode item = m_TreeView.SelectedNode;
        if ( item == null || item.Tag == null)
          return null;
        return item.Tag.ToString();
      }
    }
    #endregion

    #region IEnableOK Members
    public event EventHandler<OKButtonEventArgs> OnStateChanged;
    #endregion


    #region private
    private void m_TreeViewForCommServer_AfterSelect( object sender, TreeViewEventArgs e )
    {
      if ( e.Node.Tag != null )
      {
        if ( OnStateChanged != null )
          OnStateChanged( sender, new OKButtonEventArgs( true ) );
      }
      else
      {
        if ( OnStateChanged != null )
          OnStateChanged( sender, new OKButtonEventArgs( false ) );
      }
    }
    #endregion
  }
}
