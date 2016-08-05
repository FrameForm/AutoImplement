using System;

namespace AutoFrame.AutoImplement.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AutoImplementPropertyAttribute : System.Attribute
    {
        #region Constructors

        public AutoImplementPropertyAttribute(object defaultValue)
        {
            IsKeyed = false;
            HasExplicitValue = true;
            IsRandomSelection = false;
            HasProvidedValueRange = false;

            DefaultValue = defaultValue;
            DefaultValueType = defaultValue.GetType();
            MemberSetKey = null;
            ProvidedValues = null;
        }

        public AutoImplementPropertyAttribute(string memberSetKey, object defaultValue)
        {
            IsKeyed = true;
            HasExplicitValue = true;
            IsRandomSelection = false;
            HasProvidedValueRange = false;

            DefaultValue = defaultValue;
            DefaultValueType = defaultValue.GetType();
            MemberSetKey = memberSetKey;
            ProvidedValues = null;
        }

        public AutoImplementPropertyAttribute(Type type)
        {
            IsKeyed = false;
            HasExplicitValue = false;
            IsRandomSelection = true;
            HasProvidedValueRange = false;

            DefaultValue = null;
            DefaultValueType = type;
            MemberSetKey = null;
            ProvidedValues = null;
        }

        public AutoImplementPropertyAttribute(string memberSetKey, Type type)
        {
            IsKeyed = true;
            HasExplicitValue = false;
            IsRandomSelection = true;
            HasProvidedValueRange = false;
            
            DefaultValue = null;
            DefaultValueType = type;
            MemberSetKey = memberSetKey;
            ProvidedValues = null;
        }
        

        public AutoImplementPropertyAttribute(object[] possibleDefaultValues)
        {
            IsKeyed = false;
            HasExplicitValue = false;
            IsRandomSelection = true;
            HasProvidedValueRange = true;

            DefaultValue = null;
            DefaultValueType = possibleDefaultValues.Length == 0 ? typeof(void) : possibleDefaultValues[0].GetType();
            MemberSetKey = null;
            ProvidedValues = null;
        }

       

        public AutoImplementPropertyAttribute(string memberSetKey, object[] possibleDefaultValues)
        {
            IsKeyed = true;
            HasExplicitValue = false;
            IsRandomSelection = true;
            HasProvidedValueRange = true;

            DefaultValue = null;
            DefaultValueType = possibleDefaultValues.Length == 0 ? typeof(void) : possibleDefaultValues[0].GetType();
            MemberSetKey = MemberSetKey;
            ProvidedValues = possibleDefaultValues;
        }

        #endregion

        #region Internal Properties

        internal object DefaultValue { get; }

        internal Type DefaultValueType { get; }
        
        internal string MemberSetKey { get; }

        internal object[] ProvidedValues { get; }
        
        internal bool IsKeyed { get; }

        internal bool HasExplicitValue { get; }

        internal bool IsRandomSelection { get; }
        
        internal bool HasProvidedValueRange { get; }

        #endregion

    }
}
