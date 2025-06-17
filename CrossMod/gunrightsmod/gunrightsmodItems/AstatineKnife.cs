using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terbritish2.Content.Projectiles;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terbritish2.Content.Items.Weapons
{
    public class AstatineKnife : ModItem
    {
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
            Item.DamageType = DamageClass.MeleeNoSpeed;
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


            if (ModLoader.TryGetMod("gunrightsmod", out Mod TerMerica) && TerMerica.TryFind<ModItem>("AstatineBar", out ModItem AstatineBar))
              


            {

                recipe = CreateRecipe();
             
                recipe.AddIngredient(AstatineBar.Type, 12);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();


            }

            else
            {
               
            }








        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Explodes on contact with an enemy");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "The explosions are more devastating up close")
            {
                OverrideColor = new Color(255, 255, 255)
            };
            tooltips.Add(line);



            // Here we will hide all tooltips whose title end with ':RemoveMe'
            // One like that is added at the start of this method
            foreach (var l in tooltips)
            {
                if (l.Name.EndsWith(":RemoveMe"))
                {
                    l.Hide();
                }
            }

            // Another method of hiding can be done if you want to hide just one line.
            // tooltips.FirstOrDefault(x => x.Mod == "ExampleMod" && x.Name == "Verbose:RemoveMe")?.Hide();
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
                Projectile.NewProjectile(source, position, velocity*3.33f, ModContent.ProjectileType<AstatineKnifeThrown>(), (int)(damage * 0.67f), knockback, player.whoAmI);
                return false;
            }
            return true;
        }
    }
}