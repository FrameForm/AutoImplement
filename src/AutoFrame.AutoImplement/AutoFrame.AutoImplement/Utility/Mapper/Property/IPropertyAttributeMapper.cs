using System;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Model;

namespace AutoFrame.AutoImplement.Utility.Mapper.Property
{
    internal interface IPropertyAttributeMapper
    {
        PropertyMapping BuildPropertyMapping(AutoImplementPropertyAttribute propertyAttribute, Type propertyType,
            Type interfaceType, string propertyName);
    }
}
