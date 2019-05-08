using System;

namespace RacerData.NascarApi.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EnumTypeAttribute : Attribute
    {
        public string EnumTypeName { get; set; }
        
        public EnumTypeAttribute(string enumTypeName)
        {
            EnumTypeName = enumTypeName;
        }
    }
}
