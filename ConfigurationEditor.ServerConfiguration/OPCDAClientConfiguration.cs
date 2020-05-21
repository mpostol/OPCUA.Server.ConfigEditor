//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.Properties;
using CAS.DataPorter.Configurator;
using CAS.Lib.CodeProtect;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Instance of this class is to be used to manage configuration of the OPC Client. OPC Client
  /// is a component configured by an independent application.
  /// </summary>
  [DataContract(Namespace = CASConfiguration.DefaultNamespace)]
  public class OPCDAClientConfiguration
  {
    #region public properties

    /// <summary>
    /// Gets or sets the name of the file containing configuration of the OPC Client.
    /// </summary>
    /// <value>The name of the configuration file.</value>
    [DisplayName("File Name")]
    [Category("OPC DA Client")]
    [Description("Name of the file containing configuration of the OPC DA Client.")]
    [EditorAttribute(typeof(ConfigurationFileNameEditor), typeof(UITypeEditor))]
    [XmlIgnore()]
    public string DisplayFileName
    {
      get
      {
        if (Main.EntryPoint.OPCDAClienteEntryPoint.Opened)
          return Main.EntryPoint.OPCDAClienteEntryPoint.DefaultFileName;
        if (!string.IsNullOrEmpty(m_XmlFileName))
          return m_XmlFileName;
        else
          return "File name not set";
      }
      set => m_XmlFileName = value;
    }

    /// <summary>
    /// Gets the the configuration file status.
    /// </summary>
    /// <value>The file status.</value>
    [DisplayName("File status")]
    [Category("OPC Client")]
    [Description("Configuration file status.")]
    public string FileStatus => Main.EntryPoint.OPCDAClienteEntryPoint.FileStatus;

    #endregion public properties

    #region XmlSerializer properties

    /// <summary>
    /// Gets or sets the name of the OPC Client configuration file.
    /// </summary>
    /// <value>The name of the file.</value>
    [Browsable(false)]
    [XmlAttribute()]
    [DataMember(Name = "FileName")]
    public string FileName
    {
      get
      {
        if (Main.EntryPoint.OPCDAClienteEntryPoint.Opened)
          return GetRelativePath(Main.EntryPoint.OPCDAClienteEntryPoint.DefaultFileName);
        else
          return m_XmlFileName;
      }
      set
      {
        m_XmlFileName = value;
        Main.EntryPoint.OPCDAClienteEntryPoint.DefaultFileName = value;
      }
    }

    #endregion XmlSerializer properties

    #region public

    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return DisplayFileName;
    }

    internal void SetBaseDirectoryFilePath(string solutionFilePath)
    {
      m_BaseDirectoryFilePath = solutionFilePath;
    }

    #endregion public

    #region private

    private class ConfigurationFileNameEditor : FileNameEditor
    {
      public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
      {
        return base.EditValue(context, provider, value);
      }

      protected override void InitializeDialog(OpenFileDialog openFileDialog)
      {
        OpenFileDialog src = Main.EntryPoint.OPCDAClienteEntryPoint.OpenDialog;
        //TODO copy all properties from src using System.Reflection.
        openFileDialog.DefaultExt = src.DefaultExt;
        openFileDialog.Filter = src.Filter;
        openFileDialog.Title = src.Title;
        openFileDialog.CheckFileExists = true;
        openFileDialog.FileOk += new CancelEventHandler(openFileDialog_FileOk);
        openFileDialog.HelpRequest += new EventHandler(openFileDialog_HelpRequest);
      }

      private void openFileDialog_HelpRequest(object sender, EventArgs e)
      {
        System.Diagnostics.Process.Start(Resources.Help_MainPage);
        //TODO [UAD-1577] Invoke help content form DataPorter Plug-in
      }

      private void openFileDialog_FileOk(object sender, CancelEventArgs e)
      {
        OpenFileDialog parent = (OpenFileDialog)sender;
        Main.EntryPoint.OPCDAClienteEntryPoint.Open(parent.FileName, out ConfigurationManagement.AdditionalResultInfo resultinfo);
        if (resultinfo != ConfigurationManagement.AdditionalResultInfo.OK)
          MessageBox.Show(string.Format(Resources.CASConfiguration_MessageBox_configuration_file_exception, resultinfo.ToString()));
      }
    }

    private string GetRelativePath(string filename)
    {
      Debug.Assert(!string.IsNullOrEmpty(filename));
      if (string.IsNullOrEmpty(m_BaseDirectoryFilePath))
        MessageBox.Show(Resources.SolutionIsNotSaved_Info + filename, Resources.SolutionIsNotSaved_Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
      else
        filename = RelativeFilePathsCalculator.TryComputeRelativePath(m_BaseDirectoryFilePath, filename);
      return filename;
    }

    private string m_XmlFileName = null;
    private string m_BaseDirectoryFilePath = null;

    #endregion private
  }
}