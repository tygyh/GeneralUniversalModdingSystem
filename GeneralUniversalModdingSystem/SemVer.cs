namespace GeneralUniversalModdingSystem
{
    public class SemVer
    {
        public int Major;
        public int Minor;
        public int Patch;
        public string PreRelease;
        public string Build;

        public override string ToString() => "1.2.3-pre1+build2048";
    }
}
