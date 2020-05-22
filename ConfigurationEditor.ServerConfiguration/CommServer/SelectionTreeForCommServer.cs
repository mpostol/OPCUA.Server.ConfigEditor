//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.Properties;
using CAS.UA.Server.ServerConfiguration.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UAOOI.ProcessObserver.Configuration;

namespace CAS.UA.Server.ServerConfiguration.CommServer
{
  internal partial class SelectionTreeForCommServer : UserControl, IEnableOK
  {
    #region constructor

    public SelectionTreeForCommServer()
    {
      InitializeComponent();
    }

    #endregion constructor

    #region public

    public ComunicationNet Configuration
    {
      set
      {
        ImageList il = new ImageList();
        il.Images.Add(Resource.tag_element_48_full);
        il.Images.Add(Resource.Folder_Open);
        m_TreeView.ImageList = il;
        string[] completeTagPath;
        List<string> listOfProperPathElements;
        string[] splittedTagPath;
        char[] charsplit = Resource.SplitSignForCommServerTag.ToCharArray();
        for (int idx = 0; idx < value.Tags.Count; idx++)
        {
          listOfProperPathElements = new List<string>();
          ComunicationNet.TagsRow tr = value.Tags[idx];
          splittedTagPath = tr.Name.Split(charsplit[0]);
          for (int px = 0; px < splittedTagPath.Length; px++)
            if (!(string.IsNullOrEmpty(splittedTagPath[px])))
              listOfProperPathElements.Add(splittedTagPath[px]);
          completeTagPath = listOfProperPathElements.ToArray();
          TreeNode lastNode = null;
          TreeNode[] currentNodeArray;
          TreeNodeCollection tnc;
          string partOfTheTagPath;
          for (int levelCounter = 0; levelCounter < completeTagPath.Length; levelCounter++)
          {
            partOfTheTagPath = completeTagPath[levelCounter];
            if (levelCounter == 0)
              tnc = m_TreeView.Nodes;
            else
              tnc = lastNode.Nodes;
            currentNodeArray = tnc.Find(partOfTheTagPath, false);
            if (currentNodeArray == null || currentNodeArray.Length == 0 || currentNodeArray[0] == null)
            {
              lastNode = new TreeNode(partOfTheTagPath)
              {
                Name = partOfTheTagPath
              };
              if (levelCounter == completeTagPath.Length - 1)
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
              tnc.Add(lastNode);
            }
            else
              lastNode = currentNodeArray[0];
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
        if (item == null || item.Tag == null)
          return null;
        return item.Tag.ToString();
      }
    }

    #endregion public

    #region IEnableOK Members

    public event EventHandler<OKButtonEventArgs> OnStateChanged;

    #endregion IEnableOK Members

    #region private

    private void m_TreeViewForCommServer_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (e.Node.Tag != null)
      {
        if (OnStateChanged != null)
          OnStateChanged(sender, new OKButtonEventArgs(true));
      }
      else
      {
        if (OnStateChanged != null)
          OnStateChanged(sender, new OKButtonEventArgs(false));
      }
    }

    #endregion private
  }
}