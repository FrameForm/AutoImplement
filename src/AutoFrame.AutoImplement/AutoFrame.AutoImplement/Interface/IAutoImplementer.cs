namespace AutoFrame.AutoImplement.Interface
{
    /// <summary>
    /// Provides basic access to automatically implement an interface.
    /// </summary>
    public interface IAutoImplementer
    {
        /// <summary>
        /// Implements the interface for <typeparamref name="T"/> and returns an instance.
        /// </summary>
        /// <typeparam name="T">The interface you wish to implement.</typeparam>
        /// <returns>A new instance of <typeparamref name="T"/></returns>
        T Implement<T>()
            where T: class;
    }
}
