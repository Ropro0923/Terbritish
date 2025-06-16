using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terbritish.Content.DamageClasses;


namespace Terbritish.Content.Projectiles
{
	public class BritishBazookaRocket : ModProjectile
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.IsARocketThatDealsDoubleDamageToPrimaryEnemy[Type] = true; // Deals double damage on direct hits.
			ProjectileID.Sets.PlayerHurtDamageIgnoresDifficultyScaling[Type] = true; // Damage dealt to players does not scale with difficulty in vanilla.

			// This set handles some things for us already:
			// Sets the timeLeft to 3 and the projectile direction when colliding with an NPC or player in PVP (so the explosive can detonate).
			// Explosives also bounce off the top of Shimmer, detonate with no blast damage when touching the bottom or sides of Shimmer, and damage other players in For the Worthy worlds.
			ProjectileID.Sets.Explosive[Type] = true;

			// This set makes it so the rocket doesn't deal damage to players. Only used for vanilla rockets.
			// Simply remove the Projectile.HurtPlayer() part to stop the projectile from damaging its user.
			// ProjectileID.Sets.RocketsSkipDamageForPlayers[Type] = true;
		}
		public override void SetDefaults() {
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = ModContent.GetInstance<BritishDamage>();

			// Rockets use explosive AI, ProjAIStyleID.Explosive (16). You could use that instead here with the correct AIType.
			// But, using our own AI allows us to customize things like the dusts that the rocket creates.
			// Projectile.aiStyle = ProjAIStyleID.Explosive;
			// AIType = ProjectileID.RocketI;
		}
        
        public override void AI()
        {
            // If timeLeft is <= 3, then explode the rocket.
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.PrepareBombToBlow();
            }
            else
            {
                // Spawn dusts if the rocket is moving at or greater than half of its max speed.
                if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
                {
                    Projectile.PrepareBombToBlow();
                }
                else
                {
                    // Spawn dusts if the rocket is moving at or greater than half of its max speed.
                    if (Math.Abs(Projectile.velocity.X) >= 8f || Math.Abs(Projectile.velocity.Y) >= 8f)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            float posOffsetX = 0f;
                            float posOffsetY = 0f;
                            if (i == 1)
                            {
                                posOffsetX = Projectile.velocity.X * 0.5f;
                                posOffsetY = Projectile.velocity.Y * 0.5f;
                            }

                            // Spawn British Dust at the back of the rocket.
                            Dust MushroomSprayDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f,
                                Projectile.width - 8, Projectile.height - 8, DustID.MushroomSpray, 0f, 0f, 100);
                            MushroomSprayDust.scale *= 2f + Main.rand.Next(10) * 0.1f;
                            MushroomSprayDust.velocity *= 0.2f;
                            MushroomSprayDust.noGravity = true;

                            Dust GemRubyDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f,
                                Projectile.width - 8, Projectile.height - 8, DustID.GemRuby, 0f, 0f, 100);
                            GemRubyDust.scale *= 2f + Main.rand.Next(10) * 0.1f;
                            GemRubyDust.velocity *= 0.2f;
                            GemRubyDust.noGravity = true;

                            Dust PortalBoltDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f,
                                Projectile.width - 8, Projectile.height - 8, DustID.PortalBolt, 0f, 0f, 100);
                            PortalBoltDust.scale *= 2f + Main.rand.Next(10) * 0.1f;
                            PortalBoltDust.velocity *= 0.2f;
                            PortalBoltDust.noGravity = true;

                            // Spawn smoke dusts at the back of the rocket.
                            Dust smokeDust = Dust.NewDustDirect(new Vector2(Projectile.position.X + 3f + posOffsetX, Projectile.position.Y + 3f + posOffsetY) - Projectile.velocity * 0.5f, Projectile.width - 8, Projectile.height - 8, DustID.Smoke, 0f, 0f, 100, default, 0.5f);
                            smokeDust.fadeIn = 1f + Main.rand.Next(5) * 0.1f;
                            smokeDust.velocity *= 0.05f;
                        }
                    }

                    // Increase the speed of the rocket if it is moving less than 1 block per second.
                    // It is not recommended to increase the number past 16f to increase the speed of the rocket. It could start no clipping through blocks.
                    // Instead, increase extraUpdates in SetDefaults() to make the rocket move faster.
                    if (Math.Abs(Projectile.velocity.X) <= 15f && Math.Abs(Projectile.velocity.Y) <= 15f)
                    {
                        Projectile.velocity *= 1.1f;
                    }
                }

                // Rotate the rocket in the direction that it is moving.
                if (Projectile.velocity != Vector2.Zero)
                {
                    Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.PiOver2;
                }
            }
        }

		// When the rocket hits a tile, NPC, or player, get ready to explode.
        public override bool OnTileCollide(Vector2 oldVelocity) {
            Projectile.velocity *= 0f; // Stop moving so the explosion is where the rocket was.
            Projectile.timeLeft = 3; // Set the timeLeft to 3 so it can get ready to explode.
            return false; // Returning false is important here. Otherwise the projectile will die without being resized (no blast radius).
        }

        public override void PrepareBombToBlow()
        {
            Projectile.tileCollide = false;
            Projectile.alpha = 255;

            int rocketTier = (int)Projectile.ai[0]; // Passed from Shoot
            int size = 128; // Default for Rocket I

            // Scale explosion radius by rocket tier (example values)
            switch (rocketTier)
            {
                case 2:
                    size = 160;
                    break;
                case 3:
                    size = 400;
                    break;
                case 4:
                    size = 224;
                    break;
            }

            Projectile.Resize(size, size);
            Projectile.knockBack = 10f;
        }

		public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
			Projectile.Resize(22, 22);
			for (int i = 0; i < 30; i++) {
				Dust WhiteTorchDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 1.5f);
				WhiteTorchDust.velocity *= 1.4f;
			}
			for (int j = 0; j < 20; j++) {
				Dust BlueTorchDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, 0f, 0f, 100, default, 3.5f);
				BlueTorchDust.noGravity = true;
				BlueTorchDust.velocity *= 7f;
				BlueTorchDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, 0f, 0f, 100, default, 1.5f);
				BlueTorchDust.velocity *= 3f;
			}
            for (int j = 0; j < 20; j++) {
				Dust RedTorchDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 3.5f);
				RedTorchDust.noGravity = true;
				RedTorchDust.velocity *= 7f;
				RedTorchDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 1.5f);
				RedTorchDust.velocity *= 3f;
			}
            for (int j = 0; j < 20; j++) {
				Dust WhiteTorchDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 3.5f);
				WhiteTorchDust.noGravity = true;
				WhiteTorchDust.velocity *= 7f;
				WhiteTorchDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch, 0f, 0f, 100, default, 1.5f);
				WhiteTorchDust.velocity *= 3f;
			}
		}
	}
}