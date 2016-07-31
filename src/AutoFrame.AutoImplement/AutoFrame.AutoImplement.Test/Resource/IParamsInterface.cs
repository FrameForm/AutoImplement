namespace AutoFrame.AutoImplement.Test.Resource
{
    interface IParamsInterface
    {
        void Param1Method(int param1);

        void Param2Method(int param1, int param2);

        void ParamArrayMethod(params int[] paramArray);

        void Param2ArrayMethod(int param1, params int[] paramArray);
    }

    class ParamsInterface : IParamsInterface
    {
        public void Param1Method(int param1)
        {
        }

        public void Param2Method(int param1, int param2)
        {
        }

        public void ParamArrayMethod(params int[] paramArray)
        {
        }

        public void Param2ArrayMethod(int param1, params int[] paramArray)
        {
        }
    }
}
