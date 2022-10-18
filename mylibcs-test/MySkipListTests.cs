using Microsoft.VisualStudio.TestTools.UnitTesting;
using mylibcs;
using System;

namespace mylibcs_test
{
    [TestClass]
    public class MySkipListTests
    {
        [TestMethod]
        public void TestSkipListInsert()
        {
            SkipList list = new SkipList(3);
            list.Insert(new MyData(1));
            list.Insert(new MyData(2));
            list.Insert(new MyData(3));
            list.Insert(new MyData(4));
            list.Insert(new MyData(5));
            list.Insert(new MyData(6));
            list.Insert(new MyData(7));

            Assert.AreNotEqual(list.searchByKey(1).key, 2);
        }

        [TestMethod]
        public void TestSkipListRemoveByKey()
        {
            SkipList list = new SkipList(3);
            list.Insert(new MyData(1));
            list.Insert(new MyData(2));
            list.Insert(new MyData(3));
            list.Insert(new MyData(4));

            list.removeByKey(new MyData(0), 1); 
            list.removeByKey(new MyData(0), 2);
            list.removeByKey(new MyData(0), 3);
            list.removeByKey(new MyData(0), 4);

            Assert.AreEqual(list.searchByKey(1), null);
        }


        [TestMethod]
        public void TestSkipListListAllItems()
        {
            SkipList list = new SkipList(3);
            list.Insert(new MyData(1));
            list.Insert(new MyData(2));
            list.Insert(new MyData(3));
            list.Insert(new MyData(4));
            list.Insert(new MyData(5));
            list.Insert(new MyData(6));
            list.Insert(new MyData(7));

            MyData[] data = list.list();

            Assert.AreEqual(data[0].key, 1);
            Assert.AreEqual(data[1].key, 2);
            Assert.AreEqual(data[2].key, 3);
            Assert.AreEqual(data[3].key, 4);
            Assert.AreEqual(data[4].key, 5);
            Assert.AreEqual(data[5].key, 6);
            Assert.AreEqual(data[6].key, 7);
        }

        [TestMethod]
        public void TestSkipListSearchByKey()
        {
            SkipList list = new SkipList(3);
            list.Insert(new MyData(1));
            list.Insert(new MyData(2));
            list.Insert(new MyData(3));
            list.Insert(new MyData(4));
            list.Insert(new MyData(5));
            list.Insert(new MyData(6));
            list.Insert(new MyData(7));

            Assert.AreEqual(list.searchByKey(1).key, 1);
        }
    }
}
