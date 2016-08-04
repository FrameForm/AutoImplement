using AutoFrame.AutoImplement.Utility.Builder.Event;
using AutoFrame.AutoImplement.Utility.Builder.Method;
using AutoFrame.AutoImplement.Utility.Builder.Property;

namespace AutoFrame.AutoImplement.Utility.Builder
{
    internal class MemberBuilder
    {
        public MemberBuilder(IEventBuilder eventBuilder, IMethodBuilder methodBuilder, IPropertyBuilder propertyBuilder)
        {
            EventBuilder = eventBuilder;
            MethodBuilder = methodBuilder;
            PropertyBuilder = propertyBuilder;
        }

        public IEventBuilder EventBuilder { get; private set; }

        public IMethodBuilder MethodBuilder { get; private set; }

        public IPropertyBuilder PropertyBuilder { get; private set; }
    }
}
