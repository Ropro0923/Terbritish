

using Terraria.ID;
using Terbritish.Content.DamageClasses;

namespace Terbritish.Globals.ClassChanges
{
    public class VanillaItemClassChanger : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.Gladius)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
            else if (item.type == ItemID.ShadowFlameKnife)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
            else if (item.type == ItemID.PsychoKnife)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
            else if (item.type == ItemID.ObsidianSwordfish)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
            else if (item.type == ItemID.FlyingKnife)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
            else if (item.type == ItemID.ThrowingKnife)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
            else if (item.type == ItemID.PoisonedKnife)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
            else if (item.type == ItemID.FrostDaggerfish)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
            else if (item.type == ItemID.BoneDagger)
            {
                item.DamageType = ModContent.GetInstance<KnifeslingerDamage>(); // Change to any class here
            }
        }
    }
}