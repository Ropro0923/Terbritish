

using Terbritish.Content.Tiles;

namespace Terbritish.Content.Items.Placeable
{
    public class ScotstoneOre : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.scale = 1f;
            Item.rare = 2;
            Item.value = 3500;
            Item.maxStack = 9999;
            Item.DefaultToPlaceableTile(ModContent.TileType<Scotstone>(), 0);
        }
    }
}