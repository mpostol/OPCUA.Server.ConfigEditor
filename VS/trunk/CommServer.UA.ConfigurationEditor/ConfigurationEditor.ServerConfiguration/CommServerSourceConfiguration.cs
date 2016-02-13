//<summary>
//  Title   : CommServer Source definition
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

using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// CommServer(TM) Engine data source configuration
  /// </summary>
  [XmlTypeAttribute( Namespace = CASConfiguration.DefaultNamespace )]
  [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
  public class CommServerSourceConfiguration: SourceBase
  {
    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="CommServerSourceConfiguration"/> class.
    /// </summary>
    public CommServerSourceConfiguration() { }
    #endregion


    #region Browseable and serializable
    /// <summary>
    /// Gets or sets the name of the item.
    /// </summary>
    /// <value>The name of the item.</value>
    [ReadOnly( true )]
    [DataMember]
    public string ItemName { get; set; }

    #endregion

    #region public
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
      return "CommServer Engine Data Source: " +ItemName;
    }
    #region static factory
    internal static CommServerSourceConfiguration CreateInstance()
    {
      string ret = Main.EntryPoint.CommServerEntryPoint.GetItemIdentifier();
      return new CommServerSourceConfiguration()
      {
        ItemName = ret,
        Selected = true
      };
    }
    #endregion
    /// <summary>
    /// Gets the instance of this type.
    /// </summary>
    /// <returns>Instance of this type</returns>
    internal protected override SourceBase GetSourceBase()
    {
      string ret = Main.EntryPoint.CommServerEntryPoint.GetItemIdentifier();
      if ( ret != null )
      {
        ItemName = ret;
        Selected = true;
      }
      return this;
    }
    #endregion

  }
}
