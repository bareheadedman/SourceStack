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
            User lw = new User("", "");




            Assert.IsFalse(lw.PassWordIsUpper("asdzxcv"));
            Assert.IsFalse(lw.PassWordIsLower("ASDFGHJ"));
            Assert.IsFalse(lw.PassWordIsNumber("asdASDF"));
            Assert.IsFalse(lw.PassWordIsSymbol("ASDasd123"));

            Assert.IsTrue(lw.PassWordIsUpper("A123dff"));
            Assert.IsTrue(lw.PassWordIsLower("asd123"));
            Assert.IsTrue(lw.PassWordIsNumber("123ASDasd"));
            Assert.IsTrue(lw.PassWordIsSymbol("!@#123ASDad"));


            Assert.IsTrue(lw.PassWordIsMeet("asAS1212@#"));
            Assert.IsFalse(lw.PassWordIsMeet("AS12as112"));


        }

        [Test]
        public void GetCountTest()
        {
            User lw = new User("", "");

            Assert.AreEqual(3, lw.GetCount(",,,6321", ","));
            Assert.AreEqual(3, lw.GetCount("12,,2,4", ","));
            Assert.AreEqual(3, lw.GetCount("12,,2,", ","));
            Assert.AreEqual(0, lw.GetCount("1234", "5"));




        }

        [Test]
        public void MiniJoin()
        {
            User lw = new User("", "");

            Assert.AreEqual("飞哥a2a3", lw.mimicJoin("a", "飞哥", "2", "3"));

        }
    }
}
