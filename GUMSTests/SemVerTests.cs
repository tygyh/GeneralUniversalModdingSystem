using GeneralUniversalModdingSystem;
using NUnit.Framework;

namespace GUMSTests
{
    [TestFixture]
    public class Tests
    {
        #region ToString
        
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
        
        [Test]
        public void SemVerToStringAltMinor()
        {
            Assert.AreEqual(
                "1.1.3-pre1+build2048",
                new SemVer
                {
                    Major = 1,
                    Minor = 1,
                    Patch = 3,
                    PreRelease = "pre1",
                    Build = "build2048"
                }.ToString());
        }
        
        [Test]
        public void SemVerToStringAltPatch()
        {
            Assert.AreEqual(
                "1.2.4-pre1+build2048",
                new SemVer
                {
                    Major = 1,
                    Minor = 2,
                    Patch = 4,
                    PreRelease = "pre1",
                    Build = "build2048"
                }.ToString());
        }
        
        [Test]
        public void SemVerToStringNoPreRelease()
        {
            Assert.AreEqual(
                "1.2.3+build2048",
                new SemVer
                {
                    Major = 1, Minor = 2, Patch = 3, Build = "build2048"
                }.ToString());
        }

        [Test]
        public void SemVerToStringNoBuild()
        {
            Assert.AreEqual(
                "1.2.3-pre123",
                new SemVer
                {
                    Major = 1, Minor = 2, Patch = 3, PreRelease = "pre123"
                }.ToString());
        }

        #endregion

        #region FromString

        [Test]
        public void FromString()
        {
            SemVer semVer = new SemVer("1.2.3-pre1+build2048");
            
            Assert.AreEqual(semVer.Major, 1);
            Assert.AreEqual(semVer.Minor, 2);
            Assert.AreEqual(semVer.Patch, 3);
            Assert.AreEqual(semVer.PreRelease, "pre1");
            Assert.AreEqual(semVer.Build, "build2048");
        }

        #endregion
    }
}