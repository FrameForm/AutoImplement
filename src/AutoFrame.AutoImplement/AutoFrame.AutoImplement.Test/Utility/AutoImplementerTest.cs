using System;
using System.Net;
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
            IBasicInterface<NetworkCredential> instance = _implementer.Implement<IBasicInterface<NetworkCredential>>();

            var cred = new NetworkCredential("adsf", "asdf");
            var cred2 = new NetworkCredential("adsfj", "asdfj");

            instance.GetTPropGetSet = cred;
            instance.GetTPropSet = cred2;

            Assert.AreEqual(cred, instance.GetTPropGetSet);
            Assert.AreEqual(default(NetworkCredential), instance.GetTMethod());
            Assert.AreEqual(default(NetworkCredential), instance.GetTPropGet);
        }

        [Test]
        public void Test_IBasicInterfaceT1T2T3T4()
        {
            IBasicInterface<int, char, bool, double> instance =
                _implementer.Implement<IBasicInterface<int, char, bool, double>>();

            instance.T2PropGetSet = 'a';
            instance.T3PropGetSet = true;

            Assert.AreEqual(instance.GetT1Method(), 0);
            Assert.AreEqual(instance.T2PropGetSet, 'a');
            Assert.AreEqual(instance.T3PropGetSet, true);
            Assert.AreEqual(instance.SetMethod('z',false,913432), 0);
        }


        [Test]
        public void Test_IGenericMethodInterface()
        {
            IGenericMethodInterface instance = _implementer.Implement<IGenericMethodInterface>();

            instance.SetTMethod(0);
            instance.SetTMethod(false);
            instance.SetTMethod(Guid.Empty);
            instance.SetTMethod(instance);

            Assert.AreEqual(instance.GetTMethod<int>(), 0);
            Assert.AreEqual(instance.GetTMethod<bool>(), false);
            Assert.AreEqual(instance.GetTMethod<string>(), null);
            Assert.AreEqual(instance.GetTMethod<IGenericMethodInterface>(), null);

            Assert.AreEqual(instance.SetT1T2T3Method(9999, false, Guid.Empty), 0);
            Assert.AreEqual(instance.SetT1T2T3Method(false, Guid.Empty, 9999), false);
            Assert.AreEqual(instance.SetT1T2T3Method(Guid.Empty, 9999, false), default(Guid));
        }
    }
}
