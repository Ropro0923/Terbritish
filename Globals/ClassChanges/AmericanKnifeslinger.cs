using Terbritish.Content.DamageClasses;
using log4net.Core;
using Microsoft.Xna.Framework;
using gunrightsmod.Content.Items;
using System.Collections.Generic;

using Terraria.DataStructures;
using Terraria.ID;

using gunrightsmod.Content.Projectiles;

namespace Terbritish.Globals.ClassChanges
{
    public class RoproThisCodeWorksDoNotChangeIt : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            if (ModLoader.TryGetMod("gunrightsmod", out Mod gunrightsmod) && gunrightsmod.TryFind<ModItem>("DeliriantDagger", out ModItem DeliriantDagger))
            {
                return item.type == DeliriantDagger.Type;
            }
            else
            {
                return false;
            }

        }
      
        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<KnifeslingerDamage>();
           

        }

    }
    public class DrivingInMyCar : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            if (ModLoader.TryGetMod("gunrightsmod", out Mod gunrightsmod) && gunrightsmod.TryFind<ModItem>("VerdantClaymore", out ModItem VerdantClaymore))
            {
                return item.type == VerdantClaymore.Type;
            }
            else
            {
                return false;
            }

        }

        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<KnifeslingerDamage>();


        }

    }
    public class RightAfterABeer : GlobalItem
    {

        public override bool AppliesToEntity(Item item, bool lateInstantiation)
        {
            if (ModLoader.TryGetMod("gunrightsmod", out Mod gunrightsmod) && gunrightsmod.TryFind<ModItem>("SaberOfTheEuropoor", out ModItem SaberOfTheEuropoor))
            {
                return item.type == SaberOfTheEuropoor.Type;
            }
            else
            {
                return false;
            }

        }

        public override void SetDefaults(Item item)
        {

            item.DamageType = ModContent.GetInstance<KnifeslingerDamage>();


        }

    }
}