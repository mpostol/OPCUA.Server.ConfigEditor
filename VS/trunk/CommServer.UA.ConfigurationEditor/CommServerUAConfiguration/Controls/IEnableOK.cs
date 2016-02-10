//<summary>
//  Title   : OKButtonEventArgs
//  System  : Microsoft VisualStudio 2013 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2014, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>
      
using System;

namespace CAS.UA.Server.ServerConfiguration.Controls
{
  /// <summary>
  /// Class OKButtonEventArgs - to provide feedback for OK button state (enabled/disabled) used by the interface <see cref="IEnableOK"/>.
  /// </summary>
  public class OKButtonEventArgs: EventArgs
  {
    /// <summary>
    /// Gets a value indicating whether ok button is to be enabled.
    /// </summary>
    /// <value><c>true</c> if ok button should be enabled; otherwise, <c>false</c>.</value>
    public bool OKButtonState { get; private set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="OKButtonEventArgs"/> class.
    /// </summary>
    /// <param name="state">if set to <c>true</c> the button should be enabled.</param>
    public OKButtonEventArgs( bool state )
    {
      OKButtonState = state;
    }
  }
  /// <summary>
  /// Interface IEnableOK - used to control an accepting button state.
  /// </summary>
  public interface IEnableOK
  {
    /// <summary>
    /// Occurs when state of the button must be changed.
    /// </summary>
    event EventHandler<OKButtonEventArgs> OnStateChanged;
  }
}
