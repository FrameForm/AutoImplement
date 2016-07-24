using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using FastMember;
using FrameForm.AutoImplement.Extension;
using FrameForm.AutoImplement.Model;

namespace FrameForm.AutoImplement.Utility
{
    internal class TypeMetaExtractor
    {
        #region Static Constructor

        static TypeMetaExtractor()
        {
            var assembly = new AssemblyName("FrameForm.AutoImplement.Generated");
            var assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
            ModuleBuilder = assemblyBuilder.DefineDynamicModule("AutoImplementModule");
        }

        #endregion

        #region Private Static Fields

        private static readonly Dictionary<Type, TypeMetaInfo> StoredTypes =
            new Dictionary<Type, TypeMetaInfo>();

        private static readonly ModuleBuilder ModuleBuilder;
        private static readonly object SyncLock = new object();

        #endregion

        #region Internal Static Methods

        internal static TypeMetaInfo ExtractTypeMetaInformation(Type interfaceType)
        {
            TypeMetaInfo typeInfo;

            if (!StoredTypes.ContainsKey(interfaceType))
            {
                if (!interfaceType.IsInterface)
                    throw new ArgumentException("Can only fulfill the contract of an interface!", nameof(interfaceType));

                typeInfo = RegisterInterface(interfaceType);
            }
            else
            {
                typeInfo = StoredTypes[interfaceType];
            }

            return typeInfo;
        }
        
        #endregion

        #region Private Static Methods

        private static TypeMetaInfo RegisterInterface(Type interfaceType)
        {
            List<PropertyInfo> interfaceProperties = interfaceType.GetProperties().ToList();
            var methods = interfaceType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                                   BindingFlags.NonPublic).Where(m => !m.IsSpecialName).ToArray();

            var baseInterfaces = interfaceType.GetInterfaces();

            foreach (var baseInterface in baseInterfaces)
            {
                interfaceProperties.AddRange(baseInterface.GetProperties());
            }

            interfaceProperties = interfaceProperties.Distinct(new PropComparer()).ToList();
            
            // ensure we are only accessing our module builder from one thread at a time.  Note: the lock allows our recursive call.
            lock (SyncLock)
            {
                // double check that no other thread got here first
                if (StoredTypes.ContainsKey(interfaceType))
                {
                    return StoredTypes[interfaceType];
                }

                var typeBuilder = ModuleBuilder.DefineType(string.Format("{0}Proxy", interfaceType.Name),
                    TypeAttributes.Class);
                typeBuilder.AddInterfaceImplementation(interfaceType);
                var hasNestedTypes = false;

                foreach (var interfaceProperty in interfaceProperties)
                {
                    // register any types contained within, but make sure not to accidentally
                    // register any system interfaces.
                    if (interfaceProperty.PropertyType.IsInterface
                        && !interfaceProperty.PropertyType.Assembly.GlobalAssemblyCache
                        && !interfaceProperty.PropertyType.IsCOMObject)
                    {
                        hasNestedTypes = true;

                        if (!StoredTypes.ContainsKey(interfaceProperty.PropertyType))
                        {
                            RegisterInterface(interfaceProperty.PropertyType);
                        }
                    }
                }

                var newType = typeBuilder.CreateType();

                var typeInformation = new TypeMetaInfo(newType) { HasNestedTypes = hasNestedTypes };

                StoredTypes.CheckedAdd(interfaceType, typeInformation, SyncLock);

                return typeInformation;
            }
        }

        private static List<MemberMetaInfo> GetMembers(Type declaringType, MemberSet members,
            PropertyInfo[] propertyInfos, bool isInterface)
        {
            var memberInformationCollection = new List<MemberMetaInfo>();

            foreach (var member in members)
            {
                var relevantPropertyInfo = propertyInfos.FirstOrDefault(info => string.Equals(info.Name, member.Name));

                var memberInformation = new MemberMetaInfo(member.Type);

                object[] attributes;
                object[] dateTimeAttributes = new object[0];

                if (relevantPropertyInfo != null)
                {
                    if (typeof(ICollection).IsAssignableFrom(relevantPropertyInfo.PropertyType)
                        || relevantPropertyInfo.PropertyType.Namespace.Equals("System.Collections.Generic"))
                    {
                        memberInformation.IsCollection = true;

                        if (relevantPropertyInfo.PropertyType.IsConstructedGenericType)
                        {
                            var args = relevantPropertyInfo.PropertyType.GenericTypeArguments;
                            if (args.Length != 1)
                            {
                                throw new Exception(
                                    "Can only support generic type with one generic parameter.  Mark with an IgnoreProperty.");
                            }

                            memberInformation.IsGenericCollection = true;
                            var genericType = args[0];

                            if (!genericType.IsValueType && !genericType.FullName.Equals("System.String") && !genericType.IsEnum && genericType != typeof(DateTime))
                            {
                                throw new Exception(
                                    "Can only support generic type if the type paramter is a value type (or String), enum, or DateTime.  Mark with an IgnoreProperty.");
                            }

                            memberInformation.GenericTypeParameter = genericType;
                        }
                    }
                    else if (relevantPropertyInfo.PropertyType.ContainsGenericParameters)
                    {
                        throw new Exception("Cannot support unrealized generic types.  Mark with an IgnoreProperty.");
                    }
                }
                else
                {
                    attributes = new object[0];
                }

                memberInformation.Member = member;

                memberInformationCollection.Add(memberInformation);
            }

            return memberInformationCollection;
        }

        #endregion

        #region Private Nested Types

        private class PropComparer : IEqualityComparer<PropertyInfo>
        {
            public bool Equals(PropertyInfo x, PropertyInfo y)
            {
                return x.Name.Equals(y.Name);
            }

            public int GetHashCode(PropertyInfo obj)
            {
                return obj.Name.GetHashCode();
            }
        }

        #endregion
    }
}
