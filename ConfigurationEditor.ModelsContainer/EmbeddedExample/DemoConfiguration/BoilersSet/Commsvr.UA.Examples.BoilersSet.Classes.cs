/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;
using Commsvr.UA.Examples.BoilerType;

namespace Commsvr.UA.Examples.BoilersSet
{
    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Start Method.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_Start = 75;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Suspend Method.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_Suspend = 76;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Resume Method.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_Resume = 77;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Halt Method.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_Halt = 78;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Reset Method.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_Reset = 79;
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the BoilersArea Object.
        /// </summary>
        public const uint BoilersArea = 1;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler = 2;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_InputPipe = 3;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_FlowTransmitter1 Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_InputPipe_FlowTransmitter1 = 4;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_Valve Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_InputPipe_Valve = 11;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Drum Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Drum = 18;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Drum_LevelIndicator Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Drum_LevelIndicator = 19;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_OutputPipe Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_OutputPipe = 26;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2 Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2 = 27;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_FlowController Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_FlowController = 34;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_LevelController Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_LevelController = 38;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_CustomController = 42;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation Object.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation = 48;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output = 5;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output_EURange Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output_EURange = 9;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_Valve_Input Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_InputPipe_Valve_Input = 12;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_Valve_Input_EURange Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_InputPipe_Valve_Input_EURange = 16;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Drum_LevelIndicator_Output Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Drum_LevelIndicator_Output = 20;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Drum_LevelIndicator_Output_EURange Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Drum_LevelIndicator_Output_EURange = 24;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output = 28;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output_EURange Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output_EURange = 32;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_FlowController_Measurement Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_FlowController_Measurement = 35;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_FlowController_SetPoint Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_FlowController_SetPoint = 36;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_FlowController_ControlOut Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_FlowController_ControlOut = 37;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_LevelController_Measurement Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_LevelController_Measurement = 39;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_LevelController_SetPoint Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_LevelController_SetPoint = 40;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_LevelController_ControlOut Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_LevelController_ControlOut = 41;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_Input1 Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_CustomController_Input1 = 43;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_Input2 Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_CustomController_Input2 = 44;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_Input3 Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_CustomController_Input3 = 45;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_ControlOut Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_CustomController_ControlOut = 46;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_DescriptionX Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_CustomController_DescriptionX = 47;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_CurrentState Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_CurrentState = 49;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_CurrentState_Id Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_CurrentState_Id = 50;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_CurrentState_Number Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_CurrentState_Number = 52;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_LastTransition Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_LastTransition = 54;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_LastTransition_Id Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_LastTransition_Id = 55;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_LastTransition_Number Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_LastTransition_Number = 57;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_LastTransition_TransitionTime Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_LastTransition_TransitionTime = 58;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Deletable Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_Deletable = 60;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_RecycleCount Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_RecycleCount = 62;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateSessionId Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateSessionId = 64;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateClientName Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateClientName = 65;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_InvocationCreationTime Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_InvocationCreationTime = 66;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastTransitionTime Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastTransitionTime = 67;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCall Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCall = 68;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodSessionId Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodSessionId = 69;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodInputArguments Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodInputArguments = 70;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodOutputArguments Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodOutputArguments = 71;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCallTime Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCallTime = 72;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodReturnStatus Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodReturnStatus = 73;

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_UpdateRate Variable.
        /// </summary>
        public const uint BoilersArea_CASBoiler_Simulation_UpdateRate = 80;
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Start Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_Start = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Methods.BoilersArea_CASBoiler_Simulation_Start, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Suspend Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_Suspend = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Methods.BoilersArea_CASBoiler_Simulation_Suspend, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Resume Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_Resume = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Methods.BoilersArea_CASBoiler_Simulation_Resume, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Halt Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_Halt = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Methods.BoilersArea_CASBoiler_Simulation_Halt, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Reset Method.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_Reset = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Methods.BoilersArea_CASBoiler_Simulation_Reset, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the BoilersArea Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_InputPipe = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_InputPipe, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_FlowTransmitter1 Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_InputPipe_FlowTransmitter1 = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_InputPipe_FlowTransmitter1, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_Valve Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_InputPipe_Valve = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_InputPipe_Valve, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Drum Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Drum = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_Drum, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Drum_LevelIndicator Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Drum_LevelIndicator = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_Drum_LevelIndicator, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_OutputPipe Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_OutputPipe = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_OutputPipe, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2 Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2 = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_FlowController Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_FlowController = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_FlowController, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_LevelController Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_LevelController = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_LevelController, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_CustomController = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_CustomController, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation Object.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Objects.BoilersArea_CASBoiler_Simulation, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output_EURange = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_InputPipe_FlowTransmitter1_Output_EURange, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_Valve_Input Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_InputPipe_Valve_Input = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_InputPipe_Valve_Input, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_InputPipe_Valve_Input_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_InputPipe_Valve_Input_EURange = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_InputPipe_Valve_Input_EURange, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Drum_LevelIndicator_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Drum_LevelIndicator_Output = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Drum_LevelIndicator_Output, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Drum_LevelIndicator_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Drum_LevelIndicator_Output_EURange = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Drum_LevelIndicator_Output_EURange, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output_EURange Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output_EURange = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_OutputPipe_FlowTransmitter2_Output_EURange, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_FlowController_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_FlowController_Measurement = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_FlowController_Measurement, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_FlowController_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_FlowController_SetPoint = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_FlowController_SetPoint, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_FlowController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_FlowController_ControlOut = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_FlowController_ControlOut, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_LevelController_Measurement Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_LevelController_Measurement = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_LevelController_Measurement, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_LevelController_SetPoint Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_LevelController_SetPoint = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_LevelController_SetPoint, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_LevelController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_LevelController_ControlOut = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_LevelController_ControlOut, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_Input1 Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_CustomController_Input1 = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_CustomController_Input1, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_Input2 Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_CustomController_Input2 = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_CustomController_Input2, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_Input3 Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_CustomController_Input3 = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_CustomController_Input3, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_ControlOut Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_CustomController_ControlOut = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_CustomController_ControlOut, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_CustomController_DescriptionX Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_CustomController_DescriptionX = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_CustomController_DescriptionX, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_CurrentState Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_CurrentState = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_CurrentState, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_CurrentState_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_CurrentState_Id = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_CurrentState_Id, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_CurrentState_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_CurrentState_Number = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_CurrentState_Number, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_LastTransition Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_LastTransition = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_LastTransition, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_LastTransition_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_LastTransition_Id = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_LastTransition_Id, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_LastTransition_Number Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_LastTransition_Number = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_LastTransition_Number, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_LastTransition_TransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_LastTransition_TransitionTime = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_LastTransition_TransitionTime, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_Deletable Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_Deletable = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_Deletable, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_RecycleCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_RecycleCount = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_RecycleCount, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateSessionId = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateSessionId, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateClientName Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateClientName = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_CreateClientName, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_InvocationCreationTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_InvocationCreationTime = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_InvocationCreationTime, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastTransitionTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastTransitionTime = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastTransitionTime, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCall Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCall = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCall, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodSessionId Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodSessionId = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodSessionId, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodInputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodInputArguments = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodInputArguments, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodOutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodOutputArguments = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodOutputArguments, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCallTime Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCallTime = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodCallTime, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodReturnStatus Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodReturnStatus = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_ProgramDiagnostics_LastMethodReturnStatus, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);

        /// <summary>
        /// The identifier for the BoilersArea_CASBoiler_Simulation_UpdateRate Variable.
        /// </summary>
        public static readonly ExpandedNodeId BoilersArea_CASBoiler_Simulation_UpdateRate = new ExpandedNodeId(Commsvr.UA.Examples.BoilersSet.Variables.BoilersArea_CASBoiler_Simulation_UpdateRate, Commsvr.UA.Examples.BoilersSet.Namespaces.BoilersSet);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the BoilersArea component.
        /// </summary>
        public const string BoilersArea = "BoilersArea";

        /// <summary>
        /// The BrowseName for the CASBoiler component.
        /// </summary>
        public const string CASBoiler = "Boiler #1";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the BoilerType namespace (.NET code namespace is 'Commsvr.UA.Examples.BoilerType').
        /// </summary>
        public const string BoilerType = "http://commsvr.com/UA/Examples/BoilerType";

        /// <summary>
        /// The URI for the BoilerTypeXsd namespace (.NET code namespace is 'Commsvr.UA.Examples.BoilerType').
        /// </summary>
        public const string BoilerTypeXsd = "http://commsvr.com/UA/Examples/BoilerType/Types.xsd";

        /// <summary>
        /// The URI for the BoilersSet namespace (.NET code namespace is 'Commsvr.UA.Examples.BoilersSet').
        /// </summary>
        public const string BoilersSet = "http://commsvr.com/UA/Examples/BoilersSet";

        /// <summary>
        /// The URI for the BoilersSetXsd namespace (.NET code namespace is 'Commsvr.UA.Examples.BoilersSet').
        /// </summary>
        public const string BoilersSetXsd = "http://commsvr.com/UA/Examples/BoilersSet/Types.xsd";
    }
    #endregion

}