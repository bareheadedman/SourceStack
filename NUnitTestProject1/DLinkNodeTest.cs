using CSharp;
using NUnit.Framework;

namespace NUnitTestProject1
{
    class DLinkNodeTest
    {
        DLinkNode node1, node2, node3, node4, node5, node6;

        [SetUp]
        public void SetUp()
        {
            node1 = new DLinkNode();
            node2 = new DLinkNode();
            node3 = new DLinkNode();
            node4 = new DLinkNode();
            node5 = new DLinkNode();
            node6 = new DLinkNode();

            node1.Next = node2;
            node2.Previous = node1;
            node2.Next = node3;
            node3.Previous = node2;
            node3.Next = node4;
            node4.Previous = node3;
            node4.Next = node5;
            node5.Previous = node4;
            node5.Next = node6;
            node6.Previous = node5;



        }

        [Test]
        public void AddAfterTest()
        {
            // 1 2 3 4 5 6 [7]

            DLinkNode node7 = new DLinkNode();
            node6.AddAfter(node7);

            Assert.AreEqual(node6, node7.Previous);
            Assert.AreEqual(node7, node6.Next);
            Assert.IsNull(node7.Next);

            // 1 2 3 4 [8] 5 6 7

            DLinkNode node8 = new DLinkNode();
            node4.AddAfter(node8);

            Assert.AreEqual(node3, node4.Previous);
            Assert.AreEqual(node8, node4.Next);
            Assert.AreEqual(node8, node5.Previous);
            Assert.AreEqual(node6, node5.Next);
            Assert.AreEqual(node4, node8.Previous);
            Assert.AreEqual(node5, node8.Next);

            // 1 2 3 4 8 5 6 7 [7]

            node7.AddAfter(node7);







        }

        [Test]
        public void AddBeforeTest()
        {


            // [7] 1 2 3 4 5 6
            DLinkNode node7 = new DLinkNode();
            node1.AddBefore(node7);

            Assert.AreEqual(node7, node1.Previous);
            Assert.AreEqual(node2, node1.Next);
            Assert.AreEqual(node1, node7.Next);
            Assert.IsNull(node7.Previous);

            // 7 1 2 [8] 3 4 5 6
            DLinkNode node8 = new DLinkNode();
            node3.AddBefore(node8);

            Assert.AreEqual(node8, node3.Previous);
            Assert.AreEqual(node4, node3.Next);
            Assert.AreEqual(node1, node2.Previous);
            Assert.AreEqual(node8, node2.Next);
            Assert.AreEqual(node2, node8.Previous);
            Assert.AreEqual(node3, node8.Next);



        }

        [Test]
        public void DeleteTest()
        {

            // [1] 2 3 4 5 6
            node1.Delete();

            Assert.IsNull(node1.Previous);
            Assert.IsNull(node1.Next);
            Assert.AreEqual(node2, node3.Previous);
            Assert.AreEqual(node3, node2.Next);
            Assert.IsNull(node2.Previous);


            //  2 3 4 5 [6]
            node6.Delete();

            Assert.IsNull(node6.Previous);
            Assert.IsNull(node6.Next);
            Assert.AreEqual(node4, node5.Previous);
            Assert.AreEqual(node5, node4.Next);
            Assert.IsNull(node5.Next);


            // 2 3 [4] 5 
            node4.Delete();

            Assert.IsNull(node4.Previous);
            Assert.IsNull(node4.Next);
            Assert.AreEqual(node3, node2.Next);
            Assert.AreEqual(node2, node3.Previous);
            Assert.AreEqual(node3, node5.Previous);
            Assert.AreEqual(node5, node3.Next);
            Assert.IsNull(node5.Next);

        }

