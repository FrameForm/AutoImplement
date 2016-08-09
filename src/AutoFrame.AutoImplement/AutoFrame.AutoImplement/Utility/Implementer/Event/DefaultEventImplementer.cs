using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Implementer.Event
{
    internal class DefaultEventImplementer : IEventImplementer
    {
        public void BuildEvent(TypeBuilder typeBuilder, EventInfo myEvent)
        {
            typeBuilder.DefineEvent(myEvent.Name, EventAttributes.None, myEvent.EventHandlerType);
        }
    }
}
