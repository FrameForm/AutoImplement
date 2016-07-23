using System;

namespace FrameForm.Contracts.Attribute
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class FulfillmentContract : System.Attribute, IEquatable<FulfillmentContract>
    {
        public FulfillmentContract(string contractKey)
        {
            ContractKey = contractKey;
        }
        
        public string ContractKey { get; set; }

        public bool Equals(FulfillmentContract other)
        {
            return string.Equals(ContractKey, other.ContractKey, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
