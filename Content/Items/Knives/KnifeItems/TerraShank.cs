using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terbritish.Content.Items.Knives.KnifeProjectiles;


using Terraria.DataStructures;
using Terraria.ID;


namespace Terbritish.Content.Items.Knives.KnifeItems
{
    public class TerraShank : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 102;
            Item.knockBack = 4.75f;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.useAnimation = 10;
            Item.useTime = 10;
         
            Item.width = 32;
            Item.height = 32;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.autoReuse = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(0, 50, 50, 10);
            Item.shoot = ModContent.ProjectileType<TerraShankStab>();
            Item.shootSpeed = 3.65f;
        }
        public override void AddRecipes()
        {


            Recipe recipe = CreateRecipe();



            recipe.Register();










        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Creates extra knives of Terra energy");
            tooltips.Add(line);

            line = new TooltipLine(Mod, "Face", "")
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

           
            if (type == ModContent.ProjectileType<TerraShankStab>())
            {
                damage = (int)(damage * 1.5f);
            }
            
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position, velocity*4.5f, ModContent.ProjectileType<TerraShankThrown>(), (int)(damage * 0.67f), knockback, player.whoAmI);
                Projectile.NewProjectile(source, position, velocity * 4.2f, ModContent.ProjectileType<TerraShankEnergy>(), (int)(damage * 0.49f), knockback, player.whoAmI);
                return false;
            }
            Projectile.NewProjectile(source, position, velocity * 3.5f, ProjectileID.TerraBeam, (int)(damage * 0.69f), knockback, player.whoAmI);
            return true;
        }
    }
}
