//<summary>
//  Title   : Subscription Wrapper for Property Grid
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20090608: mzbrzezny - created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System.ComponentModel;
using CAS.DataPorter.Configurator;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient.Wrappers
{
  [ReadOnly( true )]
  internal class SubscriptionWrapperForPropertyGrid
  {
    #region Public properties
    [Description( "Name of the subscription" )]
    public string Name
    {
      get
      {
        return this.mSubscription.Name;
      }
      set
      {
        this.mSubscription.Name = value;
      }
    }
    [Description( "The update rate for the subscription" )]
    public int UpdateRate
    {
      get
      {
        return this.mSubscription.UpdateRate;
      }
      set
      {
        this.mSubscription.UpdateRate = value;
      }
    }
    [Description( "The locale setting rate for the subscription" )]
    public string Locale
    {
      get
      {
        if ( this.mSubscription.IsLocaleNull() )
          return null;
        return this.mSubscription.Locale;
      }
      set
      {
        this.mSubscription.Locale = value;
      }
    }
    [Description( "The Keep Alive Rate setting rate for the subscription" )]
    public int? KeepAliveRate
    {
      get
      {
        if ( this.mSubscription.IsKeepAliveRateNull() )
          return null;
        return this.mSubscription.KeepAliveRate;
      }
      set
      {
        if ( value != null )
          this.mSubscription.KeepAliveRate = (int)value;
        else
          this.mSubscription.SetKeepAliveRateNull();
      }
    }
    [Description( "The Deadband setting rate for the subscription" )]
    public float? Deadband
    {
      get
      {
        if ( this.mSubscription.IsDeadbandNull() )
          return null;
        return this.mSubscription.Deadband;
      }
      set
      {
        if ( value != null )
          this.mSubscription.Deadband = (float)value;
        else
          this.mSubscription.SetDeadbandNull();
      }
    }
    [Description( "Idicates whether subscription is enabled" )]
    public bool Enabled
    {
      get
      {
        return this.mSubscription.Enabled;
      }
      set
      {
        this.mSubscription.Enabled = value;
      }
    }
    [Description( "Idicates whether subscription is active" )]
    public bool Active
    {
      get
      {
        return this.mSubscription.Active;
      }
      set
      {
        this.mSubscription.Active = value;
      }
    }
    [Description( "Idicates whether subscription is read asynchronously" )]
    public bool Asynchronous
    {
      get
      {
        return this.mSubscription.Asynchronous;
      }
      set
      {
        this.mSubscription.Asynchronous = value;
      }
    } 
    #endregion
    internal SubscriptionWrapperForPropertyGrid( OPCCliConfiguration.SubscriptionsRow subscription )
    {
      this.mSubscription = subscription;
    }
    private OPCCliConfiguration.SubscriptionsRow mSubscription;
  }
}
