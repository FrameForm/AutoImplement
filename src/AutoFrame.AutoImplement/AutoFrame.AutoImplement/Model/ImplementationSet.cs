using System;
using System.Collections.Generic;

namespace AutoFrame.AutoImplement.Model
{
    internal class ImplementationSet
    {
        internal ImplementationSet(Type interfaceType)
        {
            InterfaceType = interfaceType;
            KeyedImplementedTypes = new Dictionary<string, List<Type>>();
            NonKeyedImplementedTypes = new HashSet<Type>();
        }
        
        public Type InterfaceType { get; private set; }

        public Dictionary<string, List<Type>> KeyedImplementedTypes { get; } 

        public HashSet<Type> NonKeyedImplementedTypes { get; } 

        public PropertyMappingSetCollection PropertyMappings { get; private set; }

        public void AddImplementedType(Type implementation, string memberSetKey = null)
        {
            if (memberSetKey == null)
            {
                if (!NonKeyedImplementedTypes.Contains(implementation))
                {
                    NonKeyedImplementedTypes.Add(implementation);
                }
                else
                {
                    NonKeyedImplementedTypes.Add(implementation);
                }
            }
            else
            {
                if (!KeyedImplementedTypes.ContainsKey(memberSetKey))
                {
                    KeyedImplementedTypes.Add(memberSetKey, new List<Type>());
                    KeyedImplementedTypes[memberSetKey].Add(implementation);
                }
                else
                {
                    KeyedImplementedTypes[memberSetKey].Add(implementation);
                }
            }
        }

        public void AddPropertyMappings(PropertyMappingSetCollection propertyMappings)
        {
            PropertyMappings = propertyMappings;
        }
    }
}
