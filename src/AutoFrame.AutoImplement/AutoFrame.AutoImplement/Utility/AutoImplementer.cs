using System;
using System.Collections.Generic;
using AutoFrame.AutoImplement.Model;

namespace AutoFrame.AutoImplement.Utility
{
    /// <summary>
    /// Extracts metadata about interfaces and uses it to build a type that fulfills the interface, and instantiate it.
    /// </summary>
    public sealed class AutoImplementer : IAutoImplementer
    {
        #region Constructors

        private AutoImplementer()
        {

        }

        #endregion

        #region Private Fields

        private static AutoImplementer _instance;
        private static IAutoImplementer _injected;
        private static readonly object InstanceLock = new object();
        private static readonly ImplementationSetCreator Implementer = new ImplementationSetCreator();
        private static readonly ImplementationSetCollection Implementations = new ImplementationSetCollection();
        

        #endregion

        #region Internal Methods
        /// <summary>
        /// Used for testing to ensure a new instance is created each test.
        /// </summary>
        internal static void ResetInstance()
        {
            _instance = null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Can be used to inject a mock <see cref="IAutoImplementer"/> for testing.
        /// </summary>
        /// <param name="instance"></param>
        public static void Inject(IAutoImplementer instance)
        {
            _injected = instance;
        }

        /// <summary>
        /// Returns a singleton instance of IAutoImplementer.  
        /// If an instance has been injeced via <see cref="Inject"/> then that instance will be returned.
        /// </summary>
        /// <returns>An <see cref="IAutoImplementer"/>.</returns>
        public static IAutoImplementer GetImplementer()
        {
            if (_injected != null)
            {
                return _injected;
            }

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

        public T Implement<T>(string memberSetKey = null)
            where T: class
        {
            var providedType = typeof (T);

            if (!providedType.IsPublic)
            {
                throw new NotSupportedException("Interface must be public.");
            }


            var implementationSet = GetImplementationSet<T>(providedType);

            //var instance =  Activator.CreateInstance(implementation) as T;

        }


        #endregion

        #region Private Methods

        private ImplementationSet GetImplementationSet<T>(Type providedType)
            where T : class
        {

            ImplementationSet implementationSet;

            if (!Implementations.HasBeenImplemented(providedType))
            {
                lock (InstanceLock)
                {
                    if (!Implementations.HasBeenImplemented(providedType))
                    {
                        implementationSet = Implementer.CreateImplementationSet<T>();

                        Implementations.AddImplementationSet(providedType, implementationSet, true);
                    }
                    else
                    {
                        implementationSet = Implementations.GetImplementationSet(providedType);
                    }
                }
            }
            else
            {

                implementationSet = Implementations.GetImplementationSet(providedType);
            }

            return implementationSet;
        }

        #endregion
    }

}