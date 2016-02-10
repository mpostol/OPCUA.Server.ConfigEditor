namespace CAS.UA.Server.ServerConfiguration.CommServer
{
  partial class SelectionTreeForCommServer
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
      this.m_TreeView = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // m_TreeView
      // 
      this.m_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_TreeView.Location = new System.Drawing.Point( 0, 0 );
      this.m_TreeView.Name = "m_TreeViewForCommServer";
      this.m_TreeView.Size = new System.Drawing.Size( 329, 302 );
      this.m_TreeView.TabIndex = 2;
      this.m_TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.m_TreeViewForCommServer_AfterSelect );
      // 
      // SelectionTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add( this.m_TreeView );
      this.Name = "SelectionTree";
      this.Size = new System.Drawing.Size( 329, 302 );
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.TreeView m_TreeView;


  }
}
