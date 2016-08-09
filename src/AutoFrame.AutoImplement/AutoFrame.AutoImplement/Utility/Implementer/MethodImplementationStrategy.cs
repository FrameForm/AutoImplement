using System.Reflection;
using System.Reflection.Emit;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Utility.Implementer.Method;

namespace AutoFrame.AutoImplement.Utility.Implementer
{
    internal class MethodImplementationStrategy
    {
        #region Private Fields
        
        private readonly DefaultMethodImplementer _defaultMethodImplementer = new DefaultMethodImplementer();

        #endregion

        #region Public Methods

        public void ImplementMethod(TypeBuilder typeBuilder, MethodInfo methodInfo)
        {
            var attributes = methodInfo.ExtractAutoImplementAttributes();

            var implementer = GetMethodImplementer(attributes.Length == 0 ? null : attributes[0]);

            implementer.BuildMethod(typeBuilder, methodInfo);
        }

        #endregion

        #region Private Methods

        private IMethodImplementer GetMethodImplementer(AutoImplementMethodAttribute attribute)
        {
            return _defaultMethodImplementer;
        }

        #endregion
    }
}
