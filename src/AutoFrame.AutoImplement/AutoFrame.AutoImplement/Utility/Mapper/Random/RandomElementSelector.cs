namespace AutoFrame.AutoImplement.Utility.Mapper.Random
{
    public abstract class RandomElementSelector
    {
        protected RandomElementSelector()
        {
        }

        protected static readonly System.Random RandomGenerator = new System.Random();
    }
}
