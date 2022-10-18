using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using mylibcs;

namespace mylibcs_test
{
    [TestClass]
    public class MyXorListTests
    {
        [TestMethod]
        public void TestXorListInsertFront()
        {
            MyXorList list = new MyXorList();
            list.insertFront(new MyData(15));
            list.insertFront(new MyData(1));
            list.insertFront(new MyData(6));
            list.insertFront(new MyData(10));
            list.insertFront(new MyData(12));

            Assert.AreEqual(12, list.head.next.data.key);
        }

        [TestMethod]
        public void TestXorListInsertEnd()
        {
            MyXorList list = new MyXorList();
            list.insertEnd(new MyData(15));
            list.insertEnd(new MyData(1));
            list.insertEnd(new MyData(6));
            list.insertEnd(new MyData(10));
            list.insertEnd(new MyData(12));

            Assert.AreEqual(12, list.head.prev.data.key);
        }

        [TestMethod]
        public void TestXorListInsertAfter()
        {
            MyXorList list = new MyXorList();
            list.insertEnd(new MyData(15));
            list.insertEnd(new MyData(1));
            list.insertEnd(new MyData(6));
            list.insertEnd(new MyData(10));
            list.insertEnd(new MyData(12));

            list.insertAfter(new MyData(5), 6);

            Assert.AreEqual(10, list.head.next.next.next.next.next.data.key);
        }

        [TestMethod]
        public void TestXorListListAllItems()
        {
            MyXorList list = new MyXorList();
            list.insertEnd(new MyData(15));
            list.insertEnd(new MyData(1));
            list.insertEnd(new MyData(6));
            list.insertEnd(new MyData(10));
            list.insertEnd(new MyData(12));

            list.insertAfter(new MyData(5), 6);


            Assert.AreEqual(1, list.list()[1].key);
            Assert.AreEqual(6, list.list()[2].key);
        }

        [TestMethod]
        public void TestXorListSearchByKey()
        {
            MyXorList list = new MyXorList();
            list.insertEnd(new MyData(15));
            list.insertEnd(new MyData(1));
            list.insertEnd(new MyData(6));
            list.insertEnd(new MyData(10));
            list.insertEnd(new MyData(12));

            list.insertAfter(new MyData(5), 6);

            Assert.AreEqual(6, list.searchByKey(6).key);
        }
    }
}
