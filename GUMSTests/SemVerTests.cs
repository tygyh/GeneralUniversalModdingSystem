using GeneralUniversalModdingSystem;
using NUnit.Framework;

namespace GUMSTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void SemVerToString()
        {
            Assert.AreEqual(
                "1.2.3-pre1+build2048",
                new SemVer
                {
                    Major = 1,
                    Minor = 2,
                    Patch = 3,
                    PreRelease = "pre1",
                    Build = "build2048"
                }.ToString());
        }

        [Test]
        public void SemVerToStringAltBuild()
        {
            Assert.AreEqual(
                "1.2.3-pre1+phuild2048",
                new SemVer
                {
                    Major = 1,
                    Minor = 2,
                    Patch = 3,
                    PreRelease = "pre1",
                    Build = "phuild2048"
                }.ToString());
        }
        
        [Test]
        public void SemVerToStringAltPreRelease()
        {
            Assert.AreEqual(
                "1.2.3-ree1+build2048",
                new SemVer
                {
                    Major = 1,
                    Minor = 2,
                    Patch = 3,
                    PreRelease = "ree1",
                    Build = "build2048"
                }.ToString());
        }
        
        [Test]
        public void SemVerToStringAltMajor()
        {
            Assert.AreEqual(
                "6.2.3-pre1+build2048",
                new SemVer
                {
                    Major = 6,
                    Minor = 2,
                    Patch = 3,
                    PreRelease = "pre1",
                    Build = "build2048"
                }.ToString());
        }
    }
}
