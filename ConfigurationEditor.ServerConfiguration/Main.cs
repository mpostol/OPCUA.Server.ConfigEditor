//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.Properties;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using UAOOI.Configuration.Core;
using UAOOI.Windows.Forms;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// The main component of this plug-in (it contains the main interface that is exposed by this plug-in)
  /// </summary>
  public partial class Main : Component, IConfiguration
  {

    #region creators
    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class.
    /// </summary>
    public Main()
    {
      CommonInitialization();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Main"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public Main(IContainer container) : this()
    {
      container.Add(this);
    }
    //static Main()
    //{
    //  EntryPoint = null;
    //}
    private void CommonInitialization()
    {
      InitializeComponent();
      Disposed += new EventHandler(Main_Disposed);
      EntryPoint = this;
    }
    #endregion

    #region public static
    /// <summary>
    /// Gets or sets the entry point to the dependent components.
    /// </summary>
    /// <value>The entry point this instance.</value>
    internal static Main EntryPoint { get; private set; }
    #endregion

    #region Browsable properties
    /// <summary>
    /// Gets or sets the current configuration.
    /// </summary>
    /// <value>The server configuration.</value>
    #region Attributes
    [
    DisplayName("Configuration"),
    Category("Configuration"),
    Description("It provides detailed information on the configuration file."),
    TypeConverter(typeof(ExpandableObjectConverter))
    ]
    #endregion
    public CASConfiguration Configuration
    {
      get { return p_Configuration; }
      private set
      {
        if (p_Configuration == value)
          return;
        if (value == null)
          p_Configuration = CASConfiguration.CreateDefault();
        else
          p_Configuration = value;
        p_Configuration.OnChenged += new EventHandler(p_Configuration_OnChenged);
        RaiseOnChangeEvent(true);
      }
    }
    #endregion

    #region internal
    internal CommServer.CommServerMain CommServerEntryPoint { get { return m_CommServerMain; } }
    internal OPCDAClient.OPCDAClientMain OPCDAClienteEntryPoint { get { return m_DataPorterAccess; } }
    #endregion

    #region IConfiguration Members
    /// <summary>
    /// Creates the default configuration.
    /// </summary>
    public void CreateDefaultConfiguration()
    {
      Configuration = CASConfiguration.CreateDefault();
      RaiseOnChangeEvent(true);
    }
    /// <summary>
    /// Reads the configuration.
    /// </summary>
    /// <param name="configurationFile">The configuration file.</param>
    public void ReadConfiguration(FileInfo configurationFile)
    {
      Configuration = CASConfiguration.Load(configurationFile);
      m_ConfigurationFile = configurationFile;
      RaiseOnChangeEvent(true);
    }
    /// <summary>
    /// Saves the configuration file to a specified location.
    /// </summary>
    /// <param name="solutionFilePath">The solution file path.</param>
    /// <param name="configurationFile">The configuration file.</param>
    /// <remarks>
    /// <paramref name="solutionFilePath"/> is to be used to create relative file path to configuration files used by the plug-in (if required).
    /// Note that some plugins (e.g. this plugin uses relative paths to <paramref name="configurationFile"/> location.
    /// </remarks>
    public void SaveConfiguration(string solutionFilePath, FileInfo configurationFile)
    {
      Configuration.Save(configurationFile);
      if (m_ConfigurationFile != null && configurationFile.FullName.CompareTo(m_ConfigurationFile.FullName) == 0)
        return;
      m_ConfigurationFile = configurationFile;
      RaiseOnChangeEvent(true);
    }
    /// <summary>
    /// Gets the configuration editor - user interface to edit the plug-in configuration file.
    /// </summary>
    public void EditConfiguration()
    {
      using (AddObject<object> _dialog = new AddObject<object>(Configuration))
      {
        if (_dialog.ShowDialog() == DialogResult.OK)
          RaiseOnChangeEvent(false);
      }
    }
    /// <summary>
    /// Gets the instance configuration.
    /// </summary>
    /// <param name="nodeUniqueIdentifier">The node unique identifier.</param>
    /// <returns>
    /// 	<see cref="IInstanceConfiguration"/> instance provides configuration utilities.
    /// </returns>
    public IInstanceConfiguration GetInstanceConfiguration(INodeDescriptor nodeUniqueIdentifier)
    {
      if (Configuration == null)
        return null;
      return Configuration.GetInstanceConfiguration(nodeUniqueIdentifier);
    }
    /// <summary>
    /// Occurs any time the configuration is modified.
    /// </summary>
    public event EventHandler<UAServerConfigurationEventArgs> OnModified;
    /// <summary>
    /// Gets the default name of the file.
    /// </summary>
    /// <value>The default name of the file.</value>
    public string DefaultFileName
    {
      get { return Resource.Default_ConfigurationFileName + "." + Resource.DefaultConfigurationFileNametExtension; }
    }
    /// <summary>
    /// Creates automatically the instance configurations on the best effort basis.
    /// </summary>
    /// <param name="descriptors">The descriptors of nodes.</param>
    /// <param name="skipOpeningConfigurationFile">if set to <c>true</c> skip opening configuration file.</param>
    /// <param name="cancelWasPressed">if set to <c>true</c> cancel was pressed.</param>
    public void CreateInstanceConfigurations(INodeDescriptor[] descriptors, bool skipOpeningConfigurationFile, out bool cancelWasPressed)
    {
      Configuration.GetInstanceConfiguration(descriptors, skipOpeningConfigurationFile, out cancelWasPressed);
    }
    #endregion

    #region IDisposable
    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
        components.Dispose();
      EntryPoint = null;
      base.Dispose(disposing);
    }
    #endregion

    #region private
    private FileInfo m_ConfigurationFile;
    private CASConfiguration p_Configuration;
    private void RaiseOnChangeEvent(bool configurationFileChanged)
    {
      if (OnModified != null)
        OnModified(this, new UAServerConfigurationEventArgs(configurationFileChanged));
    }
    private void p_Configuration_OnChenged(object sender, EventArgs e)
    {
      RaiseOnChangeEvent(true);
    }
    private void Main_Disposed(object sender, EventArgs e)
    {
      EntryPoint = null;
    }
    #endregion

  }
}
