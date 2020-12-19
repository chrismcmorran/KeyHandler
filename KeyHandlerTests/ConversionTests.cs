using System;
using KeyHandler;
using NUnit.Framework;

namespace KeyHandlerTests
{
    public class ConversionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConvertCharacter()
        {
            var key = 'a'.ToKey();
            Assert.AreEqual(key, Key.A);
        }
        
        [Test]
        public void TestConvertString()
        {
            var key = "b".ToKey();
            Assert.AreEqual(key, Key.B);
        }
        
        [Test]
        public void TestConvertSlash()
        {
            var key = "/".ToKey();
            Assert.AreEqual(key, Key.Slash);
        }
        
        [Test]
        public void TestConvertBackSlash()
        {
            var key = "\\".ToKey();
            Assert.AreEqual(key, Key.BackSlash);
        }
        
        [Test]
        public void TestConvertPeriod()
        {
            var key = '.'.ToKey();
            Assert.AreEqual(key, Key.Period);
        }
        
        [Test]
        public void TestConvertComma()
        {
            var key = ','.ToKey();
            Assert.AreEqual(key, Key.Comma);
        }
        
        [Test]
        public void TestConvertSpacedNumber()
        {
            Key key = " 1 ".ToKey();
            Assert.AreEqual(Key.One, key);
        }
        
        [Test]
        public void TestNumber()
        {
            Key key = '1'.ToKey();
            Assert.AreEqual(Key.One, key);
        }
        
        [Test]
        public void TestConvertEmpty()
        {
            try
            {
                var key = "".ToKey();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void TestValidKeyWithSpace()
        {
            
            var key = "a ".ToKey();
            Assert.AreEqual(key, Key.A);
        }
    }
}