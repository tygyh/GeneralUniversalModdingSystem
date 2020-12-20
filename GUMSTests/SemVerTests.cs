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
        public void FromString(
            [Values(1,2)]int major,
            [Values(2,3)]int minor,
            [Values(3,4)]int patch,
            [Values("pre1","pre2")]string preRelease,
            [Values("build2048","build4096")]string build)
        {
            SemVer semVer = new SemVer(
                $"{major}.{minor}.{patch}-{preRelease}+{build}");
            
            Assert.AreEqual(semVer.Major, major);
            Assert.AreEqual(semVer.Minor, minor);
            Assert.AreEqual(semVer.Patch, patch);
            Assert.AreEqual(semVer.PreRelease, preRelease);
            Assert.AreEqual(semVer.Build, build);
        }

        #endregion
    }
}