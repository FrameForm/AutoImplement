using System.Collections.Generic;

namespace AutoFrame.AutoImplement.Model
{
    internal class PropertyMappingSetCollection
    {
        #region Private Fields

        private readonly Dictionary<string, PropertyMappingSet> _propertyMappingsByKey = new Dictionary<string, PropertyMappingSet>();

        #endregion

        #region Public Properties

        public IEnumerable<string> AvailableMemberSetKeys => _propertyMappingsByKey.Keys;

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

            if (_propertyMappingsByKey.ContainsKey(memberSetKey))
            {
                return _propertyMappingsByKey[memberSetKey];
            }

            return null;
        }

        #endregion
    }
}
