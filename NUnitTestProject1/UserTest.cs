using CSharp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace NUnitTestProject1
{
    class UserTest
    {
        [Test]
        public void PassWordTest()
        {
            User lw = new User();


            //"abcdefghijklmnopqrstuvwxyz"
            //"ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            //"0123456789"
            //"~!@#$%^&*()_+"

            Assert.IsFalse(lw.PassWordHasAny("ABCD186%$", "abcdefghijklmnopqrstuvwxyz"));
            Assert.IsFalse(lw.PassWordHasAny("asd153$#", "ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            Assert.IsFalse(lw.PassWordHasAny("ASDasd@##", "0123456789"));
            Assert.IsFalse(lw.PassWordHasAny("adasdAD123", "~!@#$%^&*()_+"));

            Assert.IsTrue(lw.PassWordHasAny("a1234841", "abcdefghijklmnopqrstuvwxyz"));
            Assert.IsTrue(lw.PassWordHasAny("A18341", "ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            Assert.IsTrue(lw.PassWordHasAny("asdaASD1", "0123456789"));
            Assert.IsTrue(lw.PassWordHasAny("asdASD13$", "~!@#$%^&*()_+"));


            Assert.IsTrue(lw.PassWordCondition("asAS1212@#"));
            Assert.IsFalse(lw.PassWordCondition("AS12as112"));


        }

        [Test]
        public void GetCountTest()
        {
            User lw = new User();

            Assert.AreEqual(3, lw.GetCount(",,,6321", ","));
            Assert.AreEqual(3, lw.GetCount("12,,2,4", ","));
            Assert.AreEqual(3, lw.GetCount("12,,2,", ","));
            Assert.AreEqual(0, lw.GetCount("1234", "5"));




        }

        [Test]
        public void MiniJoin()
        {
            User lw = new User();

            Assert.AreEqual("飞哥a2a3", lw.mimicJoin("a", "飞哥", "2", "3"));

        }
    }
}
