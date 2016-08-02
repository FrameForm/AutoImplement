using System.Collections.Generic;
using System.Data;

namespace AutoFrame.AutoImplement.Test.Resource.Basic
{
    interface IEnumInterface
    {
        IEnumerable<int> IntEnum { get; set; } 

        IEnumerable<IDataRecord> DataRecordEnum { get; set; } 

        IEnumerable<IEnumerable<IEnumerable<IDataRecord>>>  NestedDataRecordEnum { get; set; }
    }
}
