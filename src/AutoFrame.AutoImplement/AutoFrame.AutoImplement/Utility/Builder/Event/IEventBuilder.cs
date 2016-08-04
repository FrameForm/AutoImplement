using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Builder.Event
{
    internal interface IEventBuilder
    {
        void BuildEvent(TypeBuilder typeBuilder, EventInfo myEvent);
    }
}