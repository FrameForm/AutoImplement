using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Builder.Method
{
    internal class DefaultMethodBuilder : IMethodBuilder
    {
        public void BuildMethod(TypeBuilder typeBuilder, MethodInfo method)
        {
            var returnParam = method.ReturnParameter;
            var parameters = method.GetParameters();
            var methodBuilder = typeBuilder.DefineMethod(method.Name,
                MethodAttributes.Public | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.NewSlot,
                method.CallingConvention, returnParam.ParameterType, parameters.Select(param => param.ParameterType).ToArray());

            if (method.IsGenericMethodDefinition)
            {
                var genericArguments = method.GetGenericArguments();

                var paramBuilders = methodBuilder.DefineGenericParameters(genericArguments.Select(arg => arg.Name).ToArray());

                for (var i = 0; i < genericArguments.Length; i++)
                {
                    paramBuilders[0].SetGenericParameterAttributes(genericArguments[0].GenericParameterAttributes);
                }
            }
            var methodIl = methodBuilder.GetILGenerator();

            if (returnParam.ParameterType != typeof(void))
            {
                methodIl.DeclareLocal(returnParam.ParameterType, true);

                if (returnParam.ParameterType.ContainsGenericParameters)
                {
                    methodIl.Emit(OpCodes.Ldloca_S);
                    methodIl.Emit(OpCodes.Initobj, returnParam.ParameterType);
                    methodIl.Emit(OpCodes.Ldloc_0);
                    methodIl.Emit(OpCodes.Stloc_0);
                    methodIl.Emit(OpCodes.Ldloc_1);
                    methodIl.Emit(OpCodes.Ret);
                }
                else if (returnParam.ParameterType.IsValueType)
                {
                    methodIl.Emit(OpCodes.Ldc_I4_0);
                    methodIl.Emit(OpCodes.Stloc_0);
                    methodIl.Emit(OpCodes.Ldloc_0);
                    methodIl.Emit(OpCodes.Ret);
                }
                else
                {
                    methodIl.Emit(OpCodes.Ldnull);
                    methodIl.Emit(OpCodes.Stloc_0);
                    methodIl.Emit(OpCodes.Ldloc_0);
                    methodIl.Emit(OpCodes.Ret);
                }
            }
            else
            {
                methodIl.Emit(OpCodes.Ret);
            }
        }

    }
}
