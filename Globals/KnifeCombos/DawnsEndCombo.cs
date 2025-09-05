using Microsoft.Xna.Framework;

using Terbritish.Content.Buffs;
using Terbritish.Content.Projectiles;

using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Terraria.ID;



namespace Terbritish.Globals.KnifeCombos
{

    public class DawnsEndComboSetup : GlobalProjectile
    {
        public bool fromtheDawnsEnd;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {



            if (!fromtheDawnsEnd)
                return; // Only apply buff if this is a left-click setup shot

            target.AddBuff(ModContent.BuffType<DawnsEndSetupDebuff>(), 120);




        }
    }


    public class DawnsEndCombo : GlobalProjectile
    {
        public bool fromDawnsEnd;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (!fromDawnsEnd)
                return; // Don't run if this isn't a right-click combo shot

            if (target.HasBuff(ModContent.BuffType<DawnsEndSetupDebuff>()))
            {
                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.NightsEdge,
                  new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                  projectile.owner);

                Vector2 Peanits = projectile.Center - new Vector2(Main.rand.Next(-2, 2), 2);
                Projectile.NewProjectile(projectile.GetSource_FromThis(), Peanits,
                new Vector2(1, 0).RotatedBy((Peanits).DirectionTo(projectile.Center).ToRotation()),
                ModContent.ProjectileType<CorruptVortexBig>(), (int)(projectile.damage * 0.75f), projectile.knockBack, projectile.owner);


            }
       


           

        

          

        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (fromDawnsEnd && target.HasBuff(ModContent.BuffType<DawnsEndSetupDebuff>()))
            {
                modifiers.SourceDamage *= 1.85f;
            }
        }

    }
}
