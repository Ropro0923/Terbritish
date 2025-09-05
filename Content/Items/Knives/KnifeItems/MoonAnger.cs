using Microsoft.Xna.Framework;
using Terbritish.Content.Items.Knives.KnifeProjectiles;

using Terraria.DataStructures;
using Terraria.ID;

using Terbritish.Content.DamageClasses;
namespace Terbritish.Content.Items.Knives.KnifeItems
{
	public class MoonAnger : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.knockBack = 4f;
			Item.useStyle = ItemUseStyleID.Rapier;
			Item.useAnimation = 12;
			Item.useTime = 12;
			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = ModContent.GetInstance<KnifeslingerDamage>();
			Item.autoReuse = false;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 0, 10);
			Item.shoot = ModContent.ProjectileType<MoonAngerStab>();
			Item.shootSpeed = 2.1f;

		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		 public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		 {
			 if (type == ModContent.ProjectileType<MoonAngerStab>())
			 {
			 	damage = (int)(damage * 1.5f);
			 }
		 }

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
			{
				// Manually give the thrown projectile high speed
				velocity = Vector2.Normalize(velocity) * 8f;
				velocity.Y -= 1f;

				Projectile.NewProjectile(
					source,
					position,
					velocity,
					ModContent.ProjectileType<MoonAngerThrown>(),
					(int)(damage * 0.67f),
					knockback,
					player.whoAmI
				);
				return false;
			}
			return true;
		}
	}
}
