using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
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
<<<<<<< HEAD:Globals/LanceAccelerationPlayer.cs
            if (Math.Abs(Player.velocity.X) < MaxSpeed)
=======
            if (ModContent.GetInstance<LancePlayer>().HoldingLance && Player.mount.Active)
>>>>>>> d319aa7199b89736fed55a900909a7b9b9027039:Globals/LancePlayer.cs
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
        public override void PostUpdate()
        {
            if (ModContent.GetInstance<LancePlayer>().HoldingLance)
            {
                AccelTimer++;
                if (AccelTimer < 6)
                {
                    SpeedBoost++;
                }
                if (SpeedBoost == 1)
                {
                    Player.velocity.X += Player.direction + 0.2f;
                    SpeedBoost = 0;
                }
            }
        }
    }
}