

using Terbritish.Content.DamageClasses;


namespace Terbritish.Content.Projectiles
{
    public class CorruptVortex : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 45;
            Projectile.height = 45;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<BritishDamage>();
            Projectile.penetrate = 6;
            Projectile.timeLeft = 36;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;
            Projectile.scale = 0.75f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }

        public override void AI()
        {

            Projectile.rotation += 0.435f;
            Projectile.velocity *= 0f;

            if (Projectile.timeLeft< 35)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft < 30)
            {
                Projectile.scale = 1.05f;
                Projectile.Resize(55, 55);
            }
            if (Projectile.timeLeft < 24)
            {
                Projectile.scale = 1.25f;

            }
            if (Projectile.timeLeft < 18)
            {
                Projectile.scale = 0.85f;
                Projectile.Resize(40, 40);
            }
            if (Projectile.timeLeft < 11)
            {
                Projectile.scale = 0.65f;

            }
            if (Projectile.timeLeft < 5)
            {
                Projectile.scale = 0.4f;
                Projectile.Resize(15, 15);
            }

        }
    }
}
