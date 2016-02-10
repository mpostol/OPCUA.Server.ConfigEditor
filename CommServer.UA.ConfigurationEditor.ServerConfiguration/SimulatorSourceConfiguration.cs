//<summary>
//  Title   : Simulator Source
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

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CAS.UA.Server.ServerConfiguration
{
  /// <summary>
  /// Simulator source
  /// </summary>
  [XmlTypeAttribute(Namespace = CASConfiguration.DefaultNamespace)]
  [DataContract(Namespace = CASConfiguration.DefaultNamespace)]
  public class SimulatorSourceConfiguration : SourceBase
  {
    /// <summary>
    /// Names used by the Boiler simulator
    /// </summary>
    public enum Names
    {
      /// <summary>
      /// drum_LevelIndicator_Output_Value
      /// </summary>
      drum_LevelIndicator_Output_Value,
      /// <summary>
      /// customController_Input1_Value
      /// </summary>
      customController_Input1_Value,
      /// <summary>
      /// customController_Input2_Value
      /// </summary>
      customController_Input2_Value,
      /// <summary>
      /// customController_Input3_Value
      /// </summary>
      customController_Input3_Value,
      /// <summary>
      /// customController_ControlOut_Value
      /// </summary>
      customController_ControlOut_Value,
      /// <summary>
      /// flowController_SetPoint_Value
      /// </summary>
      flowController_SetPoint_Value,
      /// <summary>
      /// inputPipe_Valve_Input_Value
      /// </summary>
      inputPipe_Valve_Input_Value,
      /// <summary>
      /// inputPipe_FlowTransmitter1_Output_Value
      /// </summary>
      inputPipe_FlowTransmitter1_Output_Value,
      /// <summary>
      /// outputPipe_FlowTransmitter2_Output_Value
      /// </summary>
      outputPipe_FlowTransmitter2_Output_Value,
      /// <summary>
      /// The test_value1
      /// </summary>
      test_value1,
      /// <summary>
      /// The test_value2
      /// </summary>
      test_value2,
      /// <summary>
      /// The test_ byte
      /// </summary>
      test_Byte,
      /// <summary>
      /// The test_ byte string
      /// </summary>
      test_ByteString,
      /// <summary>
      /// The test_ boolean
      /// </summary>
      test_Boolean,
      /// <summary>
      /// The test_ s byte
      /// </summary>
      test_SByte,
      /// <summary>
      /// The test_ int16
      /// </summary>
      test_Int16,
      /// <summary>
      /// The test_ u int16
      /// </summary>
      test_UInt16,
      /// <summary>
      /// The test_ int32
      /// </summary>
      test_Int32,
      /// <summary>
      /// The test_ u int32
      /// </summary>
      test_UInt32,
      /// <summary>
      /// The test_ int64
      /// </summary>
      test_Int64,
      /// <summary>
      /// The test_ u int64
      /// </summary>
      test_UInt64,
      /// <summary>
      /// The test_ float
      /// </summary>
      test_Float,
      /// <summary>
      /// The test_ double
      /// </summary>
      test_Double,
      /// <summary>
      /// The test_ string
      /// </summary>
      test_String,
      /// <summary>
      /// The test_ date time
      /// </summary>
      test_DateTime,
      /// <summary>
      /// The test_ unique identifier
      /// </summary>
      test_Guid,
      /// <summary>
      /// The test_ XML element
      /// </summary>
      test_XmlElement,
      /// <summary>
      /// The test_ node identifier
      /// </summary>
      test_NodeId,
      /// <summary>
      /// The test_ expanded node identifier
      /// </summary>
      test_ExpandedNodeId,
      /// <summary>
      /// The test_ status code
      /// </summary>
      test_StatusCode,
      /// <summary>
      /// The test_ qualified name
      /// </summary>
      test_QualifiedName,
      /// <summary>
      /// The test_ localized text
      /// </summary>
      test_LocalizedText,
      /// <summary>
      /// The test_ extension object
      /// </summary>
      test_ExtensionObject,
      /// <summary>
      /// The test_ data value
      /// </summary>
      test_DataValue,
      /// <summary>
      /// The test_ variant
      /// </summary>
      test_Variant,
      /// <summary>
      /// The test_ diagnostic information
      /// </summary>
      test_DiagnosticInfo,
      /// <summary>
      /// The test_ number
      /// </summary>
      test_Number,
      /// <summary>
      /// The test_ integer
      /// </summary>
      test_Integer,
      /// <summary>
      /// The test_ u integer
      /// </summary>
      test_UInteger,
      /// <summary>
      /// The test_ enumeration
      /// </summary>
      test_Enumeration
    }
    /// <summary>
    /// Gets or sets the tag.
    /// </summary>
    /// <value>The tag.</value>
    [DataMember]
    public Names Tag { get; set; }
    /// <summary>
    /// Creates a new object that is a copy of the current instance.
    /// </summary>
    /// <returns>A new object that is a copy of this instance.</returns>
    public override object Clone()
    {
      return this.MemberwiseClone();
    }
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> like Simulator: boiler example that represents this instance.</returns>
    public override string ToString()
    {
      return string.Format("Simulator: {0}", Tag);
    }
    /// <summary>
    /// Gets the instance of this type.
    /// </summary>
    /// <returns>SourceBase.</returns>
    internal protected override SourceBase GetSourceBase()
    {
      return this;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="SimulatorSourceConfiguration"/> class.
    /// </summary>
    public SimulatorSourceConfiguration()
    {

    }
  }
}
