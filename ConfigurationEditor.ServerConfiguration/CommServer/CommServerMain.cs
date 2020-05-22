//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.CommServer;
using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.Properties;
using CAS.UA.Server.ServerConfiguration.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CAS.UA.Server.ServerConfiguration.CommServer
{
  /// <summary>
  /// CommServer configuration access functions.
  /// </summary>
  internal partial class CommServerMain : Component
  {
    #region constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="CommServerMain"/> class.
    /// </summary>
    internal CommServerMain()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CommServerMain"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    internal CommServerMain(IContainer container)
    {
      container.Add(this);
      InitializeComponent();
    }

    #endregion constructor

    #region public

    /// <summary>
    /// Opens the configuration from the specified file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <returns><c>true</c> if success.</returns>
    /// <exception cref="FileNotFoundException">The exception that is thrown when an attempt to access a file
    /// that does not exist or read operation fails.
    /// </exception>
    /// <exception cref="System.Security.SecurityException">System.Security.Permissions.FileIOPermission is not
    /// set to System.Security.Permissions.FileIOPermissionAccess.Read.</exception>
    /// <exception cref="System.Data.ConstraintException">One or more constraints cannot be enforced.</exception>
    internal bool Open(string fileName)
    {
      if (string.IsNullOrEmpty(fileName))
        Opened = m_CcommServerConfiguration.Open();
      else
        try
        {
          m_CcommServerConfiguration.ReadConfiguration(fileName);
          Opened = true;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, m_CcommServerConfiguration.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
          NamedTraceLogger.Logger.TraceEvent(TraceEventType.Warning, 156, string.Format("{0} : {1}", m_CcommServerConfiguration.ToString(), ex.Message));
          Opened = m_CcommServerConfiguration.Open();
        }
      return Opened;
    }

    /// <summary>
    /// Opens the subscription item selection dialog that allows to pick up a tag.
    /// </summary>
    /// <returns>Selected item description or null if the selection was canceled. </returns>
    internal string GetItemIdentifier()
    {
      if ((!Opened) && !Open(m_DefaultFileName))
        return string.Empty;
      using (SelectionTreeForCommServer target = new SelectionTreeForCommServer())
      using (OKCnacelForm ui = new OKCnacelForm("CommServer tag selection dialog"))
      {
        target.Configuration = m_CcommServerConfiguration.Configuartion;
        TreeView tv = target.Controls[0] as TreeView;
        if ((tv == null) || (tv.Nodes.Count == 0))
        {
          MessageBox.Show(Resource.NoTagsInTheCommServerConfiguration);
          return null;
        }
        ui.SelectedObject = target;
        ui.ShowDialog();
        if (ui.DialogResult != DialogResult.OK)
          return null;
        return target.Selection;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether the configuration file has been opened.
    /// </summary>
    /// <value><c>true</c> if opened; otherwise, <c>false</c>.</value>
    internal bool Opened
    {
      get => m_Opened;
      set
      {
        m_Opened = value;
        switch (value)
        {
          case true:
            m_LastMessageText = "Opened";
            break;

          case false:
            m_LastMessageText = "Closed";
            break;
        }
      }
    }

    /// <summary>
    /// Gets or sets the default name of the file.
    /// </summary>
    /// <value>The default name of the file.</value>
    internal string DefaultFileName
    {
      get
      {
        if (Opened)
          return m_CcommServerConfiguration.DefaultFileName;
        else
          return m_DefaultFileName;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
          return;
        FileInfo fi = CASConfiguration.PreparePathBasedOnBaseDirectory(value);
        if (fi == null)
          return;
        try
        {
          using (FileStream fs = fi.OpenRead()) { }
          m_DefaultFileName = fi.FullName;
          m_LastMessageText = "File OK";
        }
        catch (Exception ex)
        {
          NamedTraceLogger.Logger.TraceEvent(TraceEventType.Warning, 156, Resource.CASConfiguration_UnableToOpenConfigurationFile, fi.FullName, ex.Message);
          m_LastMessageText = ex.Message;
        }
      }
    }

    /// <summary>
    /// Gets the file status as string to provide it to the user.
    /// </summary>
    /// <value>The file status.</value>
    internal string FileStatus => m_LastMessageText;

    /// <summary>
    /// Occurs after the configuration is changed.
    /// </summary>
    private event EventHandler<EventArgs> ConfigurationChnged;

    /// <summary>
    /// Gets the open dialog.
    /// </summary>
    /// <value>The open dialog.</value>
    internal OpenFileDialog OpenDialog => m_CcommServerConfiguration.OpenFileDialog;

    #endregion public

    #region private

    private string m_LastMessageText = "Not set";
    private bool m_Opened = false;
    private string m_DefaultFileName = null;

    private void OnConfigurationChnged(object sender, ConfigurationEventArg e)
    {
      if (ConfigurationChnged == null)
        return;
      ConfigurationChnged(this, EventArgs.Empty);
    }

    #endregion private
  }
}