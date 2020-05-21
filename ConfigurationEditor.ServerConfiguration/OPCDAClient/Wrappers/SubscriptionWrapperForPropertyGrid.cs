//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.DataPorter.Configurator;
using System.ComponentModel;

namespace CAS.UA.Server.ServerConfiguration.OPCDAClient.Wrappers
{
  [ReadOnly(true)]
  internal class SubscriptionWrapperForPropertyGrid
  {
    #region Public properties

    [Description("Name of the subscription")]
    public string Name
    {
      get => mSubscription.Name;
      set => mSubscription.Name = value;
    }

    [Description("The update rate for the subscription")]
    public int UpdateRate
    {
      get => mSubscription.UpdateRate;
      set => mSubscription.UpdateRate = value;
    }

    [Description("The locale setting rate for the subscription")]
    public string Locale
    {
      get
      {
        if (mSubscription.IsLocaleNull())
          return null;
        return mSubscription.Locale;
      }
      set => mSubscription.Locale = value;
    }

    [Description("The Keep Alive Rate setting rate for the subscription")]
    public int? KeepAliveRate
    {
      get
      {
        if (mSubscription.IsKeepAliveRateNull())
          return null;
        return mSubscription.KeepAliveRate;
      }
      set
      {
        if (value != null)
          mSubscription.KeepAliveRate = (int)value;
        else
          mSubscription.SetKeepAliveRateNull();
      }
    }

    [Description("The Dead-band setting rate for the subscription")]
    public float? Deadband
    {
      get
      {
        if (mSubscription.IsDeadbandNull())
          return null;
        return mSubscription.Deadband;
      }
      set
      {
        if (value != null)
          mSubscription.Deadband = (float)value;
        else
          mSubscription.SetDeadbandNull();
      }
    }

    [Description("Indicates whether subscription is enabled")]
    public bool Enabled
    {
      get => mSubscription.Enabled;
      set => mSubscription.Enabled = value;
    }

    [Description("Indicates whether subscription is active")]
    public bool Active
    {
      get => mSubscription.Active;
      set => mSubscription.Active = value;
    }

    [Description("Indicates whether subscription is read asynchronously")]
    public bool Asynchronous
    {
      get => mSubscription.Asynchronous;
      set => mSubscription.Asynchronous = value;
    }

    #endregion Public properties

    internal SubscriptionWrapperForPropertyGrid(OPCCliConfiguration.SubscriptionsRow subscription)
    {
      mSubscription = subscription;
    }

    private OPCCliConfiguration.SubscriptionsRow mSubscription;
  }
}