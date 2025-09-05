using Microsoft.Xna.Framework;
using Terbritish.Content.Items.Knives.KnifeProjectiles;

using Terraria.DataStructures;
using Terraria.ID;

using Terbritish.Content.DamageClasses;
using Terbritish.Globals;
using Terbritish.Globals.KnifeCombos;

namespace Terbritish.Content.Items.Knives.KnifeItems
{
    public class DawnsEnd : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 16;
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
            Item.shoot = ModContent.ProjectileType<DawnsEndStab>();
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


            if (type == ModContent.ProjectileType<DawnsEndStab>())
            {
                damage = (int)(damage * 1.5f);
            }

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                int proj = Projectile.NewProjectile(source, position, velocity * 3.5f, ModContent.ProjectileType<DawnsEndThrown>(), (int)(damage * 0.67f), (int)(knockback * 0.99f), player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<DawnsEndComboSetup>().fromtheDawnsEnd = true;
                return false;
            }
            else
            {
                int proj = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<DawnsEndCombo>().fromDawnsEnd = true;
                Main.projectile[proj].GetGlobalProjectile<DawnsEndComboSetup>().fromtheDawnsEnd = false;
                return false;
            }
        }
    }
}