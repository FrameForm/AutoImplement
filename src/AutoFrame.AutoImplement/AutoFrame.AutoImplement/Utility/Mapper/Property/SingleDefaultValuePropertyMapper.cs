using System;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Exceptions;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Model;

namespace AutoFrame.AutoImplement.Utility.Mapper.Property
{
    public class SingleDefaultValuePropertyMapper : IPropertyAttributeMapper
    {
        public PropertyMapping BuildPropertyMapping(AutoImplementPropertyAttribute propertyAttribute, Type propertyType, Type interfaceType, string propertyName)
        {
            if (!propertyAttribute.DefaultValueType.IsCastableTo(propertyType))
            {
                throw new InvalidPropertyDefaultTypeException(interfaceType, propertyName,
                    propertyType, propertyAttribute.DefaultValue, propertyAttribute.DefaultValueType);
            }

            PropertyMapping mapping;

            if (propertyAttribute.IsKeyed)
            {
                mapping = new PropertyMapping(propertyAttribute.MemberSetKey,
                    ((typeAccessor, instance) => typeAccessor[instance, propertyName] = propertyAttribute.DefaultValue));
            }
            else
            {
                mapping = new PropertyMapping(((typeAccessor, instance) => 
                typeAccessor[instance, propertyName] = propertyAttribute.DefaultValue));

            }

            return mapping;
        }
    }
}
