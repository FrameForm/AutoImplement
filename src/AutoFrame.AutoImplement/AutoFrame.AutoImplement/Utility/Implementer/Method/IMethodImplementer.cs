using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Implementer.Method
{
    internal interface IMethodImplementer
    {
        void BuildMethod(TypeBuilder typeBuilder, MethodInfo method);
    }
}