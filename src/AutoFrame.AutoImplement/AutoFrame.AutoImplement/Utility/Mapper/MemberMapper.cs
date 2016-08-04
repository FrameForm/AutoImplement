using AutoFrame.AutoImplement.Utility.Mapper.Property;

namespace AutoFrame.AutoImplement.Utility.Mapper
{
    internal class MemberMapper
    {
        public MemberMapper(IPropertyMapper propertyMapper)
        {
            PropertyMapper = propertyMapper;
        }

        public IPropertyMapper PropertyMapper { get; private set; }
    }
}
