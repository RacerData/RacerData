using System;

namespace RacerData.iRacing.Telemetry.Models
{
    public interface IFieldDefinition
    {
        string DataTypeName { get; }
        string Description { get; set; }
        string Group { get; set; }
        string Name { get; set; }
        string Key { get; set; }
        string Unit { get; set; }
        irsdk_VarType DataType { get; set; }
        int Size { get; }
        Int32 Position { get; set; }
        bool IsCalculated { get; }

        string ToString();
    }
}