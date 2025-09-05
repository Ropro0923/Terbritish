using gunrightsmod.Content.Buffs;
using Terbritish.Content.Buffs;
using Terbritish.Content.DamageClasses;



namespace Terbritish.Content.Items.Knives.KnifeProjectiles
{
    public class PykreteShivThrown : ModProjectile
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
            target.AddBuff(ModContent.BuffType<PykreteShivSetupDebuff>(), 120);

           
        }
        public override void AI()
        {
            Projectile.rotation += 0.15f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 17f)
            {
                Projectile.ai[0] = 17f;
                Projectile.velocity.Y += 0.167f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 17f;
            }
        }
    }
}
