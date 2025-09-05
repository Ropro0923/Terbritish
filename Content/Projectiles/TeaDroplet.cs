
using Terraria.ID;

using Microsoft.Xna.Framework;

namespace Terbritish.Content.Projectiles
{
    public class TeaDroplet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 30;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            // Optional gravity
            Projectile.velocity.Y += 0.2f;

            // Tea-colored dust trail
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sand, 0f, 0f, 0, new Color(139, 69, 19), 1f);
        }

        public override void Kill(int timeLeft)
        {
            // Small burst of dust when the droplet vanishes
            for (int i = 0; i < 3; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Sand, Main.rand.NextFloat(-1f, 1f), Main.rand.NextFloat(-1f, 1f), 0, new Color(139, 69, 19));
            }
        }
    }
}
