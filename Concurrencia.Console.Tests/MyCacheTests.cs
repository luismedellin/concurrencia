using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Concurrencia.Console.Tests
{
    [TestFixture]
    public class MyCacheTests
    {
        private  IMyCache _myCache;

        [SetUp]
        public void SetUp()
        {
            var myCache = new MyCache();
        }

        [Test]
        public void AddItem_WhenCalled_ReturnVoid()
        {
            var keyItem = new KeyValuePair<int, int>(It.IsAny<int>(), It.IsAny<int>());

            _myCache.Add(keyItem);

            Assert.That(_myCache.Length, Is.EqualTo(1));
        }

        [Test]
        public void GetItem_WhenExists_ReturnValue()
        {
            var key = 2;

            var result = _myCache.Get(key);

            Assert.That(result, Is.EqualTo(2));
        }
    }
}
