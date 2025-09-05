


namespace Terbritish.Core
{
    public static class TerbritishCrosscompatibility
    {
        public static class gunrightsmod
        {
            public const string Name = "gunrightsmod";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class Fargowiltas
        {
            public const string Name = "Fargowiltas";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
        public static class Spiritrum
        {
            public const string Name = "Spiritrum";
            public static bool Loaded => ModLoader.HasMod(Name);
            public static Mod Mod => ModLoader.GetMod(Name);
        }
    }
}