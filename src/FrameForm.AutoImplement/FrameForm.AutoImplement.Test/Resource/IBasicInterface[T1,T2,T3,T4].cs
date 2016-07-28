namespace FrameForm.AutoImplement.Test.Resource
{
    public interface IBasicInterface<out T1,T2,T3, in T4>
        where T1: new()
        where T2: struct
        where T3: new()
        where T4: struct
    {
        T1 GetT1Method();

        T2 T2PropGetSet { get; set; }

        T3 T3PropGetSet { get; set; }

        T4 T4PropSet { set; }

        T1 SetMethod(T2 t2, T3 t3, T4 t4);
    }
}
