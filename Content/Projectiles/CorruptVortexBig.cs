

using Terbritish.Content.DamageClasses;


namespace Terbritish.Content.Projectiles
{
    public class CorruptVortexBig : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 80;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<KnifeslingerDamage>();
            Projectile.penetrate = 10;
            Projectile.timeLeft = 60;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;
            Projectile.scale = 0.9f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 18;
        }

        public override void AI()
        {

            Projectile.rotation += 0.595f;
            Projectile.velocity *= 0f;

            if (Projectile.timeLeft< 53)
            {
                Projectile.scale = 1.05f;

            }
            if (Projectile.timeLeft < 47)
            {
                Projectile.scale = 1.2f;
                Projectile.Resize(95, 95);
            }
            if (Projectile.timeLeft < 40)
            {
                Projectile.scale = 1.35f;

            }
            if (Projectile.timeLeft < 33)
            {
                Projectile.scale = 1.05f;
                Projectile.Resize(75, 75);
            }
            if (Projectile.timeLeft < 27)
            {
                Projectile.scale = 0.9f;

            }
            if (Projectile.timeLeft <20)
            {
                Projectile.scale = 0.8f;
                Projectile.Resize(60, 60);
            }
            if (Projectile.timeLeft < 13)
            {
                Projectile.scale = 0.75f;

            }
            if (Projectile.timeLeft < 7)
            {
                Projectile.scale = 0.48f;
                Projectile.Resize(45, 45);
            }
           
        }
    }
}
