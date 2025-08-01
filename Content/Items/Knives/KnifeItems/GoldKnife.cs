﻿using Microsoft.Xna.Framework;
using Terbritish.Content.Items.Knives.KnifeProjectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terbritish.Content.DamageClasses;
using Terbritish.Globals;
using Terbritish.Globals.KnifeCombos;
namespace Terbritish.Content.Items.Knives.KnifeItems
{
    public class GoldKnife : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.knockBack = 1.75f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = ModContent.GetInstance<KnifeslingerDamage>();
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.shoot = ModContent.ProjectileType<GoldKnifeStab>();
            Item.shootSpeed = 2.1f;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {


            if (type == ModContent.ProjectileType<GoldKnifeStab>())
            {
                damage = (int)(damage * 1.5f);
            }

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldBar, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                int proj = Projectile.NewProjectile(source, position, velocity * 2.67f, ModContent.ProjectileType<GoldKnifeThrown>(), (int)(damage * 0.67f), (int)(knockback * 0.99f), player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<OreKnifeComboSetup>().fromtheOreKnives = true;
                return false;
            }
            else
            {
                int proj = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<OreKnifeCombo>().fromOreKnives = true;
                Main.projectile[proj].GetGlobalProjectile<OreKnifeComboSetup>().fromtheOreKnives = false;
                return false;
            }
        }
    }
}
