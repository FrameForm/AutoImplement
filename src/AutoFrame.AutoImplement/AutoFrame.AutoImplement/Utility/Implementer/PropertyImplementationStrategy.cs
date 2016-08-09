using System.Reflection;
using System.Reflection.Emit;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Utility.Implementer.Property;

namespace AutoFrame.AutoImplement.Utility.Implementer
{
    internal class PropertyImplementationStrategy
    {
        #region Private Fields
        
        private readonly DefaultPropertyImplementer _defaultPropertyImplementer = new DefaultPropertyImplementer();

        #endregion

        #region Public Methods

        public void ImplementProperty(TypeBuilder typeBuilder, PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.ExtractAutoImplementAttributes();

            var implementer = GetPropertyImplementer(attributes.Length == 0 ? null : attributes[0]);

            implementer.BuildProperty(typeBuilder, propertyInfo);
        }

        #endregion

        #region Private Methods
        
        private IPropertyImplementer GetPropertyImplementer(AutoImplementPropertyAttribute attribute)
        {
            if (attribute == null)
            {
                return _defaultPropertyImplementer;
            }
            else
            {
                return _defaultPropertyImplementer;
            }
        }

        #endregion
    }
}
