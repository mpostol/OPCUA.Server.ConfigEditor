//<summary>
//  Title   : DataSource Configuration
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
using System.Drawing.Design;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// DataSource Configuration
  /// </summary>
  [TypeConverterAttribute( typeof( ExpandableObjectConverter ) )]
  [KnownType( typeof( SourceBase ) )]
  [KnownType( typeof( OPCDAClientSourceConfiguration ) )]
  [KnownType( typeof( CommServerSourceConfiguration ) )]
  [KnownType( typeof( SimulatorSourceConfiguration ) )]
  [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
  public class DataSourceConfiguration
  {
    #region public properties

    /// <summary>
    /// Gets or sets the name of the data source configuration.
    /// </summary>
    /// <value>The name.</value>
    [DisplayName( "Name" )]
    [Description( "Select a process data source name." )]
    [Category( "Data source" )]
    [DataMember( Order = 0 )]
    public string Name { get; set; }
    /// <summary>
    /// Gets or sets the selected source.
    /// </summary>
    /// <value>The selected source browse.</value>
    /// <remarks>Used by the <see cref="PropertyGrid"/> to expose current value and edit by the user. </remarks>
    [DisplayName( "Source" )]
    [Description( "Select a process data source." )]
    [Category( "Process data source" )]
    [XmlIgnore()]
    public Source SelectedSourceBrowse
    {
      get { return m_SelectedSource; }
      set
      {
        if ( m_SelectedSource == value )
          return;
        m_SelectedSource = value;
        switch ( m_SelectedSource )
        {
          case Source.CommServer:
            SelectedSourceConfiguration = CommServerSourceConfiguration.CreateInstance();
            break;
          case Source.OPCClient:
            SelectedSourceConfiguration = OPCDAClientSourceConfiguration.CreateInstance();
            break;
          case Source.Simulator:
            SelectedSourceConfiguration = new SimulatorSourceConfiguration();
            break;
          case Source.None:
            SelectedSourceConfiguration = new DefaultSourceConfiguration();
            break;
        }
      }
    }
    /// <summary>
    /// Gets or sets the selected source.
    /// </summary>
    /// <value>The selected source.</value>
    /// <remarks>Used by the <see cref="XmlSerializer"/></remarks>
    [Browsable( false )]
    [DataMember( Order = 1 )]
    public Source SelectedSource
    {
      get { return m_SelectedSource; }
      set
      {
        m_SelectedSource = value;
      }
    }
    /// <summary>
    /// Gets or sets the selected source configuration browse.
    /// </summary>
    /// <value>The selected source configuration browse.</value>
    [DisplayName( "Binding" )]
    [Description( "Provides bindings information of the process data source for the node." )]
    [Category( "Process data source" )]
    [TypeConverterAttribute( typeof( ExpandableObjectConverter ) )]
    [EditorAttribute( typeof( SelectedSourceEditor ), typeof( UITypeEditor ) )]
    [XmlIgnore()]
    public SourceBase SelectedSourceConfigurationBrowse
    {
      get { return m_SelectedSourceConfiguration; }
      set { m_SelectedSourceConfiguration = value; }
    }
    /// <summary>
    /// Gets or sets the selected source configuration.
    /// </summary>
    /// <value>The selected source configuration.</value>
    [XmlElement( "CommServerSourceConfiguration", typeof( CommServerSourceConfiguration ), IsNullable = true )]
    [XmlElement( "OPCDAClientSourceConfiguration", typeof( OPCDAClientSourceConfiguration ), IsNullable = true )]
    [XmlElement( "SimulatorSourceConfiguration", typeof( SimulatorSourceConfiguration ), IsNullable = true )]
    [Browsable( false )]
    public SourceBase SelectedSourceConfiguration
    {
      get { return SelectedSourceBrowse == Source.None ? null : m_SelectedSourceConfiguration; }
      set
      {
        m_SelectedSourceConfiguration = value == null ? new DefaultSourceConfiguration() : value;
      }
    }
    [DataMember( IsRequired = false, Order = 2, EmitDefaultValue = false )]
    [XmlIgnore()]
    [Obsolete( "Should be used only by DataContract serializer" )]
    private CommServerSourceConfiguration CommServerSourceConfiguration
    {
      set
      {
        if ( value != null )
          SelectedSourceConfiguration = value;
      }
      get
      {
        if ( SelectedSourceConfiguration is CommServerSourceConfiguration )
          return SelectedSourceConfiguration as CommServerSourceConfiguration;
        else
          return null;
      }
    }
    [DataMember( IsRequired = false, Order = 2, EmitDefaultValue = false )]
    [XmlIgnore()]
    [Obsolete( "Should be used only by DataContract serializer" )]
    private OPCDAClientSourceConfiguration OPCDAClientSourceConfiguration
    {
      set
      {
        if ( value != null )
          SelectedSourceConfiguration = value;
      }
      get
      {
        if ( SelectedSourceConfiguration is OPCDAClientSourceConfiguration )
          return SelectedSourceConfiguration as OPCDAClientSourceConfiguration;
        else
          return null;
      }
    }
    [DataMember( IsRequired = false, Order = 2, EmitDefaultValue = false )]
    [XmlIgnore()]
    [Obsolete( "Should be used only by DataContract serializer" )]
    private SimulatorSourceConfiguration SimulatorSourceConfiguration
    {
      set
      {
        if ( value != null )
          SelectedSourceConfiguration = value;
      }
      get
      {
        if ( SelectedSourceConfiguration is SimulatorSourceConfiguration )
          return SelectedSourceConfiguration as SimulatorSourceConfiguration;
        else
          return null;
      }
    }
    #endregion

    #region public
    internal DataSourceConfiguration Clone()
    {
      return new DataSourceConfiguration()
      {
        Name = this.Name,
        m_SelectedSource = this.m_SelectedSource,
        m_SelectedSourceConfiguration = this.m_SelectedSourceConfiguration,
      };
    }
    /// <summary>
    /// Data source enumerator
    /// </summary>
    [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
    public enum Source
    {
      /// <summary>
      /// The data source is not selected
      /// </summary>
      [EnumMember]
      None,
      /// <summary>
      /// The opc client is selected as the data source
      /// </summary>
      [EnumMember]
      OPCClient,
      /// <summary>
      /// The CommServer engine is selected as the data source.
      /// </summary>
      [EnumMember]
      CommServer,
      /// <summary>
      /// The simulator is selected as the data source
      /// </summary>
      [EnumMember]
      Simulator
    };
    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return String.Format("Name {0} Source: {1} Config: {2}", Name, SelectedSourceBrowse, SelectedSourceConfiguration == null ? "null": SelectedSourceConfiguration.ToString());
    }
    #endregion

    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="DataSourceConfiguration"/> class.
    /// </summary>
    public DataSourceConfiguration()
    {
      Initialize();
    }
    /// <summary>
    /// Initializes the object during deserialization.
    /// </summary>
    /// <param name="context">The context.</param>
    [OnDeserializing()]
    private void Initialize( StreamingContext context )
    {
      Initialize();
    }
    private void Initialize()
    {
      Name = String.Format( "DataSource{0}", count++ );
      SelectedSourceConfiguration = new DefaultSourceConfiguration();
    }
    #endregion

    #region private
    /// <summary>
    /// Dedicated edtior for the <see cref="SelectedSourceConfiguration"/> property
    /// </summary>
    private class SelectedSourceEditor: UITypeEditor
    {
      #region overrides
      /// <summary>
      /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.
      /// </summary>
      /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
      /// <param name="provider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services.</param>
      /// <param name="value">The object to edit.</param>
      /// <returns>
      /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
      /// </returns>
      public override object EditValue( System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value )
      {
        DataSourceConfiguration ds = context.Instance as DataSourceConfiguration;
        SourceBase src = value as SourceBase;
        return src.GetSourceBase();
      }
      /// <summary>
      /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method.
      /// </summary>
      /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
      /// <returns>
      /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"/> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"/> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"/>.
      /// </returns>
      public override UITypeEditorEditStyle GetEditStyle( System.ComponentModel.ITypeDescriptorContext context )
      {
        return UITypeEditorEditStyle.Modal;
      }
      #endregion
    }
    private Source m_SelectedSource = Source.None;
    private SourceBase m_SelectedSourceConfiguration = new DefaultSourceConfiguration();
    private static uint count = 0;
    #endregion

  }
}
