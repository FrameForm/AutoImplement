using System;
using System.Linq;
using System.Reflection;
using AutoFrame.AutoImplement.Attribute;

namespace AutoFrame.AutoImplement.Extension
{
    internal static class DefaultValueExtensions
    {
        public static AutoImplementInterfaceAttribute ExtractAutoImplementAttribute(this Type type)
        {
            return (AutoImplementInterfaceAttribute)type.GetCustomAttribute(typeof (AutoImplementInterfaceAttribute));
        }

        public static AutoImplementPropertyAttribute[] ExtractAutoImplementAttributes(this PropertyInfo property)
        {
            return property.GetCustomAttributes(typeof(AutoImplementPropertyAttribute)).Cast<AutoImplementPropertyAttribute>().ToArray();
        }

        public static AutoImplementMethodAttribute[] ExtractAutoImplementAttributes(this MethodInfo method)
        {
            return method.GetCustomAttributes(typeof(AutoImplementMethodAttribute)).Cast<AutoImplementMethodAttribute>().ToArray();
        }

        public static AutoImplementEventAttribute[] ExtractAutoImplementAttributes(this EventInfo _event)
        {
            return _event.GetCustomAttributes(typeof(AutoImplementEventAttribute)).Cast<AutoImplementEventAttribute>().ToArray();
        }

        public static bool IsCastableTo(this Type from, Type to)
        {
            if (from == to)
            {
                return true;
            }
            if (to.IsAssignableFrom(from))
            {
                return true;
            }
            var methods = from.GetMethods(BindingFlags.Public | BindingFlags.Static)
                              .Where(
                                  m => m.ReturnType == to &&
                                       (m.Name == "op_Implicit" ||
                                        m.Name == "op_Explicit")
                              );
            return methods.Any();
        }
    }
}
