//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.Properties;
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
  /// Instance of this class is to be used to manage configuration of the CommServer communication engine. CommServer
  /// communication engine is a component configured by an independent application.
  /// </summary>
  [DataContract(Namespace = CASConfiguration.DefaultNamespace)]
  public class CommServerConfiguration
  {
    #region public properties

    /// <summary>
    /// Gets or sets the name of the file containing configuration of the OPC Client.
    /// </summary>
    /// <value>The name of the configuration file.</value>
    [DisplayName("File Name")]
    [Category("CommServer")]
    [Description("Name of the file containing configuration of the CommServer communication engine.")]
    [EditorAttribute(typeof(ConfigurationFileNameEditor), typeof(UITypeEditor))]
    [XmlIgnore()]
    public string DisplayFileName
    {
      get
      {
        if (Main.EntryPoint.CommServerEntryPoint.Opened)
          return Main.EntryPoint.CommServerEntryPoint.DefaultFileName;
        if (!string.IsNullOrEmpty(m_XmlFileName))
          return m_XmlFileName;
        else
          return "File name not set";
      }
      set => m_XmlFileName = value;
    }

    /// <summary>
    /// Gets the configuration file status.
    /// </summary>
    /// <value>The file status.</value>
    [DisplayName("File status")]
    [Category("CommServer")]
    [Description("Configuration file status.")]
    public string FileStatus => Main.EntryPoint.CommServerEntryPoint.FileStatus;

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
        if (Main.EntryPoint.CommServerEntryPoint.Opened)
          return GetRelativePath(Main.EntryPoint.CommServerEntryPoint.DefaultFileName);
        else
          return m_XmlFileName;
      }
      set
      {
        m_XmlFileName = value;
        Main.EntryPoint.CommServerEntryPoint.DefaultFileName = value;
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

    internal void SetBaseDirecotryFilePath(string solutionFilePath)
    {
      m_BaseDirecoryFilePath = solutionFilePath;
    }

    #endregion public

    #region private

    /// <summary>
    /// Configuration File Name Editor
    /// </summary>
    private class ConfigurationFileNameEditor : FileNameEditor
    {
      public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
      {
        return base.EditValue(context, provider, value);
      }

      protected override void InitializeDialog(OpenFileDialog openFileDialog)
      {
        OpenFileDialog src = Main.EntryPoint.CommServerEntryPoint.OpenDialog;
        foreach (System.Reflection.PropertyInfo property in (typeof(OpenFileDialog).GetProperties()))
        {
          System.Reflection.MethodInfo getMethod = property.GetGetMethod();
          System.Reflection.MethodInfo setMethod = property.GetSetMethod();
          object val = getMethod.Invoke(src, null);
          object[] param = new object[] { val };
          if (setMethod != null)
            setMethod.Invoke(openFileDialog, param);
        }
        openFileDialog.FileOk += new CancelEventHandler(openFileDialog_FileOk);
        openFileDialog.HelpRequest += new EventHandler(openFileDialog_HelpRequest);
      }

      private void openFileDialog_HelpRequest(object sender, EventArgs e)
      {
        System.Diagnostics.Process.Start(Resource.Help_MainPage);
        //TODO [UAD-1577] Invoke help content form CommServer Plug-in
      }

      private void openFileDialog_FileOk(object sender, CancelEventArgs e)
      {
        OpenFileDialog parent = (OpenFileDialog)sender;
        Main.EntryPoint.CommServerEntryPoint.Open(parent.FileName);
      }
    }

    private string GetRelativePath(string filename)
    {
      Debug.Assert(!string.IsNullOrEmpty(filename));
      if (string.IsNullOrEmpty(m_BaseDirecoryFilePath))
        MessageBox.Show(Resource.SolutionIsNotSaved_Info + filename, Resource.SolutionIsNotSaved_Header, MessageBoxButtons.OK, MessageBoxIcon.Information);
      else
        filename = RelativeFilePathsCalculator.TryComputeRelativePath(m_BaseDirecoryFilePath, filename);
      return filename;
    }

    private string m_XmlFileName = null;
    private string m_BaseDirecoryFilePath = null;

    #endregion private
  }
}