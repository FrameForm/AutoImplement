using System;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Utility.Builder.Event;
using AutoFrame.AutoImplement.Utility.Builder.Method;
using AutoFrame.AutoImplement.Utility.Builder.Property;

namespace AutoFrame.AutoImplement.Utility.Builder
{
    internal class MemberBuilder
    {
        public IEventBuilder GetEventBuilder(AutoImplementEventAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public IPropertyBuilder GetPropertyBuilder(AutoImplementPropertyAttribute attribute)
        {
            throw new NotImplementedException();
        }

        public IMethodBuilder GetEventBuilder(AutoImplementMethodAttribute attribute)
        {
            throw new NotImplementedException();
        }
    }
}
