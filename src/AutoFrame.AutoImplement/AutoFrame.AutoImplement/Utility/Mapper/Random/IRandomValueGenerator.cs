namespace AutoFrame.AutoImplement.Utility.Mapper.Property.Random
{
    public interface IRandomValueGenerator<out T>
    {
        T GenerateValue(long seed);
    }
}
