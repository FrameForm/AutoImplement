namespace AutoFrame.AutoImplement.Test.Resource
{
    interface IParamsOverloadInterface
    {
        void ParamMethod(int param1);

        void ParamMethod(int param1, int param2);

        void ParamMethod(params int[] paramArray);

        void ParamMethod(int param1, params int[] paramArray);
    }

    class ParamsOverloadInterface : IParamsOverloadInterface
    {
        public void ParamMethod(int param1)
        {
        }

        public void ParamMethod(int param1, int param2)
        {
        }

        public void ParamMethod(params int[] paramArray)
        {
        }

        public void ParamMethod(int param1, params int[] paramArray)
        {
        }
    }
}
