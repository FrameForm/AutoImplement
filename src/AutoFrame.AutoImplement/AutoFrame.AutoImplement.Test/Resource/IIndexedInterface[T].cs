using System.Collections.Generic;

namespace AutoFrame.AutoImplement.Test.Resource
{
    interface IIndexedInterface<T>
        where T: new()
    {
        List<T> TList { get; set;  }

        void Add(T value);

        T this[int T] { get; set; }
    }

    class IndexedInterface<T> : IIndexedInterface<T> where T : new()
    {
        public List<T> TList { get; set; }
        public void Add(T value)
        {
        }

        public T this[int T]
        {
            get { return default(T); }
            set {  }
        }
    }
}
