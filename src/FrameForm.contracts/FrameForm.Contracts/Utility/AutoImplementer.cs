using System;
using System.Data;
using FrameForm.AutoImplement.Interface;
using FrameForm.AutoImplement.Model;

namespace FrameForm.AutoImplement.Utility
{
    public sealed class AutoImplementer : IAutoImplementer
    {
        #region Constructors

        private AutoImplementer()
        {
            
        }

        #endregion

        #region Private Fields

        private static AutoImplementer _instance;
        private static readonly object InstanceLock = new object();

        #endregion

        #region Public Methods

        public static IAutoImplementer GetFulfiller()
        {
            if (_instance == null)
            {
                lock (InstanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new AutoImplementer();
                    }
                }
            }

            return _instance;
        }

        internal static ContractValidationResult ValidateContract<T>()
            where T : class 
        {
            throw new NotImplementedException();
        }

        #endregion
}

    }