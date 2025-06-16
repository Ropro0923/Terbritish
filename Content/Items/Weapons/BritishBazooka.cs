using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terbritish.Content.Projectiles;
using Terraria.DataStructures;


namespace Terbritish.Content.Items.Weapons
{
	// Rocket launchers are special because they typically have ammo-specific variant projectiles.
	// ExampleRocketLauncher will inherit the variants specified by the Rocket Launcher weapon
	public class BritishBazooka : ModItem
	{
		public override void SetStaticDefaults()
		{
			// This line lets BritishBazooka act like a normal RocketLauncher in regard to any variant projectiles
			// corresponding to ammo that aren't specifically populated in SpecificLauncherAmmoProjectileMatches below.
			AmmoID.Sets.SpecificLauncherAmmoProjectileFallback[Type] = ModContent.ProjectileType<Projectiles.BritishBazookaRocket>();

			// SpecificLauncherAmmoProjectileMatches can be used to provide specific projectiles for specific ammo items.
			// This example dictates that when RocketIII ammo is used, this weapon will fire the Meowmere projectile.
			// This is purely to show off this capability, typically SpecificLauncherAmmoProjectileFallback is all
			// that is needed for an "upgrade". A completely custom rocket launcher would instead specify new and
			// unique projectiles for all possible rocket ammo.
			//	AmmoID.Sets.SpecificLauncherAmmoProjectileMatches.Add(Type, new Dictionary<int, int> {
			//		{ ItemID.RocketIII, ProjectileID.Meowmere }, 
			//	});

			// Note that some rocket launchers, like Celebration and Electrosphere Launcher, will always
			// use their own projectiles no matter which rocket is used as ammo.
			// This type of behavior can be implemented in ModifyShootStats
		}

		public override void SetDefaults()
		{
			Item.DefaultToRangedWeapon(ProjectileID.RocketI, AmmoID.Rocket, singleShotTime: 30, shotVelocity: 5f, hasAutoReuse: true);
			Item.width = 50;
			Item.height = 20;
			Item.damage = 55;
			Item.knockBack = 4f;
			Item.UseSound = SoundID.Item11;
			Item.value = Item.buyPrice(gold: 40);
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<Projectiles.BritishBazookaRocket>();
		}


		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			// Offset forward in the direction you're aiming
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 19f;
			// Only apply the forward offset if it doesn't hit a wall
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}


		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int projType = ModContent.ProjectileType<BritishBazookaRocket>();

			// Determine rocket type from the ammo projectile
			int ammoRocketType = type; // This is the projectile ID that would have been used based on ammo

			int rocketStyle = 0;
			if (ammoRocketType == ProjectileID.RocketIII) rocketStyle = 3;
			else if (ammoRocketType == ProjectileID.RocketIV) rocketStyle = 4;
			else if (ammoRocketType == ProjectileID.RocketII) rocketStyle = 2;
			else if (ammoRocketType == ProjectileID.RocketI) rocketStyle = 1;

			// Pass rocket style to your projectile via ai[0]
			int i = Projectile.NewProjectile(source, position, velocity, projType, damage, knockback, player.whoAmI, rocketStyle);
			return false;
		}


		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8f, 2f); // Moves the position of the weapon in the player's hand.
		}
	}
}