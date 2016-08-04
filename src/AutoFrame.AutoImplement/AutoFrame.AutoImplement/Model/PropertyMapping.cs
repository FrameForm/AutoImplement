using System;
using FastMember;

namespace AutoFrame.AutoImplement.Model
{
    public class PropertyMapping
    {
        public PropertyMapping(string memberSetKey, Action<TypeAccessor, object> propertyAssignment)
        {
            MemberSetKey = memberSetKey;
            PropertyAssignment = propertyAssignment;
        }

        public string MemberSetKey { get; private set; }

        public Action<TypeAccessor, object> PropertyAssignment { get; private set; }
    }
}
