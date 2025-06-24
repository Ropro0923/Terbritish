using Terraria;
using Terraria.ModLoader;
using Terbritish.Content.Items.Lances.LanceProjectiles;
using Terbritish.Content.DamageClasses;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terbritish.Content.Items.Lances.LanceItems
{
    public class ExampleTerbritishLance : ModItem
    {
        private int AfterSpeedTimer = 0;
        private int AfterSpeedBoost = 0;
        private int InitialSpeedTimer = 0;
        private int InitialSpeedBoost = 0;
        private int SpeedTimer = 0;

        public override void SetDefaults()
        {
            Item.DefaultToSpear(ModContent.ProjectileType<ExampleTerbritishLanceProjectile>(), 1f, 24);
            Item.DamageType = ModContent.GetInstance<BritishDamage>();
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

            if (player.channel && player.HeldItem == Item)
            {
                if (InitialSpeedBoost < 10)
                {
                    InitialSpeedTimer++;
                    if (InitialSpeedTimer >= 6)
                    {
                        InitialSpeedBoost++;
                        InitialSpeedTimer = 0;
                    }
                }
                else // InitialSpeedBoost == 10
                {
                    AfterSpeedTimer++;
                    if (AfterSpeedTimer >= 30)
                    {
                        AfterSpeedBoost++;
                        AfterSpeedTimer = 0;
                    }
                }
                float totalMphBoost = InitialSpeedBoost + AfterSpeedBoost;
                float pixelPerFrameBoost = totalMphBoost * 0.195f;

                SpeedTimer++;
                if (SpeedTimer >= 60)
                {
                    player.velocity.X += pixelPerFrameBoost * player.direction;
                    SpeedTimer = 0;
                }
            }
            else
            {
                InitialSpeedBoost = 0;
                InitialSpeedTimer = 0;
                AfterSpeedBoost = 0;
                AfterSpeedTimer = 0;
                SpeedTimer = 0;
            }
        }
    }
}