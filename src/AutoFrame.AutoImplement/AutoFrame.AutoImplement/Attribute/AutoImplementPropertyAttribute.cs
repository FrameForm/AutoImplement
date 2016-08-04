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

        public AutoImplementPropertyAttribute(string memberSetKey, object defaultValue)
        {
            DefaultValue = defaultValue;
            DefaultValueType = defaultValue.GetType();
            MemberSetKey = memberSetKey;
        }
        
        public object DefaultValue { get; }

        public Type DefaultValueType { get; }

        public string MemberSetKey { get; }
    }
}
