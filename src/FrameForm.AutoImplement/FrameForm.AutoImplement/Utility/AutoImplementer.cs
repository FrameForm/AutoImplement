using System;
using System.Collections.Generic;
using System.Linq;
using FrameForm.AutoImplement.Interface;

namespace FrameForm.AutoImplement.Utility
{
    public sealed class AutoImplementer : IAutoImplementer
    {
        #region Constructors

        private AutoImplementer()
        {

        }

        #endregion

        #region Private Fields

        private static AutoImplementer _instance;
        private static readonly object InstanceLock = new object();
        private static readonly ImplementationBuilder Builder = new ImplementationBuilder();

        private static readonly Dictionary<Type, Type> TypeDictionary = new Dictionary<Type, Type>();

        #endregion

        #region Internal Methods

        internal static void ResetInstance()
        {
            _instance = null;
        }

        #endregion


        #region Public Methods

        public static IAutoImplementer GetImplementer()
        {
            if (_instance == null)
            {
                lock (InstanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new AutoImplementer();
                    }
                }
            }

            return _instance;
        }

        public T Implement<T>()
            where T: class
        {
            Type implementation;
            var providedType = typeof (T);

            if (!providedType.IsPublic)
            {
                throw new NotSupportedException("Interface must be public.");
            }
            

            if (!TypeDictionary.ContainsKey(providedType))
            {
                lock (InstanceLock)
                {
                    if (!TypeDictionary.ContainsKey(providedType))
                    {
                        implementation = Builder.BuildImplementation(providedType);

                        TypeDictionary.Add(providedType, implementation);
                    }
                    else
                    {
                        implementation = TypeDictionary[providedType];
                    }
                }
            }
            else
            {
                implementation = TypeDictionary[providedType];
            }

            return Activator.CreateInstance(implementation) as T;

        }


        #endregion
    }

}