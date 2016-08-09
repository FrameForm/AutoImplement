using System;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Exceptions;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Model;
using AutoFrame.AutoImplement.Utility.Mapper.Random;
using FastMember;

namespace AutoFrame.AutoImplement.Utility.Mapper.Property
{
    internal class MultipleDefaultValuePropertyMapper : RandomElementSelector, IPropertyAttributeMapper
    {
        public PropertyMapping BuildPropertyMapping(AutoImplementPropertyAttribute propertyAttribute, Type propertyType, Type interfaceType, string propertyName)
        {
            if (!propertyAttribute.DefaultValueType.IsCastableTo(propertyType))
            {
                throw new InvalidPropertyDefaultTypeException(interfaceType, propertyName,
                    propertyType, propertyAttribute.DefaultValue, propertyAttribute.DefaultValueType);
            }

            var action = new Action<TypeAccessor, object>((typeAccessor, instance) =>
            {
                var index = RandomGenerator.Next(0, (propertyAttribute.ProvidedValues.Length - 1));

                typeAccessor[instance, propertyName] = propertyAttribute.ProvidedValues[index];
            });

            var mapping = propertyAttribute.IsKeyed ? new PropertyMapping(propertyAttribute.MemberSetKey, action) : new PropertyMapping(action);

            return mapping;
        }
    }
}
