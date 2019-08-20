﻿using System.Runtime.CompilerServices;
using HiFramework.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiFramework.Tests
{
    [TestClass()]
    public class EventComponentTests
    {
        [TestInitialize()]
        public void InitTest()
        {
            Center.Init(new Binder());
        }

        [TestMethod()]
        public void SubscribeTest()
        {
            bool isTrue = false;
            var ievent = Center.Get<IEvent>();
            ievent.Subscribe("key1", () => { isTrue = true; });
            ievent.Dispatch("key1");
            Assert.IsTrue(isTrue);
        }

        [TestMethod()]
        public void SubscribeTest1()
        {
            bool isTrue = false;
            var ievent = Center.Get<IEvent>();
            ievent.Subscribe<bool>("key1", (x) => { isTrue = x; });
            ievent.Dispatch("key1", true);
            Assert.IsTrue(isTrue);
        }

        [TestMethod()]
        public void SubscribeTest2()
        {
            int t1 = 0, t2 = 0;
            var ievent = Center.Get<IEvent>();
            ievent.Subscribe<int, int>("key1", (x, y) =>
            {
                t1 = x;
                t2 = y;
            });
            ievent.Dispatch("key1", 1, 1);
            Assert.AreEqual(t1, 1);
            Assert.AreEqual(t2, 1);
        }

        [TestMethod()]
        public void SubscribeTest3()
        {
            int t1 = 0, t2 = 0, t3 = 0;
            var ievent = Center.Get<IEvent>();
            ievent.Subscribe<int, int, int>("key1", (x, y, z) =>
             {
                 t1 = x;
                 t2 = y;
                 t3 = z;
             });
            ievent.Dispatch("key1", 1, 2, 3);
            Assert.AreEqual(t1, 1);
            Assert.AreEqual(t2, 2);
            Assert.AreEqual(t3, 3);
        }

        [TestMethod()]
        public void SubscribeTest4()
        {
            int t1 = 0, t2 = 0, t3 = 0, t4 = 0;
            var ievent = Center.Get<IEvent>();
            ievent.Subscribe<int, int, int, int>("key1", (x, y, z, a) =>
             {
                 t1 = x;
                 t2 = y;
                 t3 = z;
                 t4 = a;
             });
            ievent.Dispatch("key1", 1, 2, 3, 4);
            Assert.AreEqual(t1, 1);
            Assert.AreEqual(t2, 2);
            Assert.AreEqual(t3, 3);
            Assert.AreEqual(t4, 4);
        }

        [TestMethod()]
        public void DispatchTest()
        {
            var e = Center.Get<IEvent>();
            e.Dispatch("");
        }

        [TestMethod()]
        public void RemoveListenerTest()
        {
        }

        [TestMethod()]
        public void OnCreatedTest()
        {
        }

        [TestCleanup]
        public void DisposeTest()
        {
            Center.Dispose();
        }
    }
}