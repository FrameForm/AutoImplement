using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Model;
using AutoFrame.AutoImplement.Utility.Implementer;
using AutoFrame.AutoImplement.Utility.Mapper;

namespace AutoFrame.AutoImplement.Utility
{
    internal class ImplementationSetCreator
    {
        #region Constructors

        static ImplementationSetCreator()
        {
            var assembly = new AssemblyName("FrameForm.AutoImplement.Generated");
            var assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);
            ModuleBuilder = assemblyBuilder.DefineDynamicModule("AutoImplementModule");
        }

        #endregion

        #region Private Fields

        private static readonly ModuleBuilder ModuleBuilder;
        private static readonly MemberImplementer MemberImplementer = new MemberImplementer();
        private static readonly MemberMapper MemberMapper = new MemberMapper();

        #endregion

        #region Internal Methods

        public ImplementationSet CreateImplementationSet<T>()
            where T : class 
        {
            var interfaceType = typeof (T);
            
            var set = new ImplementationSet(interfaceType);
            
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

                MemberImplementer.PropertyImplementationStrategy.ImplementProperty(typeBuilder, property);

                var mappingCollection = MemberMapper.PropertyMapper.PreparePropertyMappings(interfaceType, property);
                set.PropertyMappingsCollections.Add(mappingCollection);
            }
            
            var methods = interfaceType.GetMethods();

            foreach (var method in methods.Where(method => !propMethods.Contains(method.Name)))
            {
                MemberImplementer.MethodImplementationStrategy.ImplementMethod(typeBuilder, method);
            }

            foreach (var mEvent in interfaceType.GetEvents())
            {
                MemberImplementer.EventImplementationStrategy.ImplementEvent(typeBuilder, mEvent);
            }
            
            typeBuilder.AddInterfaceImplementation(interfaceType);

            set.AddImplementedType(typeBuilder.CreateType());

            return set;
        }

        #endregion

    }
}
