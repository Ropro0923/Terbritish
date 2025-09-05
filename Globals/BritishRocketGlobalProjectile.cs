

using Terraria.ID;
using Microsoft.Xna.Framework;

using Terraria.Audio;

namespace Terbritish.Globals
{
    public class BritishRocketGlobalProjectile : GlobalProjectile
    {
        public bool fromBritishBazooka;

        public override bool InstancePerEntity => true;

        public override void AI(Projectile projectile)
        {
            if (fromBritishBazooka)
            {
                if (Math.Abs(projectile.velocity.X) >= 8f || Math.Abs(projectile.velocity.Y) >= 8f)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        float posOffsetX = 0f;
                        float posOffsetY = 0f;
                        if (i == 1)
                        {
                            posOffsetX = projectile.velocity.X * 0.5f;
                            posOffsetY = projectile.velocity.Y * 0.5f;
                        }

                        Dust MushroomSprayDust = Dust.NewDustDirect(new Vector2(projectile.position.X + 3f + posOffsetX, projectile.position.Y + 3f + posOffsetY) - projectile.velocity * 0.5f,
                            projectile.width - 8, projectile.height - 8, DustID.MushroomSpray, 0f, 0f, 100);
                        MushroomSprayDust.scale *= 2f + Main.rand.Next(10) * 0.1f;
                        MushroomSprayDust.velocity *= 0.2f;
                        MushroomSprayDust.noGravity = true;

                        Dust GemRubyDust = Dust.NewDustDirect(new Vector2(projectile.position.X + 3f + posOffsetX, projectile.position.Y + 3f + posOffsetY) - projectile.velocity * 0.5f,
                            projectile.width - 8, projectile.height - 8, DustID.GemRuby, 0f, 0f, 100);
                        GemRubyDust.scale *= 2f + Main.rand.Next(10) * 0.1f;
                        GemRubyDust.velocity *= 0.2f;
                        GemRubyDust.noGravity = true;

                        Dust PortalBoltDust = Dust.NewDustDirect(new Vector2(projectile.position.X + 3f + posOffsetX, projectile.position.Y + 3f + posOffsetY) - projectile.velocity * 0.5f,
                            projectile.width - 8, projectile.height - 8, DustID.PortalBolt, 0f, 0f, 100);
                        PortalBoltDust.scale *= 2f + Main.rand.Next(10) * 0.1f;
                        PortalBoltDust.velocity *= 0.2f;
                        PortalBoltDust.noGravity = true;

                        // Spawn smoke dusts at the back of the rocket.
                        Dust smokeDust = Dust.NewDustDirect(new Vector2(projectile.position.X + 3f + posOffsetX, projectile.position.Y + 3f + posOffsetY) - projectile.velocity * 0.5f, projectile.width - 8, projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default, 0.5f);
                        smokeDust.fadeIn = 1f + Main.rand.Next(5) * 0.1f;
                        smokeDust.velocity *= 0.05f;
                    }
                }
            }
        }

        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (fromBritishBazooka)
            {
                SoundEngine.PlaySound(SoundID.Item14, projectile.position);
                projectile.Resize(22, 22);
                for (int i = 0; i < 30; i++)
                {
                    Dust WhiteTorchDust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 1.5f);
                    WhiteTorchDust.velocity *= 1.4f;
                }
                for (int j = 0; j < 20; j++)
                {
                    Dust BlueTorchDust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.BlueTorch, 0f, 0f, 100, default, 3.5f);
                    BlueTorchDust.noGravity = true;
                    BlueTorchDust.velocity *= 7f;
                    BlueTorchDust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.BlueTorch, 0f, 0f, 100, default, 1.5f);
                    BlueTorchDust.velocity *= 3f;
                }
                for (int j = 0; j < 20; j++)
                {
                    Dust RedTorchDust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 3.5f);
                    RedTorchDust.noGravity = true;
                    RedTorchDust.velocity *= 7f;
                    RedTorchDust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 1.5f);
                    RedTorchDust.velocity *= 3f;
                }
                for (int j = 0; j < 20; j++)
                {
                    Dust WhiteTorchDust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 3.5f);
                    WhiteTorchDust.noGravity = true;
                    WhiteTorchDust.velocity *= 7f;
                    WhiteTorchDust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 1.5f);
                    WhiteTorchDust.velocity *= 3f;
                }
            }
        }
    }
}
