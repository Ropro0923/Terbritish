using Microsoft.Xna.Framework;


using Terraria.ID;
using Terraria.Localization;

namespace Terbritish.Content.Tiles
{
	public class Scotstone : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileBlendAll[Type] = false;
			TileID.Sets.CanBeClearedDuringGeneration[Type] = true;
			AddMapEntry(new Color(22, 120, 26), Language.GetText("Scotstone"));
			MineResist = 3.5f;
			MinPick = 150;
		}
	}
}