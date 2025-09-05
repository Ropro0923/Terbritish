using Terbritish.Content.DamageClasses;
using Terbritish.Core;


namespace Terbritish.Content.CrossmodContent.gunrightsmod.gunrightsmodProjectiles
{
    [ExtendsFromMod(TerbritishCrosscompatibility.gunrightsmod.Name)]
    [JITWhenModsEnabled(TerbritishCrosscompatibility.gunrightsmod.Name)]
    public class UraniumKnifeThrown : ModProjectile
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return TerbritishConfig.Instance != null && TerbritishConfig.Instance.gunrightsmod;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<BritishDamage>();
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }

        public override void AI()
        {

            Projectile.rotation += 0.135f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 25f)
            {
                Projectile.ai[0] = 25f;
                Projectile.velocity.Y += 0.165f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 17f;
            }
        }
    }
}
