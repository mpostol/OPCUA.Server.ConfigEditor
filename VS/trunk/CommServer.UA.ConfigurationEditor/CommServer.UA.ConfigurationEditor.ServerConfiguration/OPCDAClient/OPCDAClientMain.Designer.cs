namespace CAS.UA.Server.ServerConfiguration.OPCDAClient
{
  partial class OPCDAClientMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.m_ConfigurationManagement = new CAS.DataPorter.Configurator.ConfigurationManagement( this.components );
      // 
      // m_ConfigurationManagement
      // 
      this.m_ConfigurationManagement.DefaultFileName = "OPCViewerSession";
      this.m_ConfigurationManagement.ConfigurationChnged += new System.EventHandler<CAS.DataPorter.Configurator.ConfigurationManagement.ConfigurationEventArg>( this.m_ConfigurationManagement_ConfigurationChnged );

    }

    #endregion

    private CAS.DataPorter.Configurator.ConfigurationManagement m_ConfigurationManagement;
  }
}
