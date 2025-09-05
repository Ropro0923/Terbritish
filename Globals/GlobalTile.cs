
using Terraria.ID;

using Terbritish.Content.Items.Materials;

namespace Terbritish
{
    public class LeafDropGlobalTile : GlobalTile
    {
        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            // Check if the tile destroyed is a leaf tile
            if (type == TileID.LeafBlock)
            {
                if (!fail && !effectOnly)
                {
                    // Roll a 1 in 25 chance
                    if (Main.rand.Next(25) == 0) 
                    {
                        // Spawn your custom item at the tile position
                        Item.NewItem(null, i * 16, j * 16, 16, 16, ModContent.ItemType<TeaLeaves>());
                    }
                }
            }
        }
    }
}