        [Test]
        public void SwapTest()
        {
            //   [1] 2 3 4 5 [6] 
            //=> [6] 2 3 4 5 [1]
            node1.Swap(node6);

            Assert.AreEqual(node2, node6.Next);
            Assert.AreEqual(node6, node2.Previous);
            Assert.IsNull(node6.Previous);
            Assert.AreEqual(node5, node1.Previous);
            Assert.AreEqual(node1, node5.Next);
            Assert.IsNull(node1.Next);


            //   [6] [2] 3 4 5 1

            // => [2] [6] 3 4 5 1
            node2.Swap(node6);
            Assert.AreEqual(node3, node6.Next);
            Assert.AreEqual(node2, node6.Previous);
            Assert.AreEqual(node6, node2.Next);
            Assert.AreEqual(node6, node3.Previous);
            Assert.IsNull(node2.Previous);


            //    2 6 3 4 [5] [1]

            // => 2 6 3 4 [1] [5]
            node5.Swap(node1);
            Assert.AreEqual(node5, node1.Next);
            Assert.AreEqual(node4, node1.Previous);
            Assert.AreEqual(node1, node5.Previous);
            Assert.AreEqual(node1, node4.Next);
            Assert.IsNull(node5.Next);


            //    [2] 6 [3] 4 1 5

            // => [3] 6 [2] 4 1 5 
            node2.Swap(node3);
            Assert.AreEqual(node4, node2.Next);
            Assert.AreEqual(node6, node2.Previous);
            Assert.AreEqual(node2, node6.Next);
            Assert.AreEqual(node3, node6.Previous);
            Assert.AreEqual(node6, node3.Next);
            Assert.AreEqual(node2, node4.Previous);
            Assert.IsNull(node3.Previous);


            //    3 6 2 [4] 1 [5]

            // => 3 6 2 [5] 1 [4]
            node4.Swap(node5);
            Assert.AreEqual(node1, node5.Next);
            Assert.AreEqual(node2, node5.Previous);
            Assert.AreEqual(node4, node1.Next);
            Assert.AreEqual(node5, node1.Previous);
            Assert.AreEqual(node1, node4.Previous);
            Assert.IsNull(node4.Next);
            Assert.AreEqual(node5, node2.Next);


            //    3 [6] [2] 5 1 4 

            // => 3 [2] [6] 5 1 4
            node6.Swap(node2);
            Assert.AreEqual(node5, node6.Next);
            Assert.AreEqual(node2, node6.Previous);
            Assert.AreEqual(node3, node2.Previous);
            Assert.AreEqual(node6, node2.Next);
            Assert.AreEqual(node2, node3.Next);
            Assert.AreEqual(node6, node5.Previous);

            //    3 [2] 6 [5] 1 4 

            // => 3 [5] 6 [2] 1 4
            node2.Swap(node5);
            Assert.AreEqual(node6, node5.Next);
            Assert.AreEqual(node3, node5.Previous);
            Assert.AreEqual(node2, node6.Next);
            Assert.AreEqual(node5, node6.Previous);
            Assert.AreEqual(node6, node2.Previous);
            Assert.AreEqual(node1, node2.Next);
            Assert.AreEqual(node5, node3.Next);
            Assert.AreEqual(node2, node1.Previous);


            //    [3] 5 6 2 1 [4]先
            // => [4] 5 6 2 1 [3]

            node4.Swap(node3);
            Assert.AreEqual(node4, node5.Previous);
            Assert.AreEqual(node5, node4.Next);
            Assert.AreEqual(node1, node3.Previous);
            Assert.AreEqual(node3, node1.Next);
            Assert.IsNull(node3.Next);
            Assert.IsNull(node4.Previous);


            // 5先
            //    [4] [5] 6 2 1 3
            // => [5] [4] 6 2 1 3
            node5.Swap(node4);
            Assert.AreEqual(node6, node4.Next);
            Assert.AreEqual(node5, node4.Previous);
            Assert.AreEqual(node4, node5.Next);
            Assert.AreEqual(node4, node6.Previous);
            Assert.IsNull(node5.Previous);


            //  3先
            //    5 4 6 2 [1] [3]
            // => 5 4 6 2 [3] [1]
            node3.Swap(node1);
            Assert.AreEqual(node1, node3.Next);
            Assert.AreEqual(node2, node3.Previous);
            Assert.AreEqual(node3, node1.Previous);
            Assert.AreEqual(node3, node2.Next);
            Assert.IsNull(node1.Next);


            // 6先
            //    [5] 4 [6] 2 3 1 
            // => [6] 4 [5] 2 3 1
            node6.Swap(node5);
            Assert.AreEqual(node5, node4.Next);
            Assert.AreEqual(node6, node4.Previous);
            Assert.AreEqual(node2, node5.Next);
            Assert.AreEqual(node4, node5.Previous);
            Assert.AreEqual(node4, node6.Next);
            Assert.AreEqual(node5, node2.Previous);
            Assert.IsNull(node6.Previous);


            // 1先
            //    6 4 5 [2] 3 [1]
            // => 6 4 5 [1] 3 [2]
            node1.Swap(node2);
            Assert.AreEqual(node2, node3.Next);
            Assert.AreEqual(node1, node3.Previous);
            Assert.AreEqual(node3, node1.Next);
            Assert.AreEqual(node5, node1.Previous);
            Assert.AreEqual(node3, node2.Previous);
            Assert.IsNull(node2.Next);
            Assert.AreEqual(node1, node5.Next);




        }

    }
}
