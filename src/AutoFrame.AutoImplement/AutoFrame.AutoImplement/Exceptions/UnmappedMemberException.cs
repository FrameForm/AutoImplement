using System;

namespace AutoFrame.AutoImplement.Exceptions
{
    public class UnmappedMemberException : Exception
    {
        internal UnmappedMemberException(Type interfaceType, string memberSetKey, string memberName)
            : base($"Unable to map member [{memberName}] witin type [{interfaceType.Name}] using member set [{memberSetKey}].")
        {
            InterfaceType = interfaceType;
            MemberSetKey = MemberSetKey;
            MemberName = memberName;
        }

        Type InterfaceType { get; }

        string MemberSetKey { get; }

        string MemberName { get; }
    }
}
