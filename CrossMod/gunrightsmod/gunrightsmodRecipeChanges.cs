
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terbritish.Core;
using Terbritish.Content.Items.Weapons;
using gunrightsmod.Content.Items;

namespace Terbritish.CrossMod.gunrightsmod
{
    [ExtendsFromMod(ModCompatibility.gunrightsmod.Name)]
    [JITWhenModsEnabled(ModCompatibility.gunrightsmod.Name)]
    public class TerbritishGunrightsmodRecipeChanges : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return TerbritishConfig.Instance != null && TerbritishConfig.Instance.TerMerica;
        }
        public override void PostAddRecipes()
        {
            foreach (Recipe recipe in Main.recipe)
            {
                if (recipe.createItem.type == ModContent.ItemType<BrenGun>())
                {
                    recipe.AddIngredient<ImprovisedMachineGun>(1);
                    recipe.AddIngredient<LycopiteBar>(13);
                    recipe.AddTile(TileID.Anvils);
                }
            }
        }
    }
}