using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using CSharp;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }


    }
}