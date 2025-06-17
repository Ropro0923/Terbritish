using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terbritish.Content.Projectiles;
using Terbritish.CrossMod.gunrightsmod.gunrightsmodProjectiles;
using Terbritish.Core;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using gunrightsmod.Content.Items;

namespace Terbritish.CrossMod.gunrightsmod.gunrightsmodItems
{
    [ExtendsFromMod(ModCompatibility.gunrightsmod.Name)]
    [JITWhenModsEnabled(ModCompatibility.gunrightsmod.Name)]
    public class PlutoniumShank : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 93;
            Item.knockBack = 4.5f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 18;
            Item.useTime = 9;
            Item.reuseDelay = 3;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.shoot = ModContent.ProjectileType<PlutoniumShankStab>();
            Item.shootSpeed = 5.25f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<PlutoniumBar>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {


            if (type == ModContent.ProjectileType<PlutoniumShankStab>())
            {
                damage = (int)(damage * 1.5f);
            }

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position, velocity * 2.67f, ModContent.ProjectileType<PlutoniumShankThrown>(), (int)(damage * 0.67f), knockback, player.whoAmI);
                return false;
            }
            return true;
        }
    }
}
