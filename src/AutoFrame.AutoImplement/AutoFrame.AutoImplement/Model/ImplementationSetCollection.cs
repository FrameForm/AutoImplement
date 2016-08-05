using System;
using System.Collections.Generic;

namespace AutoFrame.AutoImplement.Model
{
    /// <summary>
    /// 
    /// </summary>
    internal class ImplementationSetCollection
    {
        #region Private Fields

        private readonly Dictionary<Type, ImplementationSet> _implementationsByType = new Dictionary<Type, ImplementationSet>();

        #endregion

        #region Public Methods

        public bool HasBeenImplemented(Type interfaceType)
        {
            return _implementationsByType.ContainsKey(interfaceType);
        }

        public void AddImplementationSet(Type interfaceType, ImplementationSet set, bool updateIfExisting)
        {
            if (!_implementationsByType.ContainsKey(interfaceType))
            {
                _implementationsByType.Add(interfaceType, set);
            }
            else if (updateIfExisting)
            {
                _implementationsByType[interfaceType] = set;
            }
        }

        public ImplementationSet GetImplementationSet(Type interfaceType)
        {
            return _implementationsByType[interfaceType];
        }

        #endregion
    }
}
