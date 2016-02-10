//<summary>
//  Title   : Item Wrapper for Property Grid
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
  internal class ItemWrapperForPropertyGrid
  {
    [Description( "Name of the item" )]
    public string Name
    {
      get
      {
        return this.mItem.Name;
      }
      set
      {
        this.mItem.Name = value;
      }
    }
    [Description( "The MaxAge setting for the item" )]
    public int? MaxAge
    {
      get
      {
        if ( this.mItem.IsMaxAgeNull() )
          return null;
        return this.mItem.MaxAge;
      }
      set
      {
        if ( value != null )
          this.mItem.MaxAge = (int)value;
        else
          this.mItem.SetMaxAgeNull();
      }
    }
    [Description( "Idicates whether item is active" )]
    public bool? Active
    {
      get
      {
        if ( this.mItem.IsActiveNull() )
          return null;
        return this.mItem.Active;
      }
      set
      {
        if ( value != null )
          this.mItem.Active = (bool)value;
        else
          this.mItem.SetActiveNull();
      }
    }
    [Description( "The Deadband setting for the item" )]
    public float? Deadband
    {
      get
      {
        if ( this.mItem.IsDeadbandNull() )
          return null;
        return this.mItem.Deadband;
      }
      set
      {
        if ( value != null )
          this.mItem.Deadband = (float)value;
        else
          this.mItem.SetDeadbandNull();
      }
    }
    [Description( "Idicates whether buffering is enabled" )]
    public bool? EnableBuffering
    {
      get
      {
        if ( this.mItem.IsEnableBufferingNull() )
          return null;
        return this.mItem.EnableBuffering;
      }
      set
      {
        if ( value != null )
          this.mItem.EnableBuffering = (bool)value;
        else
          this.mItem.SetEnableBufferingNull();
      }
    }
    [Description( "Path of the item" )]
    public string ItemPath
    {
      get
      {
        if ( this.mItem.IsItemPathNull() )
          return null;
        return this.mItem.ItemPath;
      }
      set
      {
        this.mItem.ItemPath = value;
      }
    }
    [Description( "The sampling rate" )]
    public int? SamplingRate
    {
      get
      {
        if ( this.mItem.IsSamplingRateNull() )
          return null;
        return this.mItem.SamplingRate;
      }
      set
      {
        if ( value != null )
          this.mItem.SamplingRate = (int)value;
        else
          this.mItem.SetSamplingRateNull();
      }
    }
    [Description( "The requested type" )]
    public string RequestedTypeFullName
    {
      get
      {
        if ( this.mItem.IsRequestedTypeFullNameNull() )
          return null;
        return this.mItem.RequestedTypeFullName;
      }
      set
      {
        this.mItem.RequestedTypeFullName = value;
      }
    }
    internal ItemWrapperForPropertyGrid( OPCCliConfiguration.ItemsRow Item )
    {
      mItem = Item;
    }
    private OPCCliConfiguration.ItemsRow mItem;
  }
}
