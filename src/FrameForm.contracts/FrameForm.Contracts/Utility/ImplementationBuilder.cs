using System;
using System.Reflection;
using System.Reflection.Emit;

namespace FrameForm.AutoImplement.Utility
{
    class ImplementationBuilder
    {
        private static void BuildProperty(TypeBuilder typeBuilder, string name, Type type, bool get = true, bool set = true)
        {
            var field = typeBuilder.DefineField("m" + name, type, FieldAttributes.Private);
            var propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.None, type, null);

            var getSetAttr = MethodAttributes.Public | MethodAttributes.HideBySig |
                             MethodAttributes.SpecialName | MethodAttributes.Virtual;

            if (get)
            {
                var getter = typeBuilder.DefineMethod("get_" + name, getSetAttr, type, Type.EmptyTypes);

                var getIL = getter.GetILGenerator();
                getIL.Emit(OpCodes.Ldarg_0);
                getIL.Emit(OpCodes.Ldfld, field);
                getIL.Emit(OpCodes.Ret);

                propertyBuilder.SetGetMethod(getter);
            }
            if (set)
            {
                var setter = typeBuilder.DefineMethod("set_" + name, getSetAttr, null, new Type[] { type });

                var setIL = setter.GetILGenerator();
                setIL.Emit(OpCodes.Ldarg_0);
                setIL.Emit(OpCodes.Ldarg_1);
                setIL.Emit(OpCodes.Stfld, field);
                setIL.Emit(OpCodes.Ret);

                propertyBuilder.SetSetMethod(setter);
            }
        }

        private static void BuildMethod(TypeBuilder typeBuilder, string name, bool varArgs)
        {
            var methodBuilder = typeBuilder.DefineMethod(name, MethodAttributes.Public, 
                varArgs ? CallingConventions.HasThis | CallingConventions.VarArgs : CallingConventions.HasThis);

        
            //methodBuilder.Create
        }

        private static void BuildEvent(TypeBuilder typeBuilder, string name, Type type)
        {
            var eventBuilder = typeBuilder.DefineEvent(name, EventAttributes.None, type);

            var eventAtt = MethodAttributes.Public;

        }
    }
}
