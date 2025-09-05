using Terbritish.Content.Items.Materials;

using Terraria.ID;


namespace Terbritish.Content.Items.Armour
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class TeaLeafLeggings : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 5; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
		player.moveSpeed += 0.1f;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<TeaLeaves>(12)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
