using Microsoft.Xna.Framework;

using Terraria.ID;

using Terraria.DataStructures;
using Terbritish.Content.DamageClasses;
using Terbritish.Globals;


namespace Terbritish.Content.Items.Weapons
{
	public class BritishBazooka : ModItem
	{
		public override void SetStaticDefaults()
		{
			AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ItemID.RocketLauncher;
		}

		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = ModContent.GetInstance<BritishDamage>();
			Item.width = 40;
			Item.height = 10;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.RocketI;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Rocket;
			Item.scale = 0.8f;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			// Offset forward in the direction you're aiming
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 45f;
			// Only apply the forward offset if it doesn't hit a wall
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			Vector2 verticalOffset = new Vector2(0, -6f);
			position += verticalOffset;
		}


		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int proj = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			Main.projectile[proj].GetGlobalProjectile<BritishRocketGlobalProjectile>().fromBritishBazooka = true;
			return false; // Prevent vanilla projectile spawn
		}



		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-12f, -7f); // Moves the position of the weapon in the player's hand.
		}
	}
}