
using Terraria.ID;
using Terbritish.Core;
using Terbritish.Content.Items.Weapons;
using gunrightsmod.Content.Items;

namespace Terbritish.Content.CrossmodContent.gunrightsmod
{
    [ExtendsFromMod(TerbritishCrosscompatibility.gunrightsmod.Name)]
    [JITWhenModsEnabled(TerbritishCrosscompatibility.gunrightsmod.Name)]
    public class TerbritishGunrightsmodRecipeChanges : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return TerbritishConfig.Instance != null && TerbritishConfig.Instance.gunrightsmod;
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