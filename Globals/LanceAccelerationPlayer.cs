using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terbritish.Content.DamageClasses;
using Terraria.ID;

public class LanceAccelerationPlayer : ModPlayer
{
    public int AccelTimer;
    public int SpeedBoost;
    public float StartBoost;
    public float MaxSpeed;
    public bool HoldingLance;

    public override void PostUpdate()
    {
        if (HoldingLance)
        {
            if (Math.Abs(Player.velocity.X) < 13f)
            {
                Player.velocity.X += ((SpeedBoost / 60f) + StartBoost) * Player.direction;

                Main.NewText("SpeedBoost: " + SpeedBoost, Color.Orange);
                Main.NewText(Player.velocity.X, Color.Orange);
            }


            if (Player.mount.Active)
            {
                Player.GetDamage(ModContent.GetInstance<BritishDamage>()) += 0.50f;

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
}