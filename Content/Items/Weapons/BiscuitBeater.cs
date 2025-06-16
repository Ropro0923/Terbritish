using Terbritish.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terbritish.Content.DamageClasses;


namespace Terbritish.Content.Items.Weapons
{
	// Example Advanced Flail is a complete adaption of Ball O' Hurt. The Projectile has the complete code needed to customize all aspects of the flail. See ExampleFlail for a simpler example that is less customizable.
	public class BiscuitBeater : ModItem
	{
		public override void SetStaticDefaults()
		{
			// This line will make the damage shown in the tooltip twice the actual Item.damage. This multiplier is used to adjust for the dynamic damage capabilities of the projectile.
			// When thrown directly at enemies, the flail projectile will deal double Item.damage, matching the tooltip, but deals normal damage in other modes.
			ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.useAnimation = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useTime = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.knockBack = 5.5f; // The knockback of your flail, this is dynamically adjusted in the projectile code.
			Item.width = 32; // Hitbox width of the item.
			Item.height = 32; // Hitbox height of the item.
			Item.damage = 15; // The damage of your flail, this is dynamically adjusted in the projectile code.
			Item.noUseGraphic = true; // This makes sure the item does not get shown when the player swings his hand
			Item.shoot = ModContent.ProjectileType<BiscuitBeaterProjectile>(); // The flail projectile
			Item.shootSpeed = 12f; // The speed of the projectile measured in pixels per frame.
			Item.UseSound = SoundID.Item1; // The sound that this item makes when used
			Item.rare = ItemRarityID.Green; // The color of the name of your item
			Item.value = Item.sellPrice(gold: 1, silver: 50); // Sells for 1 gold 50 silver
			Item.DamageType = ModContent.GetInstance<BritishDamage>(); // Deals melee damage
			Item.channel = true;
			Item.noMelee = true; // This makes sure the item does not deal damage from the swinging animation
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DemoniteOre, 20)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}