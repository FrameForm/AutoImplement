using System;

namespace AutoFrame.AutoImplement.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ImplementationContractPropertyAttribute : System.Attribute
    {
        public ImplementationContractPropertyAttribute()
        {
        }

        public ImplementationContractPropertyAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
        
        internal object DefaultValue { get; private set; }
    }
}