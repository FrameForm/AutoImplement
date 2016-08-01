using System;

namespace AutoFrame.AutoImplement.Exceptions
{
    public class InvalidMemberSetKeyException : Exception
    {
        internal InvalidMemberSetKeyException(string memberSetKey, string[] availableValueSetKeys, Type interfaceType)
            : base($"Unable to utilize member set [{memberSetKey}] to implement type [{interfaceType.Name}] as it is not " +
                   $"defined within the types member set keys [{string.Join(", ", availableValueSetKeys)}].")
        {
            MemberSetKey = memberSetKey;
            AvailableValueSetKeys = availableValueSetKeys;
            InterfaceType = interfaceType;
        }

        public string MemberSetKey { get; }

        public string[] AvailableValueSetKeys { get; }

        public Type InterfaceType { get; }
    }
}
