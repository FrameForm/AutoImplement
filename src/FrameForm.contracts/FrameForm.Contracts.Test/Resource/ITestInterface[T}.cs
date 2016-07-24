using System;
using System.Collections.Generic;
using System.Data;

namespace FrameForm.AutoImplement.Test.Resource
{
    public interface ITestInterface<T>
    {
        int MyGetSetIntProperty { get; set; }

        T MyGetTProperty { get; }

        bool MySetBoolProperty { set; }

        event EventHandler MyEventHandler;

        List<Guid> MyGuidGetSetListProp { get; set; } 

        IEnumerable<IDataRecord> MyIEnumerableIDataRecordProp { get; set; }

        IDictionary<T, object> MyDictStringObjectGetProp { get; }

        int MyIntMethod1ParamString(T param1);

        int MyIntMethod3ParamStringStringString(T param1, T param2, T param3);

        int MyIntMethodArgsParamString(params T[] paramsN);


    }
    
}
