using System;
using System.Collections.Generic;
using System.Linq;
using AutoFrame.AutoImplement.Exceptions;

namespace AutoFrame.AutoImplement.Attribute
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class AutoImplementInterfaceAttribute : System.Attribute
    {
        public AutoImplementInterfaceAttribute(bool allowUnmappedMembers, params string[] memberSetKeys)
        {
            AllowUnmappedMembers = allowUnmappedMembers;

            MemberSetKeys = new HashSet<string>();
            var duplicateKeys = new List<string>();
            foreach (var memberSetKey in memberSetKeys)
            {
                if (MemberSetKeys.Contains(memberSetKey))
                {
                    duplicateKeys.Add(memberSetKey);
                }
                else
                {
                    MemberSetKeys.Add(memberSetKey);
                }
            }

            if (duplicateKeys.Any())
            {
                throw new DuplicateMemberSetKeyException(memberSetKeys, duplicateKeys.ToArray());
            }
        }

        public bool AllowUnmappedMembers { get; }

        public HashSet<string> MemberSetKeys { get; }
    }
}
