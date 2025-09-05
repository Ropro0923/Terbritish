
using Terraria.ID;

using Microsoft.Xna.Framework;
using Terbritish.Content.DamageClasses;
using Terraria.Audio;
using Terbritish.Content.Projectiles;


namespace Terbritish.Content.Items.Knives.KnifeProjectiles
{
    public class QueensShankThrown : ModProjectile
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
            Projectile.extraUpdates = 1;
           
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            Vector2 velocity = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits, velocity,
            ModContent.ProjectileType<CrystalGelShard>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity2 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits2 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits2, velocity2,
            ModContent.ProjectileType<CrystalGelShard>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
            Vector2 velocity3 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits3 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));
            Vector2 velocity4 = Projectile.velocity.RotatedByRandom(MathHelper.ToRadians(360));
            Vector2 Peanits4 = Projectile.Center - new Vector2(Main.rand.NextFloat(-4, 4));

            if (Main.rand.NextBool(2))
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits3, velocity3,
           ModContent.ProjectileType<CrystalGelShard>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);


            }

            if (Main.rand.NextBool(2))
            {

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits4, velocity4,
           ModContent.ProjectileType<CrystalGelShard>(), (int)(Projectile.damage * 0.5f), Projectile.knockBack, Projectile.owner);
            }
            SoundEngine.PlaySound(SoundID.Shatter, Projectile.position);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
        public override void AI()
        {

            Projectile.rotation += 0.225f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 25f)
            {
                Projectile.ai[0] = 25f;
                Projectile.velocity.Y += 0.185f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 17f;
            }
        }
    }
}
