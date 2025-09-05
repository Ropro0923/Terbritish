using Microsoft.Xna.Framework;


using Terraria.ID;
using Terraria.Localization;

namespace Terbritish.Content.Tiles
{
	public class Pykrete : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;
			Main.tileBlendAll[Type] = false;
			TileID.Sets.CanBeClearedDuringGeneration[Type] = true;
			AddMapEntry(new Color(180, 220, 255), Language.GetText("MapObject.Pykrete"));
			DustType = DustID.Ice;
			MineResist = 1f;
			MinPick = 1;
		}

		public override void NumDust(int i, int j, bool fail, ref int num) {
			num = fail ? 1 : 3;
		}
	}
}