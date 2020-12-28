using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GUMSTests
{
    [TestFixture]
    public class DummyTest
    {
        private DummyFileLoader dummyFileLoader;

        [SetUp]
        public void Init()
        {
            dummyFileLoader = new DummyFileLoader("C:\\placeholder")
            {
                Files =
                {
                    ["a"] = new Dictionary<string, object>
                    {
                        ["b"] = new Dictionary<string, object>
                        {
                            ["c.txt"] = "the letter c"
                        },
                        ["b.txt"] = "the letter b"
                    },
                    ["a.txt"] = "the letter a"
                }
            };
        }

        [Test]
        public async Task LoadsStringAtImmediate()
        {
            Assert.AreEqual(
                "the letter a", await dummyFileLoader.LoadStringAt("a.txt"));
        }

        [Test]
        public async Task LoadsStringAtPath()
        {
            Assert.AreEqual(
                "the letter b",
                await dummyFileLoader.LoadStringAt("a/b.txt"));
        }
    }
}