using System;
using System.Linq;

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
            string[] splits = version.Split('.');
            string[] splitsHyphen = splits[2].Split('-');
            string[] splitsPlus = splitsHyphen.Last().Split('+');
            Major = Convert.ToInt32(splits[0]);
            Minor = Convert.ToInt32(splits[1]);
            Patch = Convert.ToInt32(splitsHyphen[0]);
            PreRelease = splitsPlus[0];
            Build = splitsPlus[1];
        }
    }
}