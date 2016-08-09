using System.Collections.Generic;

namespace AutoFrame.AutoImplement.Model
{
    internal class PropertyMappingSet
    {
        public PropertyMappingSet(string memberSetKey)
        {
            if (memberSetKey == null)
            {
                memberSetKey = string.Empty;
            }

            MemberSetKey = memberSetKey;

            Mappings = new List<PropertyMapping>();
        }

        public List<PropertyMapping> Mappings { get; }

        public string MemberSetKey { get; private set; }
    }
}
