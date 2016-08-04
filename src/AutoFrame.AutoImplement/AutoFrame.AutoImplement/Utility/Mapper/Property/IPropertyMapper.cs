using System;
using System.Collections.Generic;
using System.Reflection;
using AutoFrame.AutoImplement.Model;

namespace AutoFrame.AutoImplement.Utility.Mapper.Property
{
    internal interface IPropertyMapper
    {
        List<PropertyMapping> MapPropertyValues(Type interfaceType, PropertyInfo property);
    }
}