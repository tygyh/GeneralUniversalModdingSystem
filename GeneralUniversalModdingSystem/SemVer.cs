using System;
using System.Linq;
using System.Text.RegularExpressions;

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

        public static SemVer RegexExperiment(string version)
        {
            Regex regex = new Regex(
                @"(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:-(?<preRelease>(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)))?(?:\+(?<buildMetadata>[0-9a-zA-Z-]*))?");

            Match match = regex.Match(version);

            string GetSubstring(string value) => match.Groups[value].Value;

            int ToInt(string toConvert) =>
                Convert.ToInt32(GetSubstring(toConvert));
            
            return new SemVer
            {
                Major = ToInt("major"),
                Minor = ToInt("minor"),
                Patch = ToInt("patch"),
                PreRelease = GetSubstring("preRelease"),
                Build = GetSubstring("buildMetadata")
            };
        }
    }
}