
using Terraria.ID;



namespace Terbritish.Content.Items.Placeable
{
	public class Pykrete : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Pykrete>());
			Item.width = 12;
			Item.height = 12;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe(3)
				.AddIngredient(ItemID.Wood, 5)
				.AddIngredient(ItemID.IceBlock, 2)
				.AddTile(TileID.Sawmill)
				.Register();
		}
	}
}
