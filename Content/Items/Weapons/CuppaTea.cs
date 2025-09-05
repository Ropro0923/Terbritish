using Terbritish.Content.DamageClasses;

using Terraria.ID;

using Terbritish.Content.Items.Placeable;
using Terbritish.Content.Items.Materials;

namespace Terbritish.Content.Items.Weapons
{
	public class CuppaTea : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 30;
			Item.autoReuse = true;
			Item.damage = 22;
			Item.DamageType = ModContent.GetInstance<BritishDamage>();
			Item.knockBack = 4f;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 15f;
			Item.useAnimation = 13;
			Item.useTime = 13;
			Item.UseSound = SoundID.Item1;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.buyPrice(gold: 1);
			Item.shoot = ModContent.ProjectileType<Projectiles.TeaProjectile>();
			Item.noUseGraphic = true;

		}

		public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient<Ceramic>(15)
				.AddIngredient(ItemID.BottledWater, 5)
				.AddIngredient<TeaLeaves>(3)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}

