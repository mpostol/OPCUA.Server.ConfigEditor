﻿//<summary>
//  Title   : DataPorter Source definition
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

using CAS.DataPorter.Configurator;
using CAS.UA.IServerConfiguration;
using CAS.UA.Server.ServerConfiguration.OPCDAClient;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// OPC DA client data source configuration.
  /// </summary>
  [XmlTypeAttribute( Namespace = CASConfiguration.DefaultNamespace )]
  [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
  public class OPCDAClientSourceConfiguration: SourceBase
  {
    #region creators
    /// <summary>
    /// Creates the OPCDA client source configuration.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="LastResultInfo">The last result info.</param>
    /// <param name="SkipGetItemIdentifier">if set to <c>true</c> skip calling OPCDAClienteEntryPoint.GetItemIdentifier (OPCItemIdentifier==null) </param>
    public OPCDAClientSourceConfiguration(
      INodeDescriptor item,
      out ConfigurationManagement.AdditionalResultInfo LastResultInfo,
      bool SkipGetItemIdentifier )
    {
      LastResultInfo = ConfigurationManagement.AdditionalResultInfo.OK;
      OPCItemIdentifier ret = null;
      if ( !SkipGetItemIdentifier )
        ret = Main.EntryPoint.OPCDAClienteEntryPoint.GetItemIdentifier( item.BindingDescription, out LastResultInfo );
      if ( ret == null )
      {
        Selected = false;
        LastResultInfo = ConfigurationManagement.AdditionalResultInfo.Cancel;
        return;
      }
      ItemName = ret.ItemName;
      ServerName = ret.ServerName;
      SubscriptionName = ret.SubscriptionName;
      Selected = true;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="OPCDAClientSourceConfiguration"/> class.
    /// </summary>
    public OPCDAClientSourceConfiguration() { }
    #endregion

    #region Browsable properties
    /// <summary>
    /// Gets or sets the name of the item.
    /// </summary>
    /// <value>The name of the item.</value>
    [ReadOnly( true )]
    [DataMember]
    public string ItemName { get; set; }
    /// <summary>
    /// Gets or sets the name of the server.
    /// </summary>
    /// <value>The name of the server.</value>
    [ReadOnly( true )]
    [DataMember]
    public string ServerName { get; set; }
    /// <summary>
    /// Gets or sets the name of the subscription.
    /// </summary>
    /// <value>The name of the subscription.</value>
    [ReadOnly( true )]
    [DataMember]
    public string SubscriptionName { get; set; }
    /// <summary>
    /// Gets the unique identifier of the item.
    /// </summary>
    /// <value>The unique identifier.</value>
    public string UniqueIdentifier
    {
      get 
      {
        if ( Selected )
          return String.Format( "{0}\\{1}\\{2}", ServerName, SubscriptionName, ItemName );
        else
          return "Not selected";
      }
    }
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
      return "OPC Client " + UniqueIdentifier;
    }
    internal static OPCDAClientSourceConfiguration CreateInstance()
    {
      OPCItemIdentifier ret = Main.EntryPoint.OPCDAClienteEntryPoint.GetItemIdentifier();
      if ( ret == null )
        return new OPCDAClientSourceConfiguration() { Selected = false };
      else
        return new OPCDAClientSourceConfiguration()
        {
          ItemName = ret.ItemName,
          ServerName = ret.ServerName,
          SubscriptionName = ret.SubscriptionName,
          Selected = true
        };
    }
    /// <summary>
    /// Gets the instance of this type.
    /// </summary>
    /// <returns>SourceBase.</returns>
    internal protected override SourceBase GetSourceBase()
    {
      OPCItemIdentifier ret = Main.EntryPoint.OPCDAClienteEntryPoint.GetItemIdentifier();
      if ( ret != null )
      {
        ItemName = ret.ItemName;
        ServerName = ret.ServerName;
        SubscriptionName = ret.SubscriptionName;
        Selected = true;
      }
      return this;
    }
    #endregion
  }
}
