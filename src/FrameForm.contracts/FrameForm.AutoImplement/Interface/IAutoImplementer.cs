namespace FrameForm.AutoImplement.Interface
{
    public interface IAutoImplementer
    {
        T Implement<T>()
            where T: class;
    }
}
