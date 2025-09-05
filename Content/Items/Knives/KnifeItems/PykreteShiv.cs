using Microsoft.Xna.Framework;
using Terbritish.Content.Items.Knives.KnifeProjectiles;

using Terraria.DataStructures;
using Terraria.ID;

using Terbritish.Content.DamageClasses;
using Terbritish.Globals;
using Terbritish.Globals.KnifeCombos;
using Terbritish.Content.Items.Placeable;


namespace Terbritish.Content.Items.Knives.KnifeItems
{
    public class PykreteShiv : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.knockBack = 2.5f;
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
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.shoot = ModContent.ProjectileType<PykreteShivStab>();
            Item.shootSpeed = 2.3f;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {


            if (type == ModContent.ProjectileType<PykreteShivStab>())
            {
                damage = (int)(damage * 1.5f);
            }

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient<Pykrete>(18);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();







        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position, velocity * 3.25f, ModContent.ProjectileType<PykreteShivThrown>(), (int)(damage * 0.67f), knockback, player.whoAmI);
                return false;
            }
            else
            {
               
                return true;
            }
        }
    }
}