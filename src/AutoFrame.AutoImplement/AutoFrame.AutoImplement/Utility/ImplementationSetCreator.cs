using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using AutoFrame.AutoImplement.Model;

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

        #endregion

        #region Internal Methods

        public ImplementationSet CreateImplementationSet<T>()
            where T : class 
        {
            var interfaceType = typeof (T);

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

                //BuildProperty(typeBuilder, property);

                //var mappings = BuildPropertyMappings(interfaceType, property);
            }
            
            var methods = interfaceType.GetMethods();

            foreach (var method in methods.Where(method => !propMethods.Contains(method.Name)))
            {
                //BuildMethod(typeBuilder, method);
            }

            foreach (var mEvent in interfaceType.GetEvents())
            {
                //BuildEvent(typeBuilder, mEvent);
            }
            
            typeBuilder.AddInterfaceImplementation(interfaceType);
            

        }

        #endregion

    }
}
