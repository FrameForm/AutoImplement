using System;

namespace AutoFrame.AutoImplement.Exceptions
{
    public class InvalidPropertyDefaultTypeException : Exception
    {
        internal InvalidPropertyDefaultTypeException(Type interfaceType, string propertyName, Type propertyType, 
            object defaultValue, Type defaultValueType)
            : base($"Unable to assign default value [{defaultValue}] of type [{defaultValueType.Name}]" +
                   $"to property [{propertyName}] of type [{propertyType.Name}] in interface [{interfaceType.Name}]")
        {
            InterfaceType = interfaceType;
            PropertyName = propertyName;
            PropertyType = propertyType;
            DefaultValue = defaultValue;
            DefaultValueType = defaultValueType;
        }

        public Type InterfaceType { get; }

        public string PropertyName { get; }

        public Type PropertyType { get; }

        public object DefaultValue { get; }

        public Type DefaultValueType { get; }
    }
}
