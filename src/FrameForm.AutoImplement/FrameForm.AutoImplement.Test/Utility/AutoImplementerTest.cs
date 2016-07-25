using FrameForm.AutoImplement.Interface;
using FrameForm.AutoImplement.Test.Resource;
using FrameForm.AutoImplement.Utility;
using NUnit.Framework;

namespace FrameForm.AutoImplement.Test.Utility
{
    [TestFixture]
    class AutoImplementerTest
    {
        [SetUp]
        public void SetUp()
        {
            AutoImplementer.ResetInstance();
            _implementer = AutoImplementer.GetImplementer();

        }

        private IAutoImplementer _implementer;

        [Test]
        public void Test_IBasicInterface()
        {
            IBasicInterface instance = _implementer.Implement<IBasicInterface>();

            instance.GetIntPropGetSet = 10;
            instance.GetIntPropSet = 15;
            
            Assert.AreEqual(0, instance.GetIntPropGet);
            Assert.AreEqual(10, instance.GetIntPropGetSet);
            Assert.AreEqual(0, instance.GetIntMethod());

        }

        [Test]
        public void Test_IBasicInterfaceT()
        {
            
        }

        [Test]
        public void Test_ITestInterface()
        {
            
        }


        [Test]
        public void Test_ITestInterfaceT()
        {
            
        }
    }
}
