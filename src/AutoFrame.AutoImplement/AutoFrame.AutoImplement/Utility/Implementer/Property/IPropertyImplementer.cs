using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Implementer.Property
{
    internal interface IPropertyImplementer
    {
        void BuildProperty(TypeBuilder typeBuilder, PropertyInfo property);
    }
}