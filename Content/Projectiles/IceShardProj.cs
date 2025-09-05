using Terbritish.Content.Buffs;
using Terbritish.Content.DamageClasses;

using Terraria.ID;



namespace Terbritish.Content.Projectiles
{
    public class IceShardProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<KnifeslingerDamage>();
            Projectile.penetrate = 2;
            Projectile.timeLeft = 70;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 2;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 160);


        }
        public override void AI()
        {

            Projectile.rotation += 0.245f;
            
        }
    }
}
