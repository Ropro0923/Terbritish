using Microsoft.Xna.Framework;
using Terbritish.Content.Items.Knives.KnifeProjectiles;
using Terbritish.Content.DamageClasses;

using Terraria.DataStructures;
using Terraria.ID;


namespace Terbritish.Content.Items.Knives.KnifeItems
{
    public class Bloodslinger : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.knockBack = 3.5f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 13;
            Item.useTime = 13;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = ModContent.GetInstance<KnifeslingerDamage>();
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 50, 10);
            Item.shoot = ModContent.ProjectileType<BloodslingerStab>();
            Item.shootSpeed = 3.65f;
        }
        public override void AddRecipes()
        {


            Recipe recipe = CreateRecipe();




            recipe.AddIngredient(ItemID.CrimtaneBar, 7);

            recipe.AddTile(TileID.Anvils);
            recipe.Register();










        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

           
            if (type == ModContent.ProjectileType<BloodslingerStab>())
            {
                damage = (int)(damage * 1.5f);
            }
            
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position, velocity*3.25f, ModContent.ProjectileType<BloodslingerThrown>(), (int)(damage * 0.67f), knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity * 2.69f, ProjectileID.BloodArrow, (int)(damage * 0.48f), knockback, player.whoAmI);
                return false;
            }
            Projectile.NewProjectile(source, position, velocity * 1.66f, ProjectileID.BloodArrow, (int)(damage * 0.67f), knockback, player.whoAmI);
            return true;
        }
    }
}
