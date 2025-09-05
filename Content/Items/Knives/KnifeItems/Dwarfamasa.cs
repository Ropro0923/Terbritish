using Microsoft.Xna.Framework;
using Terbritish.Content.Items.Knives.KnifeProjectiles;

using Terraria.DataStructures;
using Terraria.ID;

using Terbritish.Content.DamageClasses;
namespace Terbritish.Content.Items.Knives.KnifeItems
{
    public class Dwarfamasa : ModItem
    {
        public override void SetDefaults()
        {
                
            Item.knockBack = 3.5f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = ModContent.GetInstance<KnifeslingerDamage>();
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 48, 8);
            Item.shoot = ModContent.ProjectileType<DwarfamasaStab>();
            Item.shootSpeed = 3.33f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (player.altFunctionUse == 2 && type == ModContent.ProjectileType<DwarfamasaThrown>())
            {
                damage = 16;
            }
            else if (type == ModContent.ProjectileType<DwarfamasaStab>())
            {
                damage = (int)(16 * 1.5f);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position, velocity * 3.25f, ModContent.ProjectileType<DwarfamasaThrown>(), 16, knockback, player.whoAmI);
                return false;
            }
            return true;
        }
    }
}
