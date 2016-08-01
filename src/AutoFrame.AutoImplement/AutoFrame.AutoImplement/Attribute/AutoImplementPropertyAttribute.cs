using System;

namespace AutoFrame.AutoImplement.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoImplementPropertyAttribute : System.Attribute
    {
        public AutoImplementPropertyAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
            DefaultValueType = defaultValue.GetType();
        }

        public AutoImplementPropertyAttribute(object defaultValue, string propertySetName)
        {
            DefaultValue = defaultValue;
            DefaultValueType = defaultValue.GetType();
            PropertySetName = propertySetName;
        }

        public object DefaultValue { get; }

        public Type DefaultValueType { get; }

        public string PropertySetName { get; }
    }
}
