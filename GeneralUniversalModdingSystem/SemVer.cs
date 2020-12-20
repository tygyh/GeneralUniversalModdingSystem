using System;

namespace GeneralUniversalModdingSystem
{
    public class SemVer
    {
        public int Major;
        public int Minor;
        public int Patch;
        public string PreRelease;
        public string Build;

        public override string ToString() =>
            Major + "." + Minor + "." + Patch +
            (string.IsNullOrEmpty(PreRelease) ? "" : "-" + PreRelease) +
            (string.IsNullOrEmpty(Build) ? "" : "+" + Build);

        public SemVer() {}

        public SemVer(string version)
        {
            Major = Convert.ToInt32(version.Substring(0,1));
            Minor = Convert.ToInt32(version.Substring(2,1));
            Patch = Convert.ToInt32(version.Substring(4,1));
            PreRelease = version.Substring(6,4);
            Build = version.Substring(11,9);
        }
    }
}