using Terbritish.Content.DamageClasses;

using Terraria.ID;

using Microsoft.Xna.Framework;

namespace Terbritish.Content.Items.Weapons
{
	public class TeaLauncher : ModItem
	{
		public override void SetDefaults() {
			Item.width = 42;
			Item.height = 30;
			Item.autoReuse = true;
			Item.damage = 400;
			Item.DamageType = ModContent.GetInstance<BritishDamage>();
			Item.knockBack = 4f;
			Item.noMelee = true;
			Item.noUseGraphic = false; // Show the item when used
			Item.rare = ItemRarityID.Yellow;
			Item.shootSpeed = 20f;
			Item.useAnimation = 35;
			Item.useTime = 35;
			Item.UseSound = SoundID.Item14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(gold: 1);
			Item.shoot = ModContent.ProjectileType<Projectiles.TeaLauncherProjectile>();
		}
		
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-20, -7);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
    	// Offset forward in the direction you're aiming
   		Vector2 muzzleOffset = Vector2.Normalize(velocity) * 30f;

   		// Add upward offset (negative Y = up in Terraria)
    	Vector2 verticalOffset = new Vector2(1, 0f);

    	// Only apply the forward offset if it doesn't hit a wall
    	if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
    		{
        	position += muzzleOffset;
    		}
	
    	// Always apply the upward offset
    	position += verticalOffset;
}


		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<CuppaTea>()
				.AddIngredient(ItemID.CobaltBar, 10)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}

