using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFrame.AutoImplement.Model
{
    /// <summary>
    /// 
    /// </summary>
    internal class PropertyMappingSetCollection
    {
        #region Private Fields

        private readonly Dictionary<string, PropertyMappingSet> _propertyMappingsByKey = new Dictionary<string, PropertyMappingSet>();

        #endregion

        #region Public Methods

        public bool HasMemberSetKey(string memberSetKey)
        {
            if (memberSetKey == null)
            {
                memberSetKey = string.Empty;
            }

            return _propertyMappingsByKey.ContainsKey(memberSetKey);
        }

        public void AddPropertyMappingSet(string memberSetKey, PropertyMappingSet set, bool updateIfExisting)
        {
            if (memberSetKey == null)
            {
                memberSetKey = string.Empty;
            }

            if (!_propertyMappingsByKey.ContainsKey(memberSetKey))
            {
                _propertyMappingsByKey.Add(memberSetKey, set);
            }
            else if (updateIfExisting)
            {
                _propertyMappingsByKey[memberSetKey] = set;
            }
        }

        public PropertyMappingSet GetPropertyMappingSet(string memberSetKey)
        {
            if (memberSetKey == null)
            {
                memberSetKey = string.Empty;
            }

            return _propertyMappingsByKey[memberSetKey];
        }

        #endregion
    }
}
