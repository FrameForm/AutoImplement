namespace AutoFrame.AutoImplement.Test.Resource
{
    public interface IBasicInterface
    {
        int GetIntMethod();

        int GetIntPropGetSet { get; set; }

        int GetIntPropGet { get; }

        int GetIntPropSet { set; }
    }

}
