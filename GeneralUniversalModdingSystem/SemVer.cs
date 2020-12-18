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
            Major + "." + Minor + "." + Patch + "-" + PreRelease + "+" + Build;
    }
}