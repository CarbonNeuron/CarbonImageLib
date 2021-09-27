using CarbonImageLib;
using NUnit.Framework;

namespace CarbonImageTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestModifierKeys1()
        {
            InputReport Report = new InputReport();
            var modifier = Report.GetModifier(Keycode.A);
            Assert.AreEqual(modifier, 0x0);
        }
        [Test]
        public void TestModifierKeys2()
        {
            InputReport Report = new InputReport();
            var modifier = Report.GetModifier(Keycode.SHIFT);
            Assert.AreEqual(modifier, 2);
        }
        
    }
}