using Microsoft.Xna.Framework;
using gunrightsmod.Content.Items;
using Terbritish.Core;
using Terraria.DataStructures;
using Terraria.ID;
using Terbritish.Content.DamageClasses;
using Terbritish.Content.CrossmodContent.gunrightsmod.gunrightsmodProjectiles;

namespace Terbritish.Content.CrossmodContent.gunrightsmod.gunrightsmodItems
{
    [ExtendsFromMod(TerbritishCrosscompatibility.gunrightsmod.Name)]
    [JITWhenModsEnabled(TerbritishCrosscompatibility.gunrightsmod.Name)]
    public class AstatineKnife : ModItem
    {

        public override bool IsLoadingEnabled(Mod mod)
        {
            return TerbritishConfig.Instance != null && TerbritishConfig.Instance.gunrightsmod;
        }
        public override void SetDefaults()
        {
            Item.damage = 121;
            Item.knockBack = 6.5f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 8;
            Item.useTime = 8;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = ModContent.GetInstance<KnifeslingerDamage>();
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.shoot = ModContent.ProjectileType<AstatineKnifeStab>();
            Item.shootSpeed = 5.95f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<AstatineBar>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ModContent.ProjectileType<AstatineKnifeStab>())
            {
                damage = (int)(damage * 1.5f);
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position, velocity * 3.33f, ModContent.ProjectileType<AstatineKnifeThrown>(), (int)(damage * 0.67f), knockback, player.whoAmI);
                return false;
            }
            return true;
        }
    }
}
