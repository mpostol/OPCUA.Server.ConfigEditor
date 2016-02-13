//<summary>
//  Title   : OPC Item identifier
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

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient
{
  /// <summary>
  /// OPC Item Identifier
  /// </summary>
  public class OPCItemIdentifier
  {
    /// <summary>
    /// Gets or sets the name of the item.
    /// </summary>
    /// <value>The name of the item.</value>
    public string ItemName { get; set; }
    /// <summary>
    /// Gets or sets the name of the server.
    /// </summary>
    /// <value>The name of the server.</value>
    public string ServerName { get; set; }
    /// <summary>
    /// Gets or sets the name of the subscription.
    /// </summary>
    /// <value>The name of the subscription.</value>
    public string SubscriptionName { get; set; }
    /// <summary>
    /// Gets the unique identifier.
    /// </summary>
    /// <value>The unique identifier.</value>
    public string UniqueIdentifier
    {
      get { return String.Format( "{0}\\{1}\\{2}", ServerName, SubscriptionName, ItemName ); }
    }
  }
}

