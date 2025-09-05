

using Microsoft.Xna.Framework;

using Terbritish.Content.DamageClasses;
using Terraria.ID;
using Terbritish;

namespace Terbritish.Content.Globals
{
    public class LancePlayer : ModPlayer
    {
        public bool HoldingLance;
    }

    public class LanceBonusMountDamage : ModPlayer
    {
        public override void PostUpdate()
        {
            if (ModContent.GetInstance<LancePlayer>().HoldingLance && Player.mount.Active)
            {

                Player.GetDamage(ModContent.GetInstance<BritishDamage>()) += 0.10f;

                if (Player.mount.Type == MountID.PaintedHorse)
                {
                    Player.GetDamage(ModContent.GetInstance<BritishDamage>()) += 0.10f;
                }
                if (Player.mount.Type == MountID.MajesticHorse)
                {
                    Player.GetDamage(ModContent.GetInstance<BritishDamage>()) += 0.10f;
                }
                if (Player.mount.Type == MountID.DarkHorse)
                {
                    Player.GetDamage(ModContent.GetInstance<BritishDamage>()) += 0.10f;
                }
                if (Player.mount.Type == MountID.Unicorn)
                {
                    Player.GetDamage(ModContent.GetInstance<BritishDamage>()) += 0.10f;
                }
                if (Player.mount.Type == MountID.Rudolph)
                {
                    Player.GetDamage(ModContent.GetInstance<BritishDamage>()) += 0.10f;
                }
                if (Player.mount.Type == MountID.WallOfFleshGoat)
                {
                    Player.GetDamage(ModContent.GetInstance<BritishDamage>()) += 0.10f;
                }
            }
        }
    }

    public class LanceAcceleration : ModPlayer
    {
        public int AccelTimer;
        public int SpeedBoost;
    }
}