using FrameForm.Contracts.Attribute;
using FrameForm.Contracts.Model;

namespace FrameForm.Contracts.Extension
{
    public static class ContractExtensions
    {
        public static bool IsValid(this FulfillmentContract fc)
        {
            return false;
        }

        public static ContractValidationResult Validate(this FulfillmentContract fc)
        {
            return new ContractValidationResult();
        }
    }
}
