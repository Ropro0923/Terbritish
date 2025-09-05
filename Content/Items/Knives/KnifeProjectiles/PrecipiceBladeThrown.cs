

using Microsoft.Xna.Framework;
using Terbritish.Content.DamageClasses;
using Terbritish.Content.Projectiles;


namespace Terbritish.Content.Items.Knives.KnifeProjectiles
{
    public class PrecipiceBladeThrown : ModProjectile
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

        public override void AI()
        {

            Projectile.rotation += 0.11f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 21f)
            {
                Projectile.ai[0] = 21f;
                Projectile.velocity.Y += 0.2f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 17f;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.Next(-1, 1), 2);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
            new Vector2(1, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<NapalmBad>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);
        }
    }
}
