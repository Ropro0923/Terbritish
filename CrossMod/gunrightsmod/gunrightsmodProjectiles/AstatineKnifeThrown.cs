using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terbritish2.Content.DamageClasses;
using Terraria.Audio;


namespace Terbritish2.Content.Projectiles
{
    public class AstatineKnifeThrown : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<britishDamage>();
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 15;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {


            Vector2 Peanits = Projectile.Center - new Vector2(Main.rand.Next(-1, 1), 2);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Peanits,
            new Vector2(1, 0).RotatedBy((Peanits).DirectionTo(Projectile.Center).ToRotation()),
            ModContent.ProjectileType<AstatineSplode>(), (int)(Projectile.damage * 1f), Projectile.knockBack, Projectile.owner);

        }
        public override void AI()
        {

            Projectile.rotation += 0.325f;
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 25f)
            {
                Projectile.ai[0] = 25f;
                Projectile.velocity.Y += 0.135f;
            }
            if (Projectile.velocity.Y > 15f)
            {
                Projectile.velocity.Y = 17f;
            }
        }
    }
}