using System;
using System.Net;
using AutoFrame.AutoImplement.Exceptions;
using AutoFrame.AutoImplement.Test.Resource.Basic;
using AutoFrame.AutoImplement.Test.Resource.Defaults;
using AutoFrame.AutoImplement.Utility;
using NUnit.Framework;

namespace AutoFrame.AutoImplement.Test.Utility
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

        [Test]
        public void Test_IBasicDefaultInterface()
        {
            IBasicDefaultInterface instance = _implementer.Implement<IBasicDefaultInterface>();

            instance.GuidProp = Guid.NewGuid();

            Assert.AreNotEqual(instance.GuidProp, default(Guid));
            Assert.AreEqual(instance.IntProp, 10);
            Assert.AreEqual(instance.StringProp, "hello");
        }

        [Test]
        public void Test_IBasicDateTimeInterface()
        {
            IBasicDateTimeInterface instance = _implementer.Implement<IBasicDateTimeInterface>();

            Assert.AreEqual(instance.DateTimeProp1, new DateTime(2016, 1, 1));
            Assert.AreEqual(instance.DateTimeProp2, new DateTime(2017,1,1,12,0,0));
        }

        [Test]
        public void Test_IBasicSetInterface()
        {
            IBasicSetInterface instance0 = _implementer.Implement<IBasicSetInterface>();
            Assert.AreEqual(instance0.PropertyBoolTrueFalse, false);
            Assert.AreEqual(instance0.PropertyCharAlphabet, default(char));
            Assert.AreEqual(instance0.PropertyIntBy10, 0);
            Assert.AreEqual(instance0.PropertyStringAlphabet, null);

            IBasicSetInterface instance1 = _implementer.Implement<IBasicSetInterface>("Set1");
            Assert.AreEqual(instance1.PropertyBoolTrueFalse, true);
            Assert.AreEqual(instance1.PropertyCharAlphabet, 'a');
            Assert.AreEqual(instance1.PropertyIntBy10, 10);
            Assert.AreEqual(instance1.PropertyStringAlphabet, "A");

            IBasicSetInterface instance2 = _implementer.Implement<IBasicSetInterface>("Set2");
            Assert.AreEqual(instance2.PropertyBoolTrueFalse, false);
            Assert.AreEqual(instance2.PropertyCharAlphabet, 'b');
            Assert.AreEqual(instance2.PropertyIntBy10, 20);
            Assert.AreEqual(instance2.PropertyStringAlphabet, "AB");

            IBasicSetInterface instance3 = _implementer.Implement<IBasicSetInterface>("Set3");
            Assert.AreEqual(instance3.PropertyBoolTrueFalse, true);
            Assert.AreEqual(instance3.PropertyCharAlphabet, 'c');
            Assert.AreEqual(instance3.PropertyIntBy10, 30);
            Assert.AreEqual(instance3.PropertyStringAlphabet, "ABC");

            IBasicSetInterface instance4 = _implementer.Implement<IBasicSetInterface>("Set4");
            Assert.AreEqual(instance4.PropertyBoolTrueFalse, false);
            Assert.AreEqual(instance4.PropertyCharAlphabet, 'd');
            Assert.AreEqual(instance4.PropertyIntBy10, 40);
            Assert.AreEqual(instance4.PropertyStringAlphabet, "ABCD");

            Assert.Throws<InvalidMemberSetKeyException>(() => _implementer.Implement<IBasicSetInterface>("invalidSet"));
        }

        [Test]
        public void Test_INullableSetInterface()
        {
            INullableSetInterface instance0 = _implementer.Implement<INullableSetInterface>();
            Assert.AreEqual(instance0.PropertyBoolTrueFalse, null);
            Assert.AreEqual(instance0.PropertyCharAlphabet, null);
            Assert.AreEqual(instance0.PropertyIntBy10, null);

            INullableSetInterface instance1 = _implementer.Implement<INullableSetInterface>("Set1");
            Assert.AreEqual(instance1.PropertyBoolTrueFalse, true);
            Assert.AreEqual(instance1.PropertyCharAlphabet, 'a');
            Assert.AreEqual(instance1.PropertyIntBy10, 10);

            INullableSetInterface instance2 = _implementer.Implement<INullableSetInterface>("Set2");
            Assert.AreEqual(instance2.PropertyBoolTrueFalse, false);
            Assert.AreEqual(instance2.PropertyCharAlphabet, 'b');
            Assert.AreEqual(instance2.PropertyIntBy10, 20);

            INullableSetInterface instance3 = _implementer.Implement<INullableSetInterface>("Set3");
            Assert.AreEqual(instance3.PropertyBoolTrueFalse, true);
            Assert.AreEqual(instance3.PropertyCharAlphabet, 'c');
            Assert.AreEqual(instance3.PropertyIntBy10, 30);

            INullableSetInterface instance4 = _implementer.Implement<INullableSetInterface>("Set4");
            Assert.AreEqual(instance4.PropertyBoolTrueFalse, false);
            Assert.AreEqual(instance4.PropertyCharAlphabet, 'd');
            Assert.AreEqual(instance4.PropertyIntBy10, 40);

            Assert.Throws<InvalidMemberSetKeyException>(() => _implementer.Implement<INullableSetInterface>("invalidSet"));
        }
    }
}
