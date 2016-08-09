using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoFrame.AutoImplement.Model
{
    internal class ImplementationSet
    {
        internal ImplementationSet(Type interfaceType)
        {
            InterfaceType = interfaceType;
            PropertyMappingsCollections = new List<PropertyMappingSetCollection>();
        }
        
        public Type InterfaceType { get; private set; }

        public Type Implementation { get; private set; }

        public List<PropertyMappingSetCollection> PropertyMappingsCollections { get; }

        public IEnumerable<string> AvailableMemberSetKeys
        {
            get { return PropertyMappingsCollections.SelectMany(map => map.AvailableMemberSetKeys).Distinct(); }
        }

        public void AddImplementedType(Type implementation)
        {
            Implementation = implementation;
        }
    }
}
