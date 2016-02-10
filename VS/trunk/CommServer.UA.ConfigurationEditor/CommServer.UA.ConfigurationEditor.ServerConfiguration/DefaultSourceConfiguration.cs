//<summary>
//  Title   : Empty source configuration 
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
using System.Collections.Generic;
using System.Text;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Empty source configuration 
  /// </summary>
  public class DefaultSourceConfiguration: SourceBase
  {
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>
    /// A new object that is a copy of this instance.
    /// </returns>
    public override object Clone()
    {
      return this.MemberwiseClone();
    }
    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return "(Not selected - get from list)";
    }
    /// <summary>
    /// Gets the instance of this type.
    /// </summary>
    /// <returns>Returns this instance.</returns>
    internal protected override SourceBase GetSourceBase()
    {
      return this;
    }
  }
}
