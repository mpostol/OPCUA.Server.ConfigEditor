//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.Properties;
using CAS.DataPorter.Configurator;
using CAS.UA.Server.ServerConfiguration.Controls;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient
{
  /// <summary>
  /// Component providing access to DataPorter configuration.
  /// </summary>
  internal partial class OPCDAClientMain : Component
  {
    #region constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="OPCDAClientMain"/> class.
    /// </summary>
    internal OPCDAClientMain()
    {
      InitializeComponent();
      Opened = false;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OPCDAClientMain"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    internal OPCDAClientMain(IContainer container)
    {
      container.Add(this);
      InitializeComponent();
      Opened = false;
    }

    #endregion constructors

    #region public

    /// <summary>
    /// Opens the specified file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <param name="additionalResult">
    /// The additional result from the enumerations <see cref="ConfigurationManagement.AdditionalResultInfo"/>.signaling if the operation succeeded, failed or was canceled by the user.
    /// </param>
    /// <returns><c>true</c> if success.</returns>
    internal bool Open(string fileName, out ConfigurationManagement.AdditionalResultInfo additionalResult)
    {
      if (string.IsNullOrEmpty(fileName))
        Opened = m_ConfigurationManagement.Open(out additionalResult);
      else
        try
        {
          m_ConfigurationManagement.ReadConfiguration(fileName);
          additionalResult = ConfigurationManagement.AdditionalResultInfo.OK;
          Opened = true;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, m_ConfigurationManagement.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
          additionalResult = ConfigurationManagement.AdditionalResultInfo.Exception;
          Opened = m_ConfigurationManagement.Open();
        }
      return Opened;
    }

    /// <summary>
    /// Opens the subscription item selection dialog that allows to pick up a tag.
    /// </summary>
    /// <returns>Selected item description or null if the selection was canceled. </returns>
    internal OPCItemIdentifier GetItemIdentifier()
    {
      if ((!Opened) && !Open(m_DefaultFileName, out ConfigurationManagement.AdditionalResultInfo resultInfo))
        return null;
      using (SelectionTree target = new SelectionTree())
      using (OKCnacelForm ui = new OKCnacelForm("Subscription item selection dialog"))
      {
        target.Configuration = m_ConfigurationManagement.Configuartion;
        ui.SelectedObject = target;
        ui.ShowDialog();
        if (ui.DialogResult != DialogResult.OK)
          return null;
        return target.Selection;
      }
    }

    internal OPCItemIdentifier GetItemIdentifier(string description, out ConfigurationManagement.AdditionalResultInfo resultInfo)
    {
      if ((!Opened) && !Open(m_DefaultFileName, out resultInfo))
        return null;
      foreach (OPCCliConfiguration.ItemsRow item in m_ConfigurationManagement.Configuartion.Items)
        if (item.Name.Contains(description))
        {
          OPCCliConfiguration.SubscriptionsRow subscription = item.SUBSCRIPTIONRow;
          OPCCliConfiguration.ServersRow server = subscription.SERVERSRow;
          resultInfo = ConfigurationManagement.AdditionalResultInfo.OK;
          return new OPCItemIdentifier() { ItemName = item.Name, SubscriptionName = subscription.Name, ServerName = server.Name };
        }
      resultInfo = ConfigurationManagement.AdditionalResultInfo.Exception;
      return null;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this configuration file is opened.
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
    /// Gets or sets the default name of the configuration file.
    /// </summary>
    /// <value>The default name of the configuration file.</value>
    internal string DefaultFileName
    {
      get
      {
        if (Opened)
          return m_ConfigurationManagement.DefaultFileName;
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
          NamedTraceLogger.Logger.TraceEvent(TraceEventType.Warning, 164, Resource.CASConfiguration_UnableToOpenConfigurationFile, fi.FullName, ex.Message);
          m_LastMessageText = ex.Message;
        }
      }
    }

    /// <summary>
    /// Gets the file status.
    /// </summary>
    /// <value>The file status.</value>
    internal string FileStatus => m_LastMessageText;

    /// <summary>
    /// Occurs when the configuration has been changed.
    /// </summary>
    internal event EventHandler<EventArgs> ConfigurationChnged;

    /// <summary>
    /// Gets the file open dialog defined for the OPC DA Client configuration.
    /// </summary>
    /// <value>The open dialog.</value>
    internal OpenFileDialog OpenDialog => m_ConfigurationManagement.OpenFileDialog;

    #endregion public

    #region private

    private string m_LastMessageText = "Not set";
    private bool m_Opened = false;
    private string m_DefaultFileName = null;

    private void m_ConfigurationManagement_ConfigurationChnged(object sender, ConfigurationManagement.ConfigurationEventArg e)
    {
      if (ConfigurationChnged == null)
        return;
      ConfigurationChnged(this, EventArgs.Empty);
    }

    #endregion private
  }
}