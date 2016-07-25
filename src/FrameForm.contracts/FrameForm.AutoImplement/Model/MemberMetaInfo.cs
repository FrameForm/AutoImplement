using System;
using System.Reflection;
using FastMember;
using FrameForm.AutoImplement.Attribute;

namespace FrameForm.AutoImplement.Model
{
    internal class MemberMetaInfo
    {
        internal MemberMetaInfo(Type memberType)
        {
            MemberType = memberType;
        }

        private ImplementationContractPropertyAttribute _contractPropertyAttribute;
        public ImplementationContractPropertyAttribute ContractContractPropertyAttribute
        {
            get { return _contractPropertyAttribute; }
            set
            {
                if (value != null)
                {
                    if (value.DefaultValue != null)
                    {
                        DefaultValue = value.DefaultValue;
                    }
                }

                _contractPropertyAttribute = value;
            }
        }

        public Type MemberType { get; private set; }
        public TypeMetaInfo MemberTypeMetaInfo { get; set; }
        public bool HasDefaultValue => DefaultValue != null;
        public object DefaultValue { get; private set; }

        public Type DefaultValueType => DefaultValue?.GetType();
        public bool DefaultValueIsArray => DefaultValueType?.GetElementType().IsArray ?? false;
        public Type DefaultValueElementType => DefaultValueIsArray ? DefaultValueType.GetElementType() : null;
        public Member Member { get; set; }
        public bool IsInheritedMember { get; set; }
        public bool IsNestedType { get; set; }
        public bool IsEnum => MemberType.IsEnum;
        public bool IsGuid => MemberType == typeof (Guid);
        public bool IsDateTime => MemberType == typeof(DateTime);
        public bool IsArray => MemberType.IsArray;
        public Type ArrayElementType => IsArray ? DefaultValueType.GetElementType() : null;
        public bool IsCollection { get; set; }
        public bool IsGenericCollection { get; set; }
        public Type GenericTypeParameter { get; set; }

        public override string ToString()
        {
            return Member.Name;
        }
    }
}
