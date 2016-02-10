namespace CAS.UA.Server.ServerConfiguration.OPCDAClient
{
  partial class SelectionTree
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
      this.m_PropertyGrid = new System.Windows.Forms.PropertyGrid();
      this.m_TreeView = new System.Windows.Forms.TreeView();
      this.m_SplitContainer = new System.Windows.Forms.SplitContainer();
      this.m_SplitContainer.Panel1.SuspendLayout();
      this.m_SplitContainer.Panel2.SuspendLayout();
      this.m_SplitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_PropertyGrid
      // 
      this.m_PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_PropertyGrid.Location = new System.Drawing.Point( 0, 0 );
      this.m_PropertyGrid.Name = "m_PropertyGrid";
      this.m_PropertyGrid.Size = new System.Drawing.Size( 163, 302 );
      this.m_PropertyGrid.TabIndex = 0;
      // 
      // m_TreeView
      // 
      this.m_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_TreeView.Location = new System.Drawing.Point( 0, 0 );
      this.m_TreeView.Name = "m_TreeView";
      this.m_TreeView.Size = new System.Drawing.Size( 162, 302 );
      this.m_TreeView.TabIndex = 0;
      this.m_TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.m_TreeView_AfterSelect );
      // 
      // m_SplitContainer
      // 
      this.m_SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_SplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.m_SplitContainer.Location = new System.Drawing.Point( 0, 0 );
      this.m_SplitContainer.Name = "m_SplitContainer";
      // 
      // m_SplitContainer.Panel1
      // 
      this.m_SplitContainer.Panel1.Controls.Add( this.m_TreeView );
      // 
      // m_SplitContainer.Panel2
      // 
      this.m_SplitContainer.Panel2.Controls.Add( this.m_PropertyGrid );
      this.m_SplitContainer.Size = new System.Drawing.Size( 329, 302 );
      this.m_SplitContainer.SplitterDistance = 162;
      this.m_SplitContainer.TabIndex = 0;
      // 
      // SelectionTree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add( this.m_SplitContainer );
      this.Name = "SelectionTree";
      this.Size = new System.Drawing.Size( 329, 302 );
      this.m_SplitContainer.Panel1.ResumeLayout( false );
      this.m_SplitContainer.Panel2.ResumeLayout( false );
      this.m_SplitContainer.ResumeLayout( false );
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.PropertyGrid m_PropertyGrid;
    private System.Windows.Forms.TreeView m_TreeView;
    private System.Windows.Forms.SplitContainer m_SplitContainer;

  }
}
