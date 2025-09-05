
using Terraria.ID;

using Terbritish.Content.Items.Materials;

namespace Terbritish.Content.Items.Armour
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Body value here will result in TML expecting a X_Body.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Body)]
	public class TeaLeafChestplate : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18; 
			Item.height = 18;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = 6; 
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
