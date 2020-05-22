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
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using UAOOI.ProcessObserver.Configuration;

namespace CAS.UA.Server.ServerConfiguration.CommServer
{
  internal class CommServerConfigurationMain : Component
  {
    internal CommServerConfigurationMain(IContainer components)
    {
      components.Add(this);
      Configuartion = new ComunicationNet();
      OpenFileDialog = new OpenFileDialog()
      {
        InitialDirectory = InstallContextNames.ApplicationDataPath,
        DefaultExt = "xml",
        FileName = "CommServerConfiguration",
        Filter = "CommServer Configuration File (*.xml)|*.xml|All files(*.*)|*.*",
        SupportMultiDottedExtensions = true,
        Title = "Open CommServer Configuration File"
      };
      ((ISupportInitialize)(Configuartion)).BeginInit();
      Configuartion.DataSetName = "ComunicationNet";
      Configuartion.Locale = new CultureInfo("en-US");
      Configuartion.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      ((ISupportInitialize)(Configuartion)).EndInit();
    }

    internal ComunicationNet Configuartion { get; private set; }
    internal string DefaultFileName => OpenFileDialog.FileName;
    internal OpenFileDialog OpenFileDialog { get; private set; }

    internal bool Open()
    {
      if (OpenFileDialog.ShowDialog() != DialogResult.OK)
        return false;
      Cursor myPreviousCursor = Cursor.Current;
      try
      {
        Cursor.Current = Cursors.WaitCursor;
        Application.UseWaitCursor = true;
        ReadConfiguration(OpenFileDialog.FileName);
        return true;
      }
      catch (Exception ex)
      {
        OpenFileDialog.FileName = "";
        MessageBox.Show(ex.Message, Resource.SessionFileOpenError, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      finally
      {
        Application.UseWaitCursor = false;
        Cursor.Current = myPreviousCursor;
      }
    }

    internal void ReadConfiguration(string fileName)
    {
      try
      {
        FileInfo info = new FileInfo(fileName);
        if (!info.Exists)
          throw new FileNotFoundException(fileName);
        Configuartion.Clear();
        Configuartion.EnforceConstraints = false;
        Configuartion.ReadXml(fileName, System.Data.XmlReadMode.IgnoreSchema);
      }
      finally
      {
        Configuartion.EnforceConstraints = true;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (OpenFileDialog != null)
      {
        OpenFileDialog.Dispose();
        OpenFileDialog = null;
      }
      if (Configuartion != null)
      {
        Configuartion.Dispose();
        Configuartion = null;
      }
      base.Dispose(disposing);
    }
  }
}