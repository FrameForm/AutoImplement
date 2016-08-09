using System;
using AutoFrame.AutoImplement.Attribute;

namespace AutoFrame.AutoImplement.Test.Resource.Defaults
{
    public interface IBasicDefaultInterface
    {
        [AutoImplementProperty(10)]
        int IntProp { get; set; }

        [AutoImplementProperty("hello")]
        string StringProp { get; set; }
        
        Guid GuidProp { get; set; }


    }
}
