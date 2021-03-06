﻿using System.Collections.Generic;

namespace AutoFrame.AutoImplement.Test.Resource.Basic
{
    internal interface IGenericCollectionInterface<T>
    {
        IEnumerable<T> IEnumerableColl { get; set; }
        Dictionary<T, object> DictionaryColl { get; set; }
        HashSet<T> HashSetColl { get; set; }
        LinkedList<T> LinkedListColl { get; set; }
        List<T> ListColl { get; set; }
        Queue<T> QueueColl { get; set; }
        SortedDictionary<T, object> SortedDictionaryColl { get; set; }
        SortedList<T, object> SortedListColl { get; set; }
        SortedSet<T> SortedSetColl { get; set; }
        Stack<T> StackColl { get; set; }
    }
}
