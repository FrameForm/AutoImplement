using System;
using System.Collections.Generic;
using System.Data;

namespace FrameForm.AutoImplement.Test.Resource
{
    public interface ITestInterface
    {
        int MyGetSetIntProperty { get; set; }

        string MyGetStringProperty { get; }

        bool MySetBoolProperty { set; }

        event EventHandler MyEventHandler;

        List<Guid> MyGuidGetSetListProp { get; set; } 

        IEnumerable<IDataRecord> MyIEnumerableIDataRecordProp { get; set; }

        IDictionary<string, object> MyDictStringObjectGetProp { get; }

        int MyIntMethod1ParamString(string param1);

        int MyIntMethod3ParamStringStringString(string param1, string param2, string param3);

        int MyIntMethodArgsParamString(params string[] paramsN);


    }
    
}
