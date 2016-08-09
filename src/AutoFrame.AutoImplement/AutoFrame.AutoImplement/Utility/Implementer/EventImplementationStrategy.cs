using System.Reflection;
using System.Reflection.Emit;
using AutoFrame.AutoImplement.Attribute;
using AutoFrame.AutoImplement.Extension;
using AutoFrame.AutoImplement.Utility.Implementer.Event;

namespace AutoFrame.AutoImplement.Utility.Implementer
{
    internal class EventImplementationStrategy
    {
        #region Private Fields
        
        private readonly DefaultEventImplementer _defaultEventImplementer = new DefaultEventImplementer();

        #endregion

        #region Public Methods

        public void ImplementEvent(TypeBuilder typeBuilder, EventInfo eventInfo)
        {
            var attributes = eventInfo.ExtractAutoImplementAttributes();

            var implementer = GetEventImplementer(attributes.Length == 0 ? null : attributes[0]);

            implementer.BuildEvent(typeBuilder, eventInfo);
        }

        #endregion

        #region Private Methods

        private IEventImplementer GetEventImplementer(AutoImplementEventAttribute attribute)
        {
            return _defaultEventImplementer;
        }

        #endregion
    }
}
