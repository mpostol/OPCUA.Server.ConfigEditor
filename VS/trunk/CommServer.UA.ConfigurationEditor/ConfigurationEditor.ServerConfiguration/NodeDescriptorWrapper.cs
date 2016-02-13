//<summary>
//  Title   : Wrapper providing information about the model node
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

using CAS.UA.IServerConfiguration;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Wrapper providing information about the model node
  /// </summary>
  [DataContract( Namespace = CASConfiguration.DefaultNamespace )]
  public class NodeDescriptorWrapper: INodeDescriptor, ICloneable, IComparable
  {
    #region INodeDescriptor Members
    /// <summary>
    /// Gets the node unique identifier.
    /// </summary>
    /// <value>The node identifier.</value>
    [DisplayName( "Name" )]
    [Description( "The node unique identifier." )]
    [Category( "Node" )]
    [ReadOnly( true )]
    [XmlElement( IsNullable = false )]
    [DataMember]
    public XmlQualifiedName NodeIdentifier { get; set; }
    /// <summary>
    /// Gets the node class.
    /// </summary>
    /// <value>The node class.</value>
    [DisplayName( "Node class" )]
    [Description( "The node unique identifier." )]
    [Category( "Node" )]
    [ReadOnly( true )]
    [DataMember]
    public InstanceNodeClassesEnum NodeClass { get; set; }
    /// <summary>
    /// Gets the type of the node of of the Variable NodeClass
    /// </summary>
    /// <value>The type of the data.</value>
    [DisplayName( "Data type" )]
    [Description( "The type of the node of the Variable node class" )]
    [Category( "Node" )]
    [ReadOnly( true )]
    [Browsable( false )]
    [DataMember( EmitDefaultValue = false )]
    //TODO it is not provided if a node is redefined by the derived type
    public XmlQualifiedName DataType { get; set; }

    /// <summary>
    /// Gets a value indicating whether it is instance declaration - may have meny instance in the created address space.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if the node is instance declaration; otherwise, <c>false</c>.
    /// </value>
    [DisplayName( "Instance Declaration" )]
    [Description( "Indicates whether this node is an instance declaration and can be instantiated many times." )]
    [Category( "Node" )]
    [ReadOnly( true )]
    [Browsable( true )]
    [DataMember( EmitDefaultValue = false )]
    [DefaultValue( false )]
    public bool InstanceDeclaration { get; set; }
    /// <summary>
    /// Gets the binding description that allows the editor to create automatically bindings.
    /// </summary>
    /// <value>The binding description - .</value>
    [DisplayName( "Description" )]
    [Description( "The binding description that allows the editor to create automatically bindings." )]
    [Category( "Node" )]
    [ReadOnly( true )]
    [Browsable( true )]
    [DataMember( EmitDefaultValue = false )]
    [DefaultValue( false )]
    public string BindingDescription { get; set; }
    #endregion

    #region public
    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return NodeIdentifier.ToString();
    }
    #endregion

    #region creators
    /// <summary>
    /// Initializes a new instance of the <see cref="NodeDescriptorWrapper"/> class.
    /// </summary>
    [Obsolete( "Can be used only by Deserializator" )]
    //TODO Add creator initializing all properties and use it while creating the object. 
    //http://itrserver.hq.cas.com.pl/Bugs/BugDetail.aspx?bid=1553
    public NodeDescriptorWrapper()
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="NodeDescriptorWrapper"/> class.
    /// </summary>
    /// <param name="descriptor">The descriptor of the node.</param>
    internal NodeDescriptorWrapper( INodeDescriptor descriptor )
    {
      if ( descriptor.DataType != null )
        this.DataType = new XmlQualifiedName( descriptor.DataType.Name, descriptor.DataType.Namespace );
      this.NodeIdentifier = new XmlQualifiedName( descriptor.NodeIdentifier.Name, descriptor.NodeIdentifier.Namespace );
      this.NodeClass = descriptor.NodeClass;
      this.InstanceDeclaration = descriptor.InstanceDeclaration;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="NodeDescriptorWrapper"/> class with empty <see cref="DataType"/>.
    /// </summary>
    /// <param name="ns">The namespace.</param>
    /// <param name="name">The name of the item.</param>
    public NodeDescriptorWrapper( string ns, string name )
    {
      NodeIdentifier = new XmlQualifiedName( name, ns );
      NodeClass = InstanceNodeClassesEnum.NotDefined;
    }
    #endregion

    #region ICloneable Members
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public object Clone()
    {
      return this.MemberwiseClone();
    }
    #endregion

    #region IComparable Members
    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="obj">An object to compare with this instance.</param>
    /// <returns>
    /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings:
    /// Value
    /// Meaning
    /// Less than zero
    /// This instance is less than <paramref name="obj"/>.
    /// Zero
    /// This instance is equal to <paramref name="obj"/>.
    /// Greater than zero
    /// This instance is greater than <paramref name="obj"/>.
    /// </returns>
    /// <exception cref="T:System.ArgumentException">
    /// 	<paramref name="obj"/> is not the same type as this instance.
    /// </exception>
    public int CompareTo( object obj )
    {
      if ( obj == null )
        throw new ArgumentException( "Parameter cannot be null" );
      NodeDescriptorWrapper other = obj as NodeDescriptorWrapper;
      if ( other == null )
        throw new ArgumentNullException( "Parameter is not the same type as this instance." );
      if ( this.NodeIdentifier == null || other.NodeIdentifier == null )
        throw new ArgumentNullException( "Instance identifier cannot be null." );
      if ( this.NodeIdentifier.IsEmpty || other.NodeIdentifier.IsEmpty )
        throw new ArgumentNullException( "Instance identifier cannot be empty." );
      if ( String.IsNullOrEmpty( this.NodeIdentifier.Namespace ) || String.IsNullOrEmpty( other.NodeIdentifier.Namespace ) )
        throw new ArgumentNullException( "Instance identifier Namespace cannot be null." );
      int ret = NodeIdentifier.Namespace.CompareTo( other.NodeIdentifier.Namespace );
      if ( ret != 0 )
        return ret;
      if ( String.IsNullOrEmpty( this.NodeIdentifier.Name ) || String.IsNullOrEmpty( other.NodeIdentifier.Namespace ) )
        throw new ArgumentNullException( "Instance identifier Name cannot be null." );
      return NodeIdentifier.Name.CompareTo( other.NodeIdentifier.Name );
    }
    #endregion

  }
}
