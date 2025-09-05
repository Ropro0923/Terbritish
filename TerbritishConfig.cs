using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Terbritish
{
    [BackgroundColor(32, 50, 32, 216)]
    public class TerbritishConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static TerbritishConfig Instance;

        [ReloadRequired]
        [BackgroundColor(60, 200, 60, 192)]
        [DefaultValue(true)]
        public bool gunrightsmod { get; set; }

        [ReloadRequired]
        [BackgroundColor(60, 200, 60, 192)]
        [DefaultValue(true)]
        public bool Spiritrum { get; set; }
        
        [ReloadRequired]
        [BackgroundColor(60, 200, 60, 192)]
        [DefaultValue(true)]
        public bool MagnoliasMod { get; set; }
    }
}
