//<summary>
//  Title   : Form allowing to modify properties of new created object. for Server Configuration
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    MPOstol - 18-12-2006: created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UA.Server.ServerConfiguration.Properties;

namespace CAS.UA.Server.ServerConfiguration.Controls
{
  /// <summary>
  /// Form allowing to modify properties of new created object. for Server Configuration
  /// </summary>
  public partial class OKCnacelForm: Form
  {
    #region public
    /// <summary>
    /// Default creator of the object
    /// </summary>
    internal OKCnacelForm()
    {
      InitializeComponent();
    }
    /// <summary>
    /// constructor with new title
    /// </summary>
    /// <param name="formName">new title for the form</param>
    public OKCnacelForm( string formName )
    {
      InitializeComponent();
      this.Text = formName;
    }
    /// <summary>
    /// Sets the reference of the object to be modified.
    /// </summary>
    public UserControl SelectedObject
    {
      set
      {
        this.cm_toolStripContainer.SuspendLayout();
        this.SuspendLayout();
        this.Size = value.Size;
        this.cm_toolStripContainer.ContentPanel.Controls.Clear();
        this.cm_toolStripContainer.ContentPanel.Controls.Add( value );
        value.Dock = DockStyle.Fill;
        value.Location = new Point( 0, 0 );
        this.cm_toolStripContainer.ResumeLayout( false );
        this.ResumeLayout( false );
        IEnableOK uc = value as IEnableOK;
        if ( uc != null )
          uc.OnStateChanged += new EventHandler<OKButtonEventArgs>( value_OnStateChanged );
      }
    }

    void value_OnStateChanged( object sender, OKButtonEventArgs e )
    {
      cm_TSButtonZaakceptuj.Enabled = e.OKButtonState;
    }
    #endregion

    #region private

    #region Private events handlers
    private void cm_TSButtonAccept_Click( object sender, EventArgs e )
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
    private void cm_TSButtonCancel_Click( object sender, EventArgs e )
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
    #endregion

    private void OKCnacelForm_HelpButtonClicked( object sender, System.ComponentModel.CancelEventArgs e )
    {
      System.Diagnostics.Process.Start( Resources.Help_MainPage );
      //TODO [UAD-1577] Invoke help content form DataPorter Plug-in 

    }
    #endregion
  }
}
