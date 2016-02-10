namespace CAS.UA.Server.ServerConfiguration
{
  partial class Main
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
      components = new System.ComponentModel.Container();
      m_CommServerMain = new CommServer.CommServerMain(components);
      m_DataPorterAccess = new OPCDAClient.OPCDAClientMain(components);
      // m_CommServerMain
      m_CommServerMain.DefaultFileName = null;
      m_CommServerMain.Opened = false;
      // m_DataPorterAccess
      m_DataPorterAccess.DefaultFileName = null;
      m_DataPorterAccess.Opened = false;
    }

    #endregion

    private CommServer.CommServerMain m_CommServerMain;
    private OPCDAClient.OPCDAClientMain m_DataPorterAccess;

  }
}
