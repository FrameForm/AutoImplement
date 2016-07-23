using System;

namespace FrameForm.Contracts.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FulfillmentContractProperty : System.Attribute
    {
        public FulfillmentContractProperty()
        {
        }

        public FulfillmentContractProperty(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
        
        internal object DefaultValue { get; private set; }
    }
}