using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace GUMSTests
{
    [TestFixture]
    public class DummyInsertionTest
    {
        private DummyFileLoader dummyFileLoader;

        [SetUp]
        public void Init()
        {
            dummyFileLoader = new DummyFileLoader("C:\\placeholder");
        }

        [Test]
        public async Task InsertFileToRoot(
            [Values("a", "b", "a/b", "b/c", "d/a")]
            string fileName,
            [Values("ahh", "nahh", "wahh")] string fileContents)
        {
            dummyFileLoader.InsertAt(fileName, fileContents);
            Assert.AreEqual(
                fileContents, await dummyFileLoader.LoadStringAt(fileName));
        }
    }

    [TestFixture]
    public class DummyLoadingTest
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
                            ["c"] =
                                new Dictionary<string, object>
                                {
                                    ["d.txt"] =
                                        "the letter d",
                                    ["d.bin"] =
                                        Encoding.Default.
                                            GetBytes(
                                                "the letter d")
                                },
                            ["c.txt"] = "the letter c",
                            ["c.bin"] =
                                Encoding.Default.GetBytes(
                                    "the letter c")
                        },
                        ["b.txt"] = "the letter b",
                        ["b.bin"] =
                            Encoding.Default.GetBytes(
                                "the letter b")
                    },
                    ["a.txt"] = "the letter a",
                    ["a.bin"] =
                        Encoding.Default.GetBytes("the letter a")
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

        [Test]
        public async Task LoadsStringAtPathFolderInFolder()
        {
            Assert.AreEqual(
                "the letter c",
                await dummyFileLoader.LoadStringAt("a/b/c.txt"));
        }

        [Test]
        public async Task LoadsStringAtPath3FolderLevelsDeep()
        {
            Assert.AreEqual(
                "the letter d",
                await dummyFileLoader.LoadStringAt("a/b/c/d.txt"));
        }
        
        [Test]
        public async Task LoadStringFromBin()
        {
            Assert.AreEqual(
                "the letter a",
                await dummyFileLoader.LoadStringAt("a.bin"));
            Assert.AreEqual(
                "the letter b", await dummyFileLoader.LoadStringAt("a/b.bin"));
            Assert.AreEqual(
                "the letter c", await dummyFileLoader.LoadStringAt("a/b/c.bin"));
            Assert.AreEqual(
                "the letter d", await dummyFileLoader.LoadStringAt("a/b/c/d.bin"));
        }
        
        [Test]
        public async Task LoadBinFromString()
        {
            Assert.AreEqual(
                Encoding.Default.GetBytes("the letter a"),
                await dummyFileLoader.LoadAt("a.bin"));
            Assert.AreEqual(
                Encoding.Default.GetBytes("the letter b"),
                await dummyFileLoader.LoadAt("a/b.bin"));
            Assert.AreEqual(
                Encoding.Default.GetBytes("the letter c"),
                await dummyFileLoader.LoadAt("a/b/c.bin"));
            Assert.AreEqual(
                Encoding.Default.GetBytes("the letter d"),
                await dummyFileLoader.LoadAt("a/b/c/d.bin"));
        }
    }
}