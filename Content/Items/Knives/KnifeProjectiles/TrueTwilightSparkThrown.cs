

using Terbritish.Content.DamageClasses;


namespace Terbritish.Content.Items.Knives.KnifeProjectiles
{
    public class TrueTwilightSparkThrown : ModProjectile
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
    }
}
