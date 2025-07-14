using Terraria;
using Terraria.ModLoader;
using Terbritish.Content.Items.Lances.LanceProjectiles;
using Terbritish.Content.DamageClasses;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terbritish.Content.Globals;

namespace Terbritish.Content.Items.Lances.LanceItems
{
    public class LaSangreDeSancho : ModItem
    {

        public override void SetDefaults()
        {
            Item.DefaultToSpear(ModContent.ProjectileType<LaSangreDeSanchoProjectile>(), 1f, 24);
            Item.DamageType = ModContent.GetInstance<DonQuixoteDamage>();
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.damage = 20;
        }

        public override bool MeleePrefix() => true;

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float speed = velocity.Length();
            velocity = new Vector2(player.direction * speed, 0f);
            position += new Vector2(player.direction * 40f, 0f);
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void HoldItem(Player player)
        {
            player.itemRotation = 0f;
            var LancePlayer = player.GetModPlayer<LancePlayer>();
            var LanceAcceleration = player.GetModPlayer<LanceAcceleration>();

            if (player.channel && player.HeldItem == Item)
            {
                LancePlayer.HoldingLance = true;
                LanceAcceleration.AccelTimer++;
                if (LanceAcceleration.AccelTimer >= 10 && LanceAcceleration.SpeedBoost < 10)
                {
                    player.velocity.X += player.direction + 0.2f;
                    LanceAcceleration.AccelTimer = 0;
                    LanceAcceleration.SpeedBoost++;
                }
            }
            else
            {
                LanceAcceleration.SpeedBoost = 0;
                LanceAcceleration.AccelTimer = 0;
                LancePlayer.HoldingLance = false;
            }
        }
    }
}