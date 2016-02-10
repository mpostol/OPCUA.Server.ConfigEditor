//<summary>
//  Title   : Provides configuration utulities for the instance nodes.
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

using CAS.Lib.ControlLibrary;
using CAS.UA.IServerConfiguration;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Provides configuration utilities for the instance nodes.
  /// </summary>
  [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
  [KnownType( typeof( SourceBase ) )]
  [KnownType( typeof( OPCDAClientSourceConfiguration ) )]
  [KnownType( typeof( CommServerSourceConfiguration ) )]
  [KnownType( typeof( SimulatorSourceConfiguration ) )]
  public class InstanceConfiguration: IInstanceConfiguration
  {
    #region IInstanceConfiguration Members
    /// <summary>
    /// Edits this instance.
    /// </summary>
    public void Edit()
    {
      InstanceConfiguration copy;
      copy = (InstanceConfiguration)this.Clone();
      using ( AddObject<InstanceConfiguration> form = new AddObject<InstanceConfiguration>( copy ) )
        if ( form.ShowDialog() == DialogResult.OK )
          DataSources = form.Object.DataSources;
    }
    /// <summary>
    /// Create new empty data bindings configuration for this instance node to store proprietary information of the UA server.
    /// </summary>
    public void ClearConfiguration()
    {
      DataSources = null;
    }
    #endregion

    #region public properties
    /// <summary>
    /// Gets or sets the <see cref="NodeDescriptorWrapper"/> object providing the selected node unique identifier.
    /// </summary>
    /// <value>Selected node identifier that is to be used by a process data binding breaker at run time to couple 
    /// the instantiated object with the underlying process signal value.</value>
    [DisplayName( "Node" )]
    [Description( "Selected node identifier that is to be used by a process data binding manager at run time to couple the instantiated object with the underlying process signal value. " )]
    [Category( "Model" )]
    [ReadOnly( true )]
    [TypeConverterAttribute( typeof( ExpandableObjectConverter ) )]
    [XmlElement( IsNullable = false )]
    [DataMember( IsRequired = true, Order = 1 )]
    public NodeDescriptorWrapper NodeDescriptor { get; set; }
    /// <summary>
    /// Gets or sets the data sources binded to this instnce.
    /// </summary>
    /// <value>The array of data sources.</value>
    [DisplayName( "(Data Sources)" )]
    [Description( "Redundant data sources collection - use the provided row editor to add, remove or modify available data sources." )]
    [Category( "Redundant data sources" )]
    [TypeConverterAttribute( typeof( CollectionConverter ) )]
    //TODO [TypeConverterAttribute( typeof( ExpandableObjectConverter ) )]
    [DataMember( Order = 2 )]
    public DataSourceConfiguration[] DataSources
    {
      get
      {
        return m_DataSources;
      }
      set
      {
        m_DataSources = value;
      }
    }
    #endregion

    #region object overide
    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return "Instance configuration editor provided by the " + System.Reflection.Assembly.GetExecutingAssembly().FullName;
    }
    #endregion

    #region creators
    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceConfiguration"/> class.
    /// </summary>
    public InstanceConfiguration() { }
    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceConfiguration"/> class.
    /// </summary>
    /// <param name="nodeUniqueIdentifier">The node unique identifier.</param>
    internal InstanceConfiguration( INodeDescriptor nodeUniqueIdentifier )
    {
      NodeDescriptor = new NodeDescriptorWrapper( nodeUniqueIdentifier );
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceConfiguration"/> class .
    /// </summary>
    /// <param name="dataSources">The data sources.</param>
    /// <param name="ns">The namespace.</param>
    /// <param name="name">The name of the item.</param>
    public InstanceConfiguration( DataSourceConfiguration[] dataSources, string ns, string name )
    {
      m_DataSources = dataSources;
      NodeDescriptor = new NodeDescriptorWrapper(ns, name);
    }
    #endregion

    #region private
    private InstanceConfiguration Clone()
    {
      InstanceConfiguration ret = new InstanceConfiguration()
      {
        DataSources = DataSources == null ? null : (DataSourceConfiguration[])this.DataSources.Clone(),
        NodeDescriptor = NodeDescriptor
      };
      if ( DataSources != null )
        for ( int i = 0; i < DataSources.Length; i++ )
          DataSources[ i ] = DataSources[ i ].Clone();
      return ret;
    }
    private DataSourceConfiguration[] m_DataSources = null;
    #endregion

  }
}
