using GeneralUniversalModdingSystem;
using NUnit.Framework;

namespace GUMSTests
{
    [TestFixture]
    public class Tests
    {
        #region ToString
        
        [Test]
        public void SemVerToString(
            [Values(1,6)]int major,
            [Values(2,1)]int minor,
            [Values(3,4)]int patch,
            [Values("pre1","ree1")]string preRelease,
            [Values("build2048","phuild2048")]string build)
        {
            Assert.AreEqual(
                $"{major}.{minor}.{patch}-{preRelease}+{build}",
                new SemVer
                {
                    Major = major,
                    Minor = minor,
                    Patch = patch,
                    PreRelease = preRelease,
                    Build = build
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
            [Values(1,2,12)]int major,
            [Values(2,3,23)]int minor,
            [Values(3,4,34)]int patch,
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