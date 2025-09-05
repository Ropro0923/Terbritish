
using Terraria.ID;

using Terbritish.Content.Items.Materials;

namespace Terbritish.Content.Items.Armour
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Head)]
	public class TeaLeafHat : ModItem
	{
		public override void SetDefaults()
        {
			Item.width = 18;
			Item.height = 18;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}


		public override void UpdateEquip(Player player) {
			player.moveSpeed += 1.1f;
		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<TeaLeafChestplate>() && legs.type == ModContent.ItemType<TeaLeafLeggings>();
		}

		// UpdateArmorSet allows you to give set bonuses to the armor.
		public override void UpdateArmorSet(Player player)
        {
		    player.moveSpeed += 0.2f;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<TeaLeaves>(12)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
