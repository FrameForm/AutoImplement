using System;
using System.Reflection;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Model;
using AutoFrame.AutoImplement.Utility.Mapper.Property;

namespace AutoFrame.AutoImplement.Utility.Mapper
{
    internal class PropertyValueMapper
    {

        private readonly SingleDefaultValuePropertyMapper _singleDefaultValuePropertyMapper
            = new SingleDefaultValuePropertyMapper();

        public PropertyMappingSetCollection MapPropertyValues(Type interfaceType, PropertyInfo property)
        {
            var results = new PropertyMappingSetCollection();
            
            var propertyAttributes = property.ExtractAutoImplementAttributes();

            foreach (var propertyAttribute in propertyAttributes)
            {

                PropertyMappingSet set;

                var mapper = GetAttributeMapper(propertyAttribute);

                var mapping = mapper.BuildPropertyMapping(propertyAttribute, property.PropertyType,
                    interfaceType, property.Name);

                if (!results.HasMemberSetKey(propertyAttribute.MemberSetKey))
                {
                    set = new PropertyMappingSet(propertyAttribute.MemberSetKey);
                }
                else
                {
                    set = results.GetPropertyMappingSet(propertyAttribute.MemberSetKey);
                }

                set.Mappings.Add(mapping);
            }

            return results;
        }

        private IPropertyAttributeMapper GetAttributeMapper(AutoImplementPropertyAttribute attribute)
        {

            if (attribute.HasExplicitValue)
            {
                return _singleDefaultValuePropertyMapper;
            }
            throw new NotImplementedException();
        }
    }
}
