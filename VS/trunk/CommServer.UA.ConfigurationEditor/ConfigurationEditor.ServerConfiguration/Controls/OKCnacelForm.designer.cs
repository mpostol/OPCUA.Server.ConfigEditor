namespace CAS.UA.Server.ServerConfiguration.Controls
{
  /// <summary>
  /// Form allowing to modify properties of new created object.
  /// </summary>
  partial class OKCnacelForm
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
    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.ToolStripButton cm_TSButtonZakoñcz;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OKCnacelForm ) );
      this.cm_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
      this.cm_ToolStrip = new System.Windows.Forms.ToolStrip();
      this.cm_TSButtonZaakceptuj = new System.Windows.Forms.ToolStripButton();
      this.m_helpProvider = new System.Windows.Forms.HelpProvider();
      cm_TSButtonZakoñcz = new System.Windows.Forms.ToolStripButton();
      this.cm_toolStripContainer.BottomToolStripPanel.SuspendLayout();
      this.cm_toolStripContainer.SuspendLayout();
      this.cm_ToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // cm_TSButtonZakoñcz
      // 
      cm_TSButtonZakoñcz.AutoSize = false;
      cm_TSButtonZakoñcz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      cm_TSButtonZakoñcz.ImageTransparentColor = System.Drawing.Color.Magenta;
      cm_TSButtonZakoñcz.Name = "cm_TSButtonZakoñcz";
      cm_TSButtonZakoñcz.Size = new System.Drawing.Size( 100, 22 );
      cm_TSButtonZakoñcz.Text = "Cancel";
      cm_TSButtonZakoñcz.Click += new System.EventHandler( this.cm_TSButtonCancel_Click );
      // 
      // cm_toolStripContainer
      // 
      // 
      // cm_toolStripContainer.BottomToolStripPanel
      // 
      this.cm_toolStripContainer.BottomToolStripPanel.Controls.Add( this.cm_ToolStrip );
      // 
      // cm_toolStripContainer.ContentPanel
      // 
      this.cm_toolStripContainer.ContentPanel.AutoScroll = true;
      this.cm_toolStripContainer.ContentPanel.Size = new System.Drawing.Size( 564, 430 );
      this.cm_toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cm_toolStripContainer.LeftToolStripPanelVisible = false;
      this.cm_toolStripContainer.Location = new System.Drawing.Point( 0, 0 );
      this.cm_toolStripContainer.Name = "cm_toolStripContainer";
      // 
      // cm_toolStripContainer.RightToolStripPanel
      // 
      this.cm_toolStripContainer.RightToolStripPanel.Enabled = false;
      this.cm_toolStripContainer.RightToolStripPanelVisible = false;
      this.cm_toolStripContainer.Size = new System.Drawing.Size( 564, 455 );
      this.cm_toolStripContainer.TabIndex = 0;
      this.cm_toolStripContainer.Text = "CreateNewObject";
      this.cm_toolStripContainer.TopToolStripPanelVisible = false;
      // 
      // cm_ToolStrip
      // 
      this.cm_ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.cm_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.cm_TSButtonZaakceptuj,
            cm_TSButtonZakoñcz} );
      this.cm_ToolStrip.Location = new System.Drawing.Point( 3, 0 );
      this.cm_ToolStrip.Name = "cm_ToolStrip";
      this.cm_ToolStrip.Size = new System.Drawing.Size( 212, 25 );
      this.cm_ToolStrip.TabIndex = 0;
      this.cm_ToolStrip.Text = "toolStrip1";
      // 
      // cm_TSButtonZaakceptuj
      // 
      this.cm_TSButtonZaakceptuj.AutoSize = false;
      this.cm_TSButtonZaakceptuj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.cm_TSButtonZaakceptuj.Enabled = false;
      this.cm_TSButtonZaakceptuj.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cm_TSButtonZaakceptuj.Name = "cm_TSButtonZaakceptuj";
      this.cm_TSButtonZaakceptuj.Size = new System.Drawing.Size( 100, 22 );
      this.cm_TSButtonZaakceptuj.Text = "OK";
      this.cm_TSButtonZaakceptuj.Click += new System.EventHandler( this.cm_TSButtonAccept_Click );
      // 
      // OKCnacelForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.ClientSize = new System.Drawing.Size( 564, 455 );
      this.Controls.Add( this.cm_toolStripContainer );
      this.HelpButton = true;
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size( 240, 300 );
      this.Name = "OKCnacelForm";
      this.m_helpProvider.SetShowHelp( this, false );
      this.ShowInTaskbar = false;
      this.Text = "Setup new object properties";
      this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler( this.OKCnacelForm_HelpButtonClicked );
      this.cm_toolStripContainer.BottomToolStripPanel.ResumeLayout( false );
      this.cm_toolStripContainer.BottomToolStripPanel.PerformLayout();
      this.cm_toolStripContainer.ResumeLayout( false );
      this.cm_toolStripContainer.PerformLayout();
      this.cm_ToolStrip.ResumeLayout( false );
      this.cm_ToolStrip.PerformLayout();
      this.ResumeLayout( false );

    }

    #endregion
    private System.Windows.Forms.ToolStrip cm_ToolStrip;
    private System.Windows.Forms.ToolStripContainer cm_toolStripContainer;
    private System.Windows.Forms.ToolStripButton cm_TSButtonZaakceptuj;
    private System.Windows.Forms.HelpProvider m_helpProvider;
  }
}