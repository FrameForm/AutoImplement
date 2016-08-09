using AutoFrame.AutoImplement.Attribute;

namespace AutoFrame.AutoImplement.Test.Resource.Defaults
{
    [AutoImplementInterface(allowUnmappedMembers: true, memberSetKeys: new [] { "Set1", "Set2", "Set3", "Set4"})]
    public interface IBasicSetInterface
    {
        [AutoImplementProperty("Set1", 10)]
        [AutoImplementProperty("Set2", 20)]
        [AutoImplementProperty("Set3", 30)]
        [AutoImplementProperty("Set4", 40)]
        int PropertyIntBy10 { get; set; }

        [AutoImplementProperty("Set1", true)]
        [AutoImplementProperty("Set2", false)]
        [AutoImplementProperty("Set3", true)]
        [AutoImplementProperty("Set4", false)]
        bool PropertyBoolTrueFalse { get; set; }

        [AutoImplementProperty("Set1", "A")]
        [AutoImplementProperty("Set2", "AB")]
        [AutoImplementProperty("Set3", "ABC")]
        [AutoImplementProperty("Set4", "ABCD")]
        string PropertyStringAlphabet { get; set; }

        [AutoImplementProperty("Set1", 'a')]
        [AutoImplementProperty("Set2", 'b')]
        [AutoImplementProperty("Set3", 'c')]
        [AutoImplementProperty("Set4", 'd')]
        char PropertyCharAlphabet { get; set; }
        
    }
}
