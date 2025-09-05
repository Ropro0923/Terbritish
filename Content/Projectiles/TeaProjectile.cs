

using Microsoft.Xna.Framework;
using Terbritish.Content.DamageClasses;
using Terraria.Audio;
using Terbritish.Content.Buffs;

namespace Terbritish.Content.Projectiles
{
    public class TeaProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<BritishDamage>();
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
        }

        public override void AI()
        {

            Projectile.rotation += 0.05f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 25f)
            {
                Projectile.ai[0] = 25f;
                Projectile.velocity.Y += 0.2f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 17f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
            int debuffType = ModContent.BuffType<Scalding>(); // your debuff
            int duration = 300; // duration in ticks (60 ticks = 1 second)
            target.AddBuff(debuffType, duration);

        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            base.OnHitPlayer(target, info);
            int debuffType = ModContent.BuffType<Scalding>();
            int duration = 300;
            target.AddBuff(debuffType, duration);
        }

        public override void Kill(int timeLeft)
        {
            SoundStyle customSound = new SoundStyle("Terbritish/Assets/Sounds/TeaProjectileHit")
            {
                Volume = 0.4f,
                PitchVariance = 0.1f,
            };
            SoundEngine.PlaySound(customSound, Projectile.position);

            // Optional: spawn splash droplets as projectiles
            for (int i = 0; i < 3; i++)
            {
                Vector2 velocity = new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-4f, -1f));
                Projectile.NewProjectile(
                    Projectile.GetSource_Death(),
                    Projectile.Center,
                    velocity,
                    ModContent.ProjectileType<TeaDroplet>(),
                    Projectile.damage / 2,
                    0,
                    Projectile.owner
                );
            }

            for (int i = 0; i < 3; i++)
            {
                Vector2 velocity = new Vector2(Main.rand.NextFloat(-2f, 2f), Main.rand.NextFloat(-4f, -1f));
                Projectile.NewProjectile(
                    Projectile.GetSource_Death(),
                    Projectile.Center,
                    velocity,
                    ModContent.ProjectileType<TeaDroplet>(),
                    Projectile.damage / 2,
                    0,
                    Projectile.owner
                );
            }
        }
    }
}