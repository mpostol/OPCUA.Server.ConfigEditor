//<summary>
//  Title   : Base class for all sources
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Base class for all sources
  /// </summary>
  [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
  public abstract class SourceBase: ICloneable
  {
    #region public
    /// <summary>
    /// Gets the instance of this type.
    /// </summary>
    /// <returns></returns>
    internal protected abstract SourceBase GetSourceBase();
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="SourceBase"/> is selected.
    /// </summary>
    /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
    [Browsable( false )]
    [DataMember]
    public bool Selected { get; set; }
    #endregion

    #region ICloneable Members
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public abstract object Clone();
    #endregion
  }
}
