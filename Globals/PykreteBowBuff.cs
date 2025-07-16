using Microsoft.Xna.Framework;
using System;
using Terbritish.Content.Buffs;
using Terbritish.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;


namespace Terbritish.Globals
{


    public class PykreteBowBuff : GlobalProjectile
    {
        public bool fromPykreteBow;

        public override bool InstancePerEntity => true;

        public override void AI(Projectile projectile)
        {

            if (fromPykreteBow)
            {

                projectile.scale = 1.15f;


            }
        }


        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (fromPykreteBow)
            {
                modifiers.SourceDamage *= 1.33f;
            }
        }

    }
}
