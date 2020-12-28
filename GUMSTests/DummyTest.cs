using System.Threading.Tasks;
using NUnit.Framework;

namespace GUMSTests
{
    [TestFixture]
    public class DummyTest
    {
        [Test]
        public async Task LoadsStringAtImmediate()
        {
            DummyFileLoader dummyFileLoader =
                new DummyFileLoader("C:\\placeholder")
                {
                    Files = {["a.txt"] = "the letter a"}
                };
            Assert.AreEqual(
                "the letter a", await dummyFileLoader.LoadStringAt("a.txt"));
        }
    }
}