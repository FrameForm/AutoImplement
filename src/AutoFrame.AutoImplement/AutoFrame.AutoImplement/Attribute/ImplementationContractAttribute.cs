using System;

namespace AutoFrame.AutoImplement.Attribute
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class ImplementationContractAttribute : System.Attribute, IEquatable<ImplementationContractAttribute>
    {
        public ImplementationContractAttribute(string contractKey)
        {
            ContractKey = contractKey;
        }
        
        public string ContractKey { get; set; }

        public bool Equals(ImplementationContractAttribute other)
        {
            return string.Equals(ContractKey, other.ContractKey, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
