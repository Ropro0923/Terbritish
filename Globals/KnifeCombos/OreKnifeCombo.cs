using Microsoft.Xna.Framework;

using Terbritish.Content.Buffs;

using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Terraria.ID;



namespace Terbritish.Globals.KnifeCombos
{

    public class OreKnifeComboSetup : GlobalProjectile
    {
        public bool fromtheOreKnives;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {



            if (!fromtheOreKnives)
                return; // Only apply buff if this is a left-click setup shot

            target.AddBuff(ModContent.BuffType<OreKnifeSetupDebuff>(), 120);




        }
    }


    public class OreKnifeCombo : GlobalProjectile
    {
        public bool fromOreKnives;

        public override bool InstancePerEntity => true;

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (!fromOreKnives)
                return; // Don't run if this isn't a right-click combo shot

            if (target.HasBuff(ModContent.BuffType<OreKnifeSetupDebuff>()))
            {
                ParticleOrchestrator.RequestParticleSpawn(clientOnly: false, ParticleOrchestraType.Excalibur,
                  new ParticleOrchestraSettings { PositionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox) },
                  projectile.owner);

                  // Apply a buff to the player
            Player player = Main.player[projectile.owner];
            player.AddBuff(ModContent.BuffType<AlloySkin>(), 300); // 300 = 5 seconds (60 ticks per second)
                
            }


          

        }
        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (fromOreKnives && target.HasBuff(ModContent.BuffType<OreKnifeSetupDebuff>()))
            {
                modifiers.SourceDamage *= 1.85f;
            }
        }

    }
}
