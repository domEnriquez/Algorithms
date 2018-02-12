using NUnit.Framework;
using System.Collections.Generic;
using SystemTables;

namespace SystemTablesTest
{
    [TestFixture]
    public class SystemTablesTest
    {
        List<SystemTable<int, string>> tables;

        [SetUp]
        public void GivenAListOfSystemTableTypes()
        {
            tables = new List<SystemTable<int, string>>()
            {
                 new OrderedArrayST<int, string>(), new BinarySearchTrees<int, string>(), new UnorderedLinkedListST<int, string>(),
                 new RedBlackBinarySearchTrees<int, string>()
            };
        }

        [Test]
        public void WhenPutOneEntry_ThenGetEntry()
        {
            foreach(SystemTable<int, string> st in tables)
            {
                st.Put(1, "Dominic");

                Assert.AreEqual("Dominic", st.Get(1), st.GetName());
            }
        }

        [Test]
        public void WhenPutInExisitingKey_ThenReplaceValueOfKey()
        {
            foreach(SystemTable<int, string> st in tables)
            {
                st.Put(1, "Dominic");
                st.Put(2, "Genie");
                st.Put(1, "Dom");

                Assert.AreEqual("Dom", st.Get(1), st.GetName());
                Assert.AreEqual("Genie", st.Get(2), st.GetName());
            }
        }

        [Test]
        public void WhenInsertedMultipleEntries_ThenGetMultipleEntries()
        {
            foreach (SystemTable<int, string> st in tables)
            {
                st.Put(1, "Dominic");
                st.Put(2, "Genie");
                st.Put(5, "Rambo");
                st.Put(4, "Chico");
                st.Put(20, "Hola");
                st.Put(3, "Carl");
                st.Put(1, "Domi");
                st.Put(21, "Bogart");

                Assert.AreEqual("Domi", st.Get(1), st.GetName());
                Assert.AreEqual("Genie", st.Get(2), st.GetName());
                Assert.AreEqual("Rambo", st.Get(5), st.GetName());
                Assert.AreEqual("Chico", st.Get(4), st.GetName());
                Assert.AreEqual("Hola", st.Get(20), st.GetName());
                Assert.AreEqual("Bogart", st.Get(21), st.GetName());
                Assert.AreEqual("Carl", st.Get(3), st.GetName());
            }
        }

        [Test]
        public void WhenGetFloorOfUserKey_ThenReturnLargestKeyLessThanOrEqualToUserKey()
        {
            foreach(SystemTable<int,string> st in tables)
            {
                st.Put(1, "Dom");
                st.Put(2, "Genie");
                st.Put(3, "Rambo");
                st.Put(5, "Bogart");

                Assert.AreEqual(1, st.Floor(1), st.GetName());
                Assert.AreEqual(2, st.Floor(2), st.GetName());
                Assert.AreEqual(3, st.Floor(4), st.GetName());
                Assert.AreEqual(5, st.Floor(5), st.GetName());
                Assert.AreEqual(5, st.Floor(7), st.GetName());
            }
        }

        [Test]
        public void WhenGetSize_ThenReturnNumberOfTableEntries()
        {
            foreach(SystemTable<int, string> st in tables)
            {
                st.Put(1, "Dominic");
                Assert.AreEqual(1, st.Size());

                st.Put(2, "Rifle");
                Assert.AreEqual(2, st.Size());

                st.Put(3, "Monkey");
                st.Put(4, "Luffy");
                Assert.AreEqual(4, st.Size());
            }
        }

        [Test]
        public void WhenGetRankOfUserKey_ThenGetNumberOfKeysLessThanUserKey()
        {
            foreach(SystemTable<int, string> st in tables)
            {
                st.Put(1, "Dominic");
                Assert.AreEqual(0, st.Rank(1));
                Assert.AreEqual(1, st.Rank(2));
                Assert.AreEqual(1, st.Rank(5));

                st.Put(2, "Gino");
                st.Put(3, "Gina");
                Assert.AreEqual(2, st.Rank(3));
                Assert.AreEqual(3, st.Rank(5));
            }
        }

        [Test]
        public void WhenDeleteMin_ThenDeleteMinimumKey()
        {
            foreach(SystemTable<int, string> st in tables)
            {
                st.Put(2, "Tong");
                st.Put(5, "Dominic");
                st.DeleteMin();
                Assert.AreEqual(1, st.Size());
                Assert.AreEqual(null, st.Get(2));

                st.Put(2, "Teng");
                st.Put(6, "Chesca");
                st.Put(1, "Mommy");
                st.Put(9, "Daddy");
                st.DeleteMin();
                Assert.AreEqual(4, st.Size());
                Assert.AreEqual(null, st.Get(1));
                Assert.AreEqual("Chesca", st.Get(6));
                Assert.AreEqual("Teng", st.Get(2));
                Assert.AreEqual("Daddy", st.Get(9));
            }
        }

        [Test]
        public void WhenDelete_ThenRemoveTargetKey()
        {
            foreach(SystemTable<int, string> st in tables)
            {
                st.Put(7, "Dom");
                st.Put(3, "Nico");
                st.Put(12, "Tong");
                st.Delete(7);
                Assert.AreEqual(2, st.Size());
                Assert.AreEqual(null, st.Get(7));
                Assert.AreEqual("Nico", st.Get(3));
                Assert.AreEqual("Tong", st.Get(12));

                st.Delete(12);
                Assert.AreEqual(null, st.Get(12));
            }
        }
    }
}
