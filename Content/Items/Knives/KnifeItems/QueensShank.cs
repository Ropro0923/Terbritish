using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terbritish.Content.Items.Knives.KnifeProjectiles;
using Terbritish.Content.DamageClasses;

using Terraria.DataStructures;
using Terraria.ID;


namespace Terbritish.Content.Items.Knives.KnifeItems
{
    public class QueensShank : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 39;
            Item.knockBack = 2.5f;
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
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.shoot = ModContent.ProjectileType<QueensShankStab>();
            Item.shootSpeed = 5.25f;
        }
       
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Here we add a tooltipline that will later be removed, showcasing how to remove tooltips from an item
            var line = new TooltipLine(Mod, "Face", "Explodes into homing crystal gel shards on impact");
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

           
            if (type == ModContent.ProjectileType<QueensShankStab>())
            {
                damage = (int)(damage * 1.5f);
            }
            
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (player.altFunctionUse == 2)
            {
                Projectile.NewProjectile(source, position, velocity*3.25f, ModContent.ProjectileType<QueensShankThrown>(), (int)(damage * 0.67f), knockback, player.whoAmI);
                return false;
            }
            return true;
        }
    }
}
