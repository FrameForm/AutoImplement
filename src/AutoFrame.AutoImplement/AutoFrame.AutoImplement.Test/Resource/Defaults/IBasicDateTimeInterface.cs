using System;
using AutoFrame.AutoImplement.Attribute;

namespace AutoFrame.AutoImplement.Test.Resource.Defaults
{
    public interface IBasicDateTimeInterface
    {
        [AutoImplementDateTimeProperty(2016,01,01)]
        DateTime DateTimeProp1 { get; set; }

        [AutoImplementDateTimeProperty(2017,01,01,12,0,0)]
        string DateTimeProp2 { get; set; }


    }
}
