using CSharp;
using NUnit.Framework;

namespace NUnitTestProject1
{
    class DLinkNodeTest
    {
        [Test]
        public void AddAfterTest()
        {


            DLinkNode node1 = new DLinkNode();
            DLinkNode node2 = new DLinkNode();
            DLinkNode node3 = new DLinkNode();
            DLinkNode node4 = new DLinkNode();

            // 1 2
            node1.AddAfter(node2);

            Assert.AreEqual(node1, node2.Previous);
            Assert.AreEqual(node2, node1.Next);
            Assert.IsNull(node1.Previous);
            Assert.IsNull(node2.Next);

            //1 2 3
            node2.AddAfter(node3);
            Assert.AreEqual(node2, node3.Previous);
            Assert.AreEqual(node3, node2.Next);
            Assert.IsNull(node3.Next);

            // 1 2 3 4
            node3.AddAfter(node4);
            Assert.AreEqual(node3, node4.Previous);
            Assert.AreEqual(node4, node3.Next);
            Assert.IsNull(node4.Next);

            // 1 2 3 [5] 4
            DLinkNode node5 = new DLinkNode();
            node3.AddAfter(node5);
            Assert.AreEqual(node5, node3.Next);
            Assert.AreEqual(node5, node4.Previous);
            Assert.AreEqual(node3, node5.Previous);
            Assert.AreEqual(node4, node5.Next);
            Assert.IsNull(node4.Next);

            // 1 2 [6] 3 5 4

            DLinkNode node6 = new DLinkNode();
            node2.AddAfter(node6);
            Assert.AreEqual(node6, node2.Next);
            Assert.AreEqual(node6, node3.Previous);
            Assert.AreEqual(node2, node6.Previous);
            Assert.AreEqual(node3, node6.Next);



        }

        [Test]
        public void AddFrontTest()
        {
            DLinkNode node1 = new DLinkNode();
            DLinkNode node2 = new DLinkNode();
            DLinkNode node3 = new DLinkNode();
            DLinkNode node4 = new DLinkNode();

            //[4] 1
            node1.AddFront(node4);
            Assert.AreEqual(node4, node1.Previous);
            Assert.AreEqual(node1, node4.Next);
            Assert.IsNull(node4.Previous);
            Assert.IsNull(node1.Next);

            //[3] 4 1

            node4.AddFront(node3);
            Assert.AreEqual(node3, node4.Previous);
            Assert.AreEqual(node4, node3.Next);
            Assert.AreEqual(node1, node4.Next);
            Assert.IsNull(node3.Previous);

            //[2] 3 4 1

            node3.AddFront(node2);
            Assert.AreEqual(node2, node3.Previous);
            Assert.AreEqual(node3, node2.Next);
            Assert.AreEqual(node4, node3.Next);
            Assert.IsNull(node2.Previous);

            // 2 [5] 3 4 1

            DLinkNode node5 = new DLinkNode();
            node3.AddFront(node5);
            Assert.AreEqual(node5, node2.Next);
            Assert.AreEqual(node5, node3.Previous);
            Assert.AreEqual(node2, node5.Previous);
            Assert.AreEqual(node3, node5.Next);
            Assert.IsNull(node2.Previous);


        }

        [Test]
        public void DeleteAfterTest()
        {
            DLinkNode node1 = new DLinkNode();
            DLinkNode node2 = new DLinkNode();
            DLinkNode node3 = new DLinkNode();
            DLinkNode node4 = new DLinkNode();
            DLinkNode node5 = new DLinkNode();
            DLinkNode node6 = new DLinkNode();
            DLinkNode node7 = new DLinkNode();
            DLinkNode node8 = new DLinkNode();

            node1.AddAfter(node2);
            node2.AddAfter(node3);
            node3.AddAfter(node4);
            node4.AddAfter(node5);
            node5.AddAfter(node6);
            node6.AddAfter(node7);
            node7.AddAfter(node8);


            // 1 2 3 4 5 6 7 [8] 

            node7.DeleteAfter();
            Assert.AreEqual(node7, node6.Next);
            Assert.AreEqual(node6, node7.Previous);
            Assert.IsNull(node7.Next);


            //1 2 3 4 5 [6] 7 

            node5.DeleteAfter();
            Assert.AreEqual(node5, node7.Previous);
            Assert.AreEqual(node7, node5.Next);
            Assert.IsNull(node7.Next);


            



        }

        [Test]
        public void DeleteFrontTest()
        {
            DLinkNode node1 = new DLinkNode();
            DLinkNode node2 = new DLinkNode();
            DLinkNode node3 = new DLinkNode();
            DLinkNode node4 = new DLinkNode();
            DLinkNode node5 = new DLinkNode();
            DLinkNode node6 = new DLinkNode();
            DLinkNode node7 = new DLinkNode();
            DLinkNode node8 = new DLinkNode();

            node1.AddAfter(node2);
            node2.AddAfter(node3);
            node3.AddAfter(node4);
            node4.AddAfter(node5);
            node5.AddAfter(node6);
            node6.AddAfter(node7);
            node7.AddAfter(node8);


            // [1] 2 3 4 5 6 7 8

            node2.DeleteFront();
            Assert.AreEqual(node3, node2.Next);
            Assert.AreEqual(node2, node3.Previous);
            Assert.IsNull(node2.Previous);


            // 2 [3] 4 5 6 7 

            node4.DeleteFront();
            Assert.AreEqual(node2, node4.Previous);
            Assert.AreEqual(node4, node2.Next);
            Assert.IsNull(node2.Previous);






        }

    }
}
