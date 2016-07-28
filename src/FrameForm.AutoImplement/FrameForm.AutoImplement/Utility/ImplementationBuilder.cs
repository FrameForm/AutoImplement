using System;
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
            var parameters = method.GetParameters().Select(param => param.ParameterType).ToArray();
            var methodBuilder = typeBuilder.DefineMethod(method.Name, 
                MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.NewSlot,
                method.CallingConvention);

            if (method.IsGenericMethod)
            {
                var genArgs = method.GetGenericArguments();

                var genBuilders = methodBuilder.DefineGenericParameters(genArgs.Select(arg => arg.Name).ToArray());

                for (var genArgIndex = 0; genArgIndex < genArgs.Length; genArgIndex++)
                {
                    genBuilders[genArgIndex].SetGenericParameterAttributes(genArgs[genArgIndex].GenericParameterAttributes);
                }

                methodBuilder.MakeGenericMethod(genBuilders);

                if (parameters.Length > 0)
                {
                    List<Type> methodParams = new List<Type>();
                    foreach (var param in parameters)
                    {
                        if (param.IsGenericParameter)
                        {
                            methodParams.Add(genBuilders.First(genBuilder => genBuilder.Name == param.Name));
                        }
                        else
                        {
                            methodParams.Add(param);
                        }
                    }

                    methodBuilder.SetParameters(methodParams.ToArray());
                }
                methodBuilder.SetReturnType(genBuilders.First(genBuilder => genBuilder.Name == returnParam.Name));
            }
            else
            {
                methodBuilder.SetParameters(parameters);
                methodBuilder.SetReturnType(returnParam);
            }
            
            var methodIl = methodBuilder.GetILGenerator();

            if (returnParam != typeof (void))
            {
                methodIl.DeclareLocal(returnParam, false);

                if (returnParam.ContainsGenericParameters)
                {
                    methodIl.DeclareLocal(returnParam, false);
                    methodIl.Emit(OpCodes.Ldloca_S);
                    methodIl.Emit(OpCodes.Initobj, returnParam);
                    methodIl.Emit(OpCodes.Ldloc_0);
                    methodIl.Emit(OpCodes.Stloc_0);
                    methodIl.Emit(OpCodes.Ldloc_1);
                    methodIl.Emit(OpCodes.Ret);
                }
                else if (returnParam.IsValueType)
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


        #endregion
    }
}
