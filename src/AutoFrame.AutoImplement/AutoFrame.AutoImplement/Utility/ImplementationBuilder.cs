using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Exceptions;
using AutoFrame.AutoImplement.Extension;
using FastMember;

namespace AutoFrame.AutoImplement.Utility
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

        internal Type BuildImplementation(Type interfaceType, string memberSetKey = null)
        {
            var typeBuilder = ModuleBuilder.DefineType($"{interfaceType.Name}_Generated",
                TypeAttributes.Class);


            var interfaceAttribute = interfaceType.ExtractAutoImplementAttribute();

            var hasDefinedPropertySet = false;

            if (interfaceAttribute != null && interfaceAttribute.MemberSetKeys.Count > 0 & memberSetKey != null)
            {
                if (!interfaceAttribute.MemberSetKeys.Contains(memberSetKey))
                {
                    throw new InvalidMemberSetKeyException(memberSetKey, interfaceAttribute.MemberSetKeys.ToArray(), interfaceType);
                }

                hasDefinedPropertySet = true;
            }


            TypeAccessor typeAccessor = null;  
            
            var propMethods = new HashSet<string>();
            var propertyAssignments = new List<Action<object>>();

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

                MapProperty(interfaceType, typeAccessor, property, memberSetKey, hasDefinedPropertySet,
                    interfaceAttribute, propertyAssignments);
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

        private void MapProperty(Type interfaceType, TypeAccessor typeAccessor, PropertyInfo property,
            string memberSetKey, bool hasDefinedPropertySet, AutoImplementInterfaceAttribute interfaceAttribute,
            List<Action<object>> propertyAssignments)
        {
            var propertyAttributes = property.ExtractAutoImplementAttributes();

            if (propertyAttributes.Length == 0)
            {
                return;
            }
            
            if (typeAccessor == null)
            {
                typeAccessor = TypeAccessor.Create(interfaceType);
            }

            if (propertyAttributes.Length == 1)
            {
                var attribute = propertyAttributes[0];

                if (hasDefinedPropertySet)
                {
                    if ((attribute.PropertySetName == null || attribute.PropertySetName != memberSetKey)
                        && !interfaceAttribute.AllowUnmappedMembers)
                    {
                        throw new UnmappedMemberException(interfaceType, memberSetKey, property.Name);
                    }
                }
                else
                {
                    if (attribute.DefaultValueType.IsCastableTo(property.PropertyType))
                    {
                        propertyAssignments.Add((obj => typeAccessor[obj, property.Name] = attribute.DefaultValue));
                    }
                    else
                    {
                        throw new InvalidPropertyDefaultTypeException(interfaceType, property.Name,
                            property.PropertyType, attribute.DefaultValue, attribute.DefaultValueType);
                    }
                }
            }
            else
            {
                AutoImplementPropertyAttribute attribute;

                if (hasDefinedPropertySet)
                {
                    foreach (var propertyAttribute in propertyAttributes)
                    {
                        //todo finish loop and assignment
                    }
                }
            }
            
        }
        private void BuildMethod(TypeBuilder typeBuilder, MethodInfo method)
        {
            var returnParam = method.ReturnParameter;
            var parameters = method.GetParameters();
            var methodBuilder = typeBuilder.DefineMethod(method.Name, 
                MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.NewSlot,
                method.CallingConvention, returnParam.ParameterType, parameters.Select(param => param.ParameterType).ToArray());

            if (method.IsGenericMethodDefinition)
            {
                var genericArguments = method.GetGenericArguments();

                var paramBuilders = methodBuilder.DefineGenericParameters(genericArguments.Select(arg => arg.Name).ToArray());

                for (var i = 0; i < genericArguments.Length; i++)
                {
                    paramBuilders[0].SetGenericParameterAttributes(genericArguments[0].GenericParameterAttributes);
                }
            }
            var methodIl = methodBuilder.GetILGenerator();

            if (returnParam.ParameterType != typeof (void))
            {
                methodIl.DeclareLocal(returnParam.ParameterType, true);

                if (returnParam.ParameterType.ContainsGenericParameters)
                {
                    methodIl.Emit(OpCodes.Ldloca_S);
                    methodIl.Emit(OpCodes.Initobj, returnParam.ParameterType);
                    methodIl.Emit(OpCodes.Ldloc_0);
                    methodIl.Emit(OpCodes.Stloc_0);
                    methodIl.Emit(OpCodes.Ldloc_1);
                    methodIl.Emit(OpCodes.Ret);
                }
                else if (returnParam.ParameterType.IsValueType)
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
