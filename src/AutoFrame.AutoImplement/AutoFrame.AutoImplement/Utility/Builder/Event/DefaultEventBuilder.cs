using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Builder.Event
{
    internal class DefaultEventBuilder : IEventBuilder
    {
        public void BuildEvent(TypeBuilder typeBuilder, EventInfo myEvent)
        {
            typeBuilder.DefineEvent(myEvent.Name, EventAttributes.None, myEvent.EventHandlerType);
        }
    }
}
