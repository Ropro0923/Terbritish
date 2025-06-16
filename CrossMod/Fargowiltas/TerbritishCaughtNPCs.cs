using Terraria.ModLoader;
using Terbritish.Core;
using Terbritish.Content.NPCs;

namespace Terbritish.CrossMod.Fargowiltas
{
    [ExtendsFromMod(ModCompatibility.Fargowiltas.Name)]
    [JITWhenModsEnabled(ModCompatibility.Fargowiltas.Name)]
    
    internal class TerbritishCaughtNpcs : ModSystem
    {
        public static void RegisterItems()
        {
            TerbritishFargowiltas.Add("DapperChapper", ModContent.NPCType<DapperChapper>());
        }
    }
}
