using System;
using System.Reflection;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Model;
using AutoFrame.AutoImplement.Utility.Mapper.Property;

namespace AutoFrame.AutoImplement.Utility.Mapper
{
    internal class PropertyMapperStrategy
    {
        #region Private Fields

        private readonly SingleDefaultValuePropertyMapper _singleDefaultValuePropertyMapper = new SingleDefaultValuePropertyMapper();

        private readonly MultipleDefaultValuePropertyMapper _multipleDefaultValuePropertyMapper = new MultipleDefaultValuePropertyMapper();

        #endregion

        #region Public Methods

        public PropertyMappingSetCollection PreparePropertyMappings(Type interfaceType, PropertyInfo property)
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
                results.AddPropertyMappingSet(propertyAttribute.MemberSetKey, set, false);
            }

            return results;
        }

        #endregion

        #region Private Methods

        private IPropertyAttributeMapper GetAttributeMapper(AutoImplementPropertyAttribute attribute)
        {

            if (attribute.HasExplicitValue)
            {
                return _singleDefaultValuePropertyMapper;
            }
            else if (attribute.HasProvidedValueRange)
            {
                return _multipleDefaultValuePropertyMapper;
            }
            else
            { 
                throw new NotImplementedException();
            }
            
        }

        #endregion
    }
}
