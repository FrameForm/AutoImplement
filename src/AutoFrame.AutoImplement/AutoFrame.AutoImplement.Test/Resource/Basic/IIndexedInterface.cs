using System.Collections.Generic;

namespace AutoFrame.AutoImplement.Test.Resource.Basic
{
    public interface IIndexedInterface
    {
        List<int> TList { get; set; }

        void Add(int value);

        int this[int val] { get; set; }
    }

    class IndexedInterface : IIndexedInterface
    {
        public List<int> TList { get; set; }
        public void Add(int value)
        {
        }

        public int this[int val]
        {
            get { return default(int); }
            set {  }
        }
    }
}
