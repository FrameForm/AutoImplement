namespace AutoFrame.AutoImplement.Utility.Mapper
{
    internal class MemberMapper
    {
        public MemberMapper(PropertyValueMapper propertyMapper)
        {
            PropertyMapper = propertyMapper;
        }

        public PropertyValueMapper PropertyMapper { get; private set; }
    }
}
