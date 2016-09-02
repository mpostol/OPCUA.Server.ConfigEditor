//<summary>
//  Title   : NamedTraceLogger
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

using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.Properties;
using System;
using System.Diagnostics;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Class NamedTraceLogger is implemented as <see cref="TraceSource"/> with the name defined in the setting by the entry Default.TraceSourceName.
  /// </summary>
  public class NamedTraceLogger : TraceSource, IDisposable
  {

    #region creator
    /// <summary>
    /// Gets the logger service - it is implemented as singleton and must by disposed before closing the application.
    /// </summary>
    /// <value>The logger.</value>
    public static NamedTraceLogger Logger
    {
      get { return m_NamedTraceLogger; }
    }
    #endregion

    #region private
    private static NamedTraceLogger m_NamedTraceLogger = new NamedTraceLogger();
    private NamedTraceLogger()
      : base(Settings.Default.TraceSourceName)
    {}
    #endregion

    #region IDisposable
    /// <summary>
    /// Implement IDisposable. Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// Do not make this method virtual. A derived class should not be able to override this method. 
    /// </summary>
    public void Dispose()
    {
      Dispose(true);
      // This object will be cleaned up by the Dispose method. 
      // Therefore, you should call GC.SupressFinalize to 
      // take this object off the finalization queue 
      // and prevent finalization code for this object 
      // from executing a second time.
      GC.SuppressFinalize(this);
    }
    /// <summary>
    /// Releases unmanaged and - optionally - managed resources. Dispose(bool disposing) executes in two distinct scenarios. 
    /// If disposing equals true, the method has been called directly or indirectly by a user's code. Managed and unmanaged resources 
    /// can be disposed. If disposing equals false, the method has been called by the runtime from inside the finalizer and you should not reference 
    /// other objects. Only unmanaged resources can be disposed. 
    /// </summary>
    /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
      // Check to see if Dispose has already been called. 
      if (!this.disposed)
      {
        // If disposing equals true, dispose all managed and unmanaged resources. 
        this.Flush();
        this.Close();
        // Note disposing has been done.
        disposed = true;
      }
    }
    // Track whether Dispose has been called. 
    private bool disposed = false;
    // Use C# destructor syntax for finalization code. 
    // This destructor will run only if the Dispose method 
    // does not get called. 
    // It gives your base class the opportunity to finalize. 
    // Do not provide destructors in types derived from this class.
    /// <summary>
    /// Finalizes an instance of the <see cref="NamedTraceLogger"/> class. Use C# destructor syntax for finalization code. This destructor will run only if the Dispose method 
    /// does not get called. It gives your base class the opportunity to finalize. Do not provide destructors in types derived from this class.
    /// </summary>
    ~NamedTraceLogger()
    {
      // Do not re-create Dispose clean-up code here. Calling Dispose(false) is optimal in terms of readability and maintainability.
      Dispose(false);
    }
    #endregion

  }
}
