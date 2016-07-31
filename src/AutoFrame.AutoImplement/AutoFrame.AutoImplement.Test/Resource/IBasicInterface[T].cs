namespace AutoFrame.AutoImplement.Test.Resource
{
    public interface IBasicInterface<T>
        where T: new()
    {
        T GetTMethod();

        T GetTPropGetSet { get; set; }

        T GetTPropGet { get; }

        T GetTPropSet { set; }
    }
}
