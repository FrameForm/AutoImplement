namespace AutoFrame.AutoImplement.Test.Resource.Basic
{
    public interface IGenericMethodInterface
    {
        T GetTMethod<T>();

        T SetTMethod<T>(T value);

        T1 SetT1T2T3Method<T1, T2, T3>(T1 t1, T2 t2, T3 t3);
    }

    class GenericMethodInterface : IGenericMethodInterface
    {
        public T GetTMethod<T>()
        {
            return default(T);
        }

        public T SetTMethod<T>(T value)
        {
            return default(T);
        }

        public T1 SetT1T2T3Method<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return default(T1);
        }
    }
}
