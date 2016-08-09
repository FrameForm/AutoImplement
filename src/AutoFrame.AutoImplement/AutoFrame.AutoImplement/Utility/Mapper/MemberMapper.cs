namespace AutoFrame.AutoImplement.Utility.Mapper
{
    internal class MemberMapper
    {
        public MemberMapper()
        {
            PropertyMapper = new PropertyMapperStrategy();
        }

        public PropertyMapperStrategy PropertyMapper { get; }

    }
}
