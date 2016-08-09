using System.Reflection;
using System.Reflection.Emit;

namespace AutoFrame.AutoImplement.Utility.Implementer.Event
{
    internal interface IEventImplementer
    {
        void BuildEvent(TypeBuilder typeBuilder, EventInfo myEvent);
    }
}