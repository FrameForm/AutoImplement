using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace FrameForm.AutoImplement.Utility
{
    internal class ImplementationBuilder
    {
        #region Constructors

        static ImplementationBuilder()
        {
            var assembly = new AssemblyName("FrameForm.AutoImplement.Generated");
            var assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
            ModuleBuilder = assemblyBuilder.DefineDynamicModule("AutoImplementModule");
        }

        #endregion

        #region Private Fields

        private static readonly ModuleBuilder ModuleBuilder;

        #endregion

        #region Internal Methods

        internal Type BuildImplementation(Type interfaceType)
        {
            var typeBuilder = ModuleBuilder.DefineType($"{interfaceType.Name}_Generated",
                TypeAttributes.Class);
            
            var propMethods = new HashSet<string>();
            foreach (var property in interfaceType.GetProperties())
            {
                if (property.CanRead)
                {
                    propMethods.Add($"get_{property.Name}");
                }
                if (property.CanWrite)
                {
                    propMethods.Add($"set_{property.Name}");
                }

                BuildProperty(typeBuilder, property);
            }
            

            var methods = interfaceType.GetMethods();
            foreach (var method in methods.Where(method => !propMethods.Contains(method.Name)))
            {
                BuildMethod(typeBuilder, method);
            }

            foreach (var mEvent in interfaceType.GetEvents())
            {
                BuildEvent(typeBuilder, mEvent);
            }
            
            typeBuilder.AddInterfaceImplementation(interfaceType);

            return typeBuilder.CreateType();
        }

        #endregion

        #region Private Methods

        private void BuildProperty(TypeBuilder typeBuilder, PropertyInfo property)
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

        private void BuildMethod(TypeBuilder typeBuilder, MethodInfo method)
        {
            var returnParam = method.ReturnType;
            var methodBuilder = typeBuilder.DefineMethod(method.Name, 
                MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.NewSlot,
                method.CallingConvention, returnParam,
                method.GetParameters().Select(param => param.ParameterType).ToArray());
            
            var methodIl = methodBuilder.GetILGenerator();

            if (returnParam != typeof (void))
            {
                methodIl.DeclareLocal(returnParam, true);

                if (returnParam.IsValueType)
                {
                    methodIl.Emit(OpCodes.Ldc_I4_0);
                    methodIl.Emit(OpCodes.Stloc_0);
                    methodIl.Emit(OpCodes.Ldloc_0);
                    methodIl.Emit(OpCodes.Ret);
                }
                else
                {
                    methodIl.Emit(OpCodes.Ldnull);
                    methodIl.Emit(OpCodes.Stloc_0);
                    methodIl.Emit(OpCodes.Ldloc_0);
                    methodIl.Emit(OpCodes.Ret);
                }
            }
            else
            {
                methodIl.Emit(OpCodes.Ret);
            }

        }

        private void BuildEvent(TypeBuilder typeBuilder, EventInfo myEvent)
        {
            typeBuilder.DefineEvent(myEvent.Name, EventAttributes.None, myEvent.EventHandlerType);
        }

        private void BuildGenericTypeParameters(TypeBuilder typeBuilder, string[] names)
        {

        }

        #endregion
    }
}
