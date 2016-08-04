using System;
using System.Collections.Generic;
using System.Reflection;
using AutoFrame.AutoImplement.Exceptions;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Model;

namespace AutoFrame.AutoImplement.Utility.Mapper.Property
{
    internal class PropertyValueMapper : IPropertyMapper
    {
        public List<PropertyMapping> MapPropertyValues(Type interfaceType, PropertyInfo property)
        {
            var results = new List<PropertyMapping>();

            var propertyAttributes = property.ExtractAutoImplementAttributes();

            foreach (var propertyAttribute in propertyAttributes)
            {
                if (propertyAttribute.DefaultValueType.IsCastableTo(property.PropertyType))
                {
                    var result = new PropertyMapping(propertyAttribute.MemberSetKey,
                        ((typeAccessor, instance) => typeAccessor[instance, property.Name] = propertyAttribute.DefaultValue));

                    results.Add(result);
                }
                else
                {
                    throw new InvalidPropertyDefaultTypeException(interfaceType, property.Name,
                        property.PropertyType, propertyAttribute.DefaultValue, propertyAttribute.DefaultValueType);
                }
            }

            return results;
        }
    }
}
