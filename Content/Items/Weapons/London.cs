using Terbritish.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terbritish.Content.Items.Weapons
{
	public class London : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 8;
			Item.knockBack = 4f;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 16;
			Item.useTime = 8;
			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.autoReuse = false;
			Item.noUseGraphic = true; 
			Item.noMelee = true;

			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 0, 10);

			Item.shoot = ModContent.ProjectileType<LondonProjectile>(); // The projectile is what makes a shortsword work
			Item.shootSpeed = 2.1f; // This value bleeds into the behavior of the projectile as velocity, keep that in mind when tweaking values
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
	}
}
