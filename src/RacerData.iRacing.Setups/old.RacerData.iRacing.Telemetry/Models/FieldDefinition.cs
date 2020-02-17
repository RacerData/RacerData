using System;
using System.Collections.Generic;
using System.Text;

namespace RacerData.iRacing.Telemetry.Models
{
    class FieldDefinition : IFieldDefinition
    {
        public virtual string Name { get; set; }
        public virtual string Group { get; set; }
        private string _key;
        public virtual string Key
        {
            get
            {
                if (String.IsNullOrEmpty(_key))
                    _key = $"{Group}.{Name}";

                return _key;
            }
            set
            {
                _key = value;
            }
        }
        public virtual string Description { get; set; }
        public virtual string Unit { get; set; }
        public virtual irsdk_VarType DataType { get; set; }
        public virtual string DataTypeName
        {
            get
            {
                if (DataType == irsdk_VarType.irsdk_bool) // 1 = irsdk_bool
                    return "Boolean";
                else if (DataType == irsdk_VarType.irsdk_int) // 2 = irsdk_int
                    return "Int32";
                else if (DataType == irsdk_VarType.irsdk_bitField) // 3 = irsdk_bitField 
                    return Unit;
                else if (DataType == irsdk_VarType.irsdk_float) // 4 = irsdk_float
                    return "Single";
                else if (DataType == irsdk_VarType.irsdk_double) // 5 = irsdk_double
                    return "Double";
                else
                    return "FOO";
            }
        }
        public virtual int Size
        {
            //// 1 byte
            //irsdk_bool,

            //// 4 bytes
            //irsdk_int,
            //irsdk_bitField,
            //irsdk_float,

            //// 8 bytes
            //irsdk_double,
            get
            {
                if (DataType == irsdk_VarType.irsdk_bool) // 1 = irsdk_bool
                    return 1;
                else if (DataType == irsdk_VarType.irsdk_int) // 2 = irsdk_int
                    return 4;
                else if (DataType == irsdk_VarType.irsdk_bitField) // 3 = irsdk_bitField 
                    return 4;
                else if (DataType == irsdk_VarType.irsdk_float) // 4 = irsdk_float
                    return 4;
                else if (DataType == irsdk_VarType.irsdk_double) // 5 = irsdk_double
                    return 8;
                else
                    return 0;
            }
        }
        public virtual Int32 Position { get; set; }
        public virtual bool IsCalculated { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
