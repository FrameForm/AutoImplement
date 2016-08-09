using System;
using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Implementer.Property
{
    internal class DefaultPropertyImplementer : IPropertyImplementer
    {
        public void BuildProperty(TypeBuilder typeBuilder, PropertyInfo property)
        {
            var field = typeBuilder.DefineField("m" + property.Name, property.PropertyType, FieldAttributes.Private);
            var propertyBuilder = typeBuilder.DefineProperty(property.Name, PropertyAttributes.None, property.PropertyType, null);

            var getSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig |
                             MethodAttributes.SpecialName | MethodAttributes.Virtual;

            if (property.CanRead)
            {
                var getter = typeBuilder.DefineMethod("get_" + property.Name, getSetAttr, property.PropertyType, Type.EmptyTypes);

                var getIl = getter.GetILGenerator();
                getIl.Emit(OpCodes.Ldarg_0);
                getIl.Emit(OpCodes.Ldfld, field);
                getIl.Emit(OpCodes.Ret);

                propertyBuilder.SetGetMethod(getter);
            }
            if (property.CanWrite)
            {
                var setter = typeBuilder.DefineMethod("set_" + property.Name, getSetAttr, null, new Type[] { property.PropertyType });

                var setIl = setter.GetILGenerator();
                setIl.Emit(OpCodes.Ldarg_0);
                setIl.Emit(OpCodes.Ldarg_1);
                setIl.Emit(OpCodes.Stfld, field);
                setIl.Emit(OpCodes.Ret);

                propertyBuilder.SetSetMethod(setter);
            }
        }

    }
}
