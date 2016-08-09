using System;

namespace AutoFrame.AutoImplement.Attribute
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class AutoImplementIndexerAttribute : System.Attribute
    {
        public AutoImplementIndexerAttribute(params object[] indexerValues)
        {
            
        }

        public AutoImplementIndexerAttribute(string memberSetKey, params object[] indexerValues)
        {

        }
    }
}
