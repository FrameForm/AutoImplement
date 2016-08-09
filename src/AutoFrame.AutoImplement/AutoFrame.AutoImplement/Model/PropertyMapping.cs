using System;
using FastMember;

namespace AutoFrame.AutoImplement.Model
{
    public class PropertyMapping
    {
        public PropertyMapping(Action<TypeAccessor, object> propertyAssignment)
        {
            PropertyAssignment = propertyAssignment;
        }

        public PropertyMapping(string memberSetKey, Action<TypeAccessor, object> propertyAssignment)
        {
            MemberSetKey = memberSetKey;
            PropertyAssignment = propertyAssignment;
        }

        public bool HasMemberSetKey => MemberSetKey != null;

        public string MemberSetKey { get; private set; }

        public Action<TypeAccessor, object> PropertyAssignment { get; private set; }
    }
}
