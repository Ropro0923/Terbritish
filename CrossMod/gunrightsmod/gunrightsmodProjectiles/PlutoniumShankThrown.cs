using Terraria;
using Terraria.ModLoader;
using Terbritish.Content.DamageClasses;
using Terbritish.Core;


namespace Terbritish.CrossMod.gunrightsmod.gunrightsmodProjectiles
{
    [ExtendsFromMod(ModCompatibility.gunrightsmod.Name)]
    [JITWhenModsEnabled(ModCompatibility.gunrightsmod.Name)]

    public class PlutoniumShankThrown : ModProjectile
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return TerbritishConfig.Instance != null && TerbritishConfig.Instance.TerMerica;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<BritishDamage>();
            Projectile.penetrate = 4;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }

        public override void AI()
        {

            Projectile.rotation += 0.215f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 25f)
            {
                Projectile.ai[0] = 25f;
                Projectile.velocity.Y += 0.155f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 17f;
            }
        }
    }
}
