//<summary>
//  Title   : Configuration for the server
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

using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.EmbeddedResources;
using CAS.CommServer.UA.ConfigurationEditor.ServerConfiguration.Properties;
using CAS.DataPorter.Configurator;
using CAS.Lib.RTLib.Utils;
using CAS.UA.IServerConfiguration;
using Opc.Ua;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{

  /// <summary>
  /// Configuration for the server
  /// </summary>
  [XmlType( Namespace = DefaultNamespace )]
  [XmlRoot( Namespace = DefaultNamespace, IsNullable = true )]
  [XmlInclude( typeof( SourceBase ) )]
  [XmlInclude( typeof( OPCDAClientSourceConfiguration ) )]
  [XmlInclude( typeof( CommServerSourceConfiguration ) )]
  [XmlInclude( typeof( SimulatorSourceConfiguration ) )]
  [KnownType( typeof( SourceBase ) )]
  [KnownType( typeof( OPCDAClientSourceConfiguration ) )]
  [KnownType( typeof( CommServerSourceConfiguration ) )]
  [KnownType( typeof( SimulatorSourceConfiguration ) )]
  [DataContract( Namespace = DefaultNamespace )]
  public class CASConfiguration: ApplicationConfiguration
  {
    #region static
    private static string CurrentDirectory = string.Empty;
    /// <summary>
    /// Default Namespace for this class (to be used in XML serialization)
    /// </summary>
    public const string DefaultNamespace = "http://cas.eu/UA/2009/ServerConfiguration.xsd";
    /// <summary>
    /// Prepares the path based on base directory.
    /// </summary>
    /// <param name="sourcePath">The source path.</param>
    /// <returns>FileInfo.</returns>
    public static FileInfo PreparePathBasedOnBaseDirectory( string sourcePath )
    {
      FileInfo file = null;
      if ( !String.IsNullOrEmpty( sourcePath ) )
      {
        if ( !RelativeFilePathsCalculator.TestIfPathIsAbsolute( sourcePath ) )
        {
          file = new FileInfo( Path.Combine( CurrentDirectory, sourcePath ) );
        }
        else
        {
          file = new FileInfo( sourcePath );
        }
      }
      return file;
    }
    /// <summary>
    /// Loads the application configuration from a configuration section.
    /// </summary>
    /// <param name="sectionName">Name of configuration section for the current application's default configuration containing <see cref="ConfigurationLocation"/>.</param>
    /// <param name="applicationType">A description for the ApplicationType DataType.</param>
    /// <returns></returns>
    internal static new CASConfiguration Load( string sectionName, ApplicationType applicationType )
    {
      return ApplicationConfiguration.Load( sectionName, applicationType, typeof( CASConfiguration ) ) as CASConfiguration;
    }
    /// <summary>
    /// Loads the specified file.
    /// </summary>
    /// <remarks>This function is called during Application installation.</remarks>
    /// <param name="file">The file.</param>
    /// <param name="applicationType">Type of the application.</param>
    /// <param name="systemType">Type of the system.</param>
    /// <param name="applyTraceSettings">if set to <c>true</c> [apply trace settings].</param>
    /// <returns>CASConfiguration.</returns>
    public static new CASConfiguration Load( FileInfo file, ApplicationType applicationType, Type systemType, bool applyTraceSettings )
    {
      CurrentDirectory = file.DirectoryName;
      return ApplicationConfiguration.Load( file,applicationType,systemType,applyTraceSettings ) as CASConfiguration;
    }
    /// <summary>
    /// Loads the specified configuration file.
    /// </summary>
    /// <param name="configurationFile">The configuration file.</param>
    /// <returns>CAS Configuration</returns>
    internal static CASConfiguration Load( FileInfo configurationFile )
    {
      CurrentDirectory = configurationFile.DirectoryName;
      CASConfiguration CASConfigurationToBeReturned = ApplicationConfiguration.Load( configurationFile, ApplicationType.Server, typeof( CASConfiguration ) ) as CASConfiguration;
      TestIfProcessBindingsAreCreatedAndCreateIfItIsNull( CASConfigurationToBeReturned );
      return CASConfigurationToBeReturned;
    }
    /// <summary>
    /// Creates the default <see cref="CASConfiguration"/>
    /// </summary>
    /// <returns>The default <see cref="CASConfiguration"/> instance</returns>
    internal static CASConfiguration CreateDefault()
    {
      CurrentDirectory = string.Empty;
      Stream _inputStream = ResourcesManagement.GetDefaultServerConfigurationFile();
      DataContractSerializer serializer = new DataContractSerializer(typeof(CASConfiguration));
      XmlTextReader reader = new XmlTextReader(_inputStream);
      CASConfiguration CASConfigurationToBeReturned = serializer.ReadObject(reader, false) as CASConfiguration;
      TestIfProcessBindingsAreCreatedAndCreateIfItIsNull(CASConfigurationToBeReturned);
      if (CASConfigurationToBeReturned == null)
      {
        CASConfigurationToBeReturned = new CASConfiguration();
        TestIfProcessBindingsAreCreatedAndCreateIfItIsNull(CASConfigurationToBeReturned);
      }
      return CASConfigurationToBeReturned;
    }


    #region private static
    private static void TestIfProcessBindingsAreCreatedAndCreateIfItIsNull( CASConfiguration CASConfigurationToBeReturned )
    {
      if ( CASConfigurationToBeReturned != null && CASConfigurationToBeReturned.CASExtension == null )
        CASConfigurationToBeReturned.CASExtension = new ProcessDataBindings();
    }
    #endregion private static
    
    #endregion static

    #region public properties
    /// <summary>
    /// Gets or sets the extension configuration (by CAS).
    /// </summary>
    /// <value>The CAS extension configuration.</value>
    [Browsable( true )]
    [Category( "CAS UA Server" )]
    [DisplayName( "CAS Extension" )]
    [Description( "CAS UA Server configuration content." )]
    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    [DataMember( IsRequired = true )]
    public ProcessDataBindings CASExtension { get; set; }
    #endregion

    #region public
    /// <summary>
    /// Saves the specified configuration file.
    /// </summary>
    /// <param name="configurationFile">The configuration file.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
    internal void Save( FileInfo configurationFile )
    {
      string _baseDirectory = configurationFile.DirectoryName;
      this.CASExtension.OPCDAClient.SetBaseDirectoryFilePath( _baseDirectory );
      this.CASExtension.CommServer.SetBaseDirecotryFilePath( _baseDirectory );
      DataContractSerializer _deserializer = new DataContractSerializer( typeof( CASConfiguration ) );
      XmlWriterSettings _ws = new XmlWriterSettings();
      _ws.Indent = true;
      using ( FileStream file = new FileStream( configurationFile.FullName, FileMode.Create, FileAccess.Write ) )
      using ( XmlWriter writer = XmlWriter.Create( file, _ws ) )
        _deserializer.WriteObject( writer, this );
      NamedTraceLogger.Logger.TraceEvent( TraceEventType.Verbose, 164, Resources.InformationFileSaved, configurationFile.FullName  );
    }
    /// <summary>
    /// Gets the instance configuration.
    /// </summary>
    /// <param name="nodeUniqueIdentifier">The node unique identifier.</param>
    /// <returns>The selected instance configuration interface to object providing configuration management functions.</returns>
    internal IInstanceConfiguration GetInstanceConfiguration( INodeDescriptor nodeUniqueIdentifier )
    {
      return CASExtension.GetInstanceConfiguration( nodeUniqueIdentifier );
    }
    internal void GetInstanceConfiguration( INodeDescriptor[] descriptors, bool SkipOpeningConfigurationFile, out bool CancelWasPressed )
    {
      CASExtension.GetInstanceConfiguration( descriptors, SkipOpeningConfigurationFile, out CancelWasPressed );
    }
    /// <summary>
    /// Occurs when any modifications are applied to the content.
    /// </summary>
    //TODO raise this event in case of any changes.
    internal event EventHandler OnChenged;
    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return Resources.MainEditorTitle;
    }
    #endregion

  }
  /// <summary>
  /// Process data bindings definition
  /// </summary>
  [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
  public class ProcessDataBindings
  {
    #region creators and initialisation
    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessDataBindings"/> class.
    /// </summary>
    public ProcessDataBindings()
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
      //Dictionary is always created, but
      //when InstanceConfiguration[] NodesConfiguration is set it could be cleared 
      Dictionary = new SortedList<NodeDescriptorWrapper, InstanceConfiguration>();
      OPCDAClient = new OPCDAClientConfiguration();
      CommServer = new CommServerConfiguration();
      Simulator = new SimulatorConfiguration();
    }
    #endregion

    #region public

    #region properties
    /// <summary>
    /// Gets or sets the model layers.
    /// </summary>
    /// <value>The model layers.</value>
    [DisplayName( "Model Layers" )]
    [Description( "The configuration properties of namespaces, *.uanodes and *.csv files containing the configuration of the nodes." )]
    [DataMember( Order = 4 )]
    public ModelLayer[] ModelLayers { get; set; }

    /// <summary>
    /// Gets or sets the OPC client configuration.
    /// </summary>
    /// <value>The OPC client.</value>
    [ReadOnly( true )]
    [DisplayName( "OPC DA Client" )]
    [Description( "The configuration properties of the OPC DA Client data source." )]
    [Category( "Data sources" )]
    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    [XmlElement( "OPCDAClientConfiguration", typeof( OPCDAClientConfiguration ), IsNullable = true )]
    [DataMember( Name = "OPCDAClientConfiguration", Order = 0 )]
    public OPCDAClientConfiguration OPCDAClient { get; set; }

    /// <summary>
    /// Gets or sets the configuration properties of the CommServer communication engine data source..
    /// </summary>
    /// <value>The CommServer configuration properties.</value>
    [ReadOnly( true )]
    [DisplayName( "CommServer" )]
    [Description( "The configuration properties of the CommServer communication engine data source." )]
    [Category( "Data sources" )]
    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    [XmlElement( "CommServerConfiguration", typeof( CommServerConfiguration ), IsNullable = true )]
    [DataMember( Name = "CommServerConfiguration", Order = 1 )]
    public CommServerConfiguration CommServer { get; set; }

    /// <summary>
    /// Gets or sets the configuration properties of the Simulator data source.
    /// </summary>
    /// <value>The simulator configuration properties.</value>
    [DisplayName( "Simulator" )]
    [Description( "The configuration properties of the Simulator data source." )]
    [Category( "Data sources" )]
    [XmlElement( "SimulatorConfiguration", typeof( SimulatorConfiguration ), IsNullable = true )]
    [DataMember( Name = "SimulatorConfiguration", Order = 2 )]
    public SimulatorConfiguration Simulator { get; set; }

    /// <summary>
    /// Gets or sets the instance node configuration.
    /// </summary>
    /// <value>The instance nodes configuration.</value>
    [DataMember( Order = 3 )]
    public InstanceConfiguration[] NodesConfiguration
    {
      get
      {
        InstanceConfiguration[] m_NodesConfiguration = new InstanceConfiguration[ Dictionary.Count ];
        Dictionary.Values.CopyTo( m_NodesConfiguration, 0 );
        return m_NodesConfiguration;
      }
      set
      {
        InstanceConfiguration[] m_NodesConfiguration = value;
        Dictionary.Clear();
        if ( m_NodesConfiguration == null )
          return;
        foreach ( InstanceConfiguration item in m_NodesConfiguration )
          if ( item.NodeDescriptor != null )
          {
            if ( Dictionary.ContainsKey( item.NodeDescriptor ) )
            {
              //TODO:: TraceEvent - to be logged
            }
            else
              Dictionary.Add( item.NodeDescriptor, item );
          }
      }
    }
    #endregion

    internal void GetInstanceConfiguration( INodeDescriptor[] descriptors, bool SkipOpeningConfigurationFile, out bool CancelWasPressed )
    {
      ConfigurationManagement.AdditionalResultInfo OperationResult;
      CancelWasPressed = SkipOpeningConfigurationFile;
      foreach ( INodeDescriptor item in descriptors )
      {
        InstanceConfiguration ic = GetInstanceConfiguration( item ) as InstanceConfiguration;
        List<DataSourceConfiguration> dsc = new List<DataSourceConfiguration>();
        if ( ic.DataSources != null )
          dsc.AddRange( ic.DataSources );
        DataSourceConfiguration newDataSource = new DataSourceConfiguration()
        {
          SelectedSource = DataSourceConfiguration.Source.OPCClient,
          SelectedSourceConfiguration =
             new OPCDAClientSourceConfiguration( item,
               out OperationResult,
               CancelWasPressed )
        };
        if ( OperationResult == ConfigurationManagement.AdditionalResultInfo.Cancel )
          CancelWasPressed = true;
        dsc.Add( newDataSource );
        if ( dsc.Count > 0 )
          ic.DataSources = dsc.ToArray();
      }
    }
    /// <summary>
    /// Gets the instance configuration.
    /// </summary>
    /// <param name="nodeUniqueIdentifier">The node unique identifier.</param>
    /// <returns>The interface providing access to the instance configuration.</returns>
    internal IInstanceConfiguration GetInstanceConfiguration( INodeDescriptor nodeUniqueIdentifier )
    {
      InstanceConfiguration sourceIC = new InstanceConfiguration( nodeUniqueIdentifier );
      InstanceConfiguration ic = null;
      if ( Dictionary.TryGetValue( sourceIC.NodeDescriptor, out ic ) )
        return ic;
      else
      {
        Dictionary.Add( sourceIC.NodeDescriptor, sourceIC );
        return sourceIC;
      }
    }
    #endregion

    #region private
    private SortedList<NodeDescriptorWrapper, InstanceConfiguration> Dictionary { get; set; }
    #endregion
  }
}
