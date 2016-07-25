namespace FrameForm.AutoImplement.Test.Resource
{
    interface IBasicInterface<T>
        where T: new()
    {
        T GetTMethod();

        T GetTPropGetSet { get; set; }

        T GetTPropGet { get; }

        T GetTPropSet { set; }

        T this[int T] { get; set; }
    }
}
