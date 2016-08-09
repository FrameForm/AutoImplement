using System;

namespace AutoFrame.AutoImplement.Exceptions
{
    public class DuplicateMemberSetKeyException : Exception
    {
        internal DuplicateMemberSetKeyException(string[] providedMemberSetKeys, string[] duplicateKeys) :
            base($"Cannot define duplicate MemberSetKeys. The duplicate keys " +
                 $"[{string.Join(", ", duplicateKeys)}] exist in the provided set " +
                 $"[{string.Join(",", providedMemberSetKeys)}].")
        {
            ProvidedMemberSetKeys = providedMemberSetKeys;
            DuplicateKeys = duplicateKeys;
        }

        public string[] ProvidedMemberSetKeys { get; }

        public string[] DuplicateKeys { get; }
    }
}
