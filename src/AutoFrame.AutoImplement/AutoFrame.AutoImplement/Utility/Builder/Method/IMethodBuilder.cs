using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Builder.Method
{
    internal interface IMethodBuilder
    {
        void BuildMethod(TypeBuilder typeBuilder, MethodInfo method);
    }
}