using System;
using System.Collections.Generic;

namespace FrameForm.AutoImplement.Model
{
    internal class TypeMetaInfo
    {
        internal TypeMetaInfo(Type type)
        {
            FulfillingType = type;
            Members = new List<MemberMetaInfo>();
            CustomAttributes = new List<System.Attribute>();
        }

        public Type FulfillingType { get; private set; }
        public List<System.Attribute> CustomAttributes { get; set; }
        public List<MemberMetaInfo> Members { get; set; }
        public bool HasNestedTypes { get; set; }
    }
}
