using Fargowiltas.Common.Configs;
using Terbritish.Core;

namespace Terbritish.Content.NPCs
{
    [ExtendsFromMod(TerbritishCrosscompatibility.Fargowiltas.Name)]
    [JITWhenModsEnabled(TerbritishCrosscompatibility.Fargowiltas.Name)]
    public class CaughtNPCs
    {
        public static bool CanSetCatchable()
        {
            return FargoServerConfig.Instance.CatchNPCs;
        }
    }
}