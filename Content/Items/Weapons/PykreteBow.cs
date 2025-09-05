using Microsoft.Xna.Framework;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terbritish.Globals;
using Terbritish.Content.Items.Placeable;

using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;



namespace Terbritish.Content.Items.Weapons
{
    public class PykreteBow : ModItem
    {
        public override void SetDefaults()
        {
            // Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

            // Common Properties
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1f;
            Item.rare = ItemRarityID.White; // The color that the item's name will be in-game.
            Item.value = 3000;


            // Use Properties
            Item.useTime = 24; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 24; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.


            // The sound that this item plays when used.
            Item.UseSound = Terraria.ID.SoundID.Item102;


            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 13; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 1.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.



            // Gun Properties
            // For some reason, all the guns in the vanilla source have this.


            Item.shootSpeed = 7.5f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = ItemID.WoodenArrow;
            Item.shoot = ItemID.WoodenArrow;


        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Main.rand.NextBool(5))
            {
                int proj = Projectile.NewProjectile(source, position, velocity, ProjectileID.FrostburnArrow, damage, knockback, player.whoAmI);
                Main.projectile[proj].GetGlobalProjectile<PykreteBowBuff>().fromPykreteBow = true;
                return false; // Return false because we don't want tModLoader to shoot projectile
            }
            else return true;
        }


       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Has a chance to turn your arrows into powered up frostburn arrows");
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



        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient<Pykrete>(21);
          
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            





        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, -1f);
        }
    }
}