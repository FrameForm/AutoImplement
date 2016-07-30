using System.Collections;

namespace FrameForm.AutoImplement.Test.Resource
{
    interface ICollectionInterface
    {
        ArrayList ArrayListColl { get; set; }
        BitArray BitArrayColl { get; set; }
        CollectionBase CollectionBaseColl { get; set; }
        DictionaryBase DictionaryBaseColl { get; set; }
        Hashtable HashtableColl { get; set; }
        Queue QueueColl { get; set; }
        SortedList SortedListColl { get; set; }
        Stack StackColl { get; set; }
        ICollection ICollectionColl { get; set; }
        IDictionary IDictionaryColl { get; set; }
        IEnumerable IEnumerableColl { get; set; }
        IList IListColl { get; set; }
    }
}
