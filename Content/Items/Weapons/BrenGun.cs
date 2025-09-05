    using Terraria.ID;
    
    
    using Microsoft.Xna.Framework;
    using Terraria.DataStructures;
    using Microsoft.Xna.Framework.Graphics;

    namespace Terbritish.Content.Items.Weapons
    {
        public class BrenGun : ModItem
        {
            public override void SetDefaults()
            {
                Item.width = 62;
                Item.height = 32;
                Item.scale = 0.75f;
                Item.rare = ItemRarityID.Orange;
                Item.value = 119000;
                Item.useTime = 9;
                Item.useAnimation = 9;
                Item.useStyle = ItemUseStyleID.Shoot;
                Item.autoReuse = true;
                Item.UseSound = Terraria.ID.SoundID.Item70;
                Item.DamageType = DamageClass.Ranged;
                Item.damage = 16;
                Item.knockBack = 1.5f;
                Item.noMelee = true;
                Item.shoot = ProjectileID.Bullet; 
                Item.shootSpeed = 11.15f;
                Item.useAmmo = AmmoID.Bullet;
            }
            public override bool CanConsumeAmmo(Item ammo, Player player)
            {
                return Main.rand.NextFloat() >= 0.25f;
            }
            public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
            {
                const int NumProjectiles = 1;

                for (int i = 0; i < NumProjectiles; i++)
                {
                    Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(4.25f));
                    newVelocity *= 1f - Main.rand.NextFloat(0.295f);
                    Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
                }

                return false; // Return false because we don't want tModLoader to shoot projectile
            }
            public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
            {
                // Offset forward in the direction you're aiming
                Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;

                // Add upward offset (negative Y = up in Terraria)
                Vector2 verticalOffset = new Vector2(2, -2.5f);

                // Only apply the forward offset if it doesn't hit a wall
                if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                {
                    position += muzzleOffset;
                }

                // Always apply the upward offset
                position += verticalOffset;
            }

            public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
            {
                scale = 0.7f;

                Texture2D texture = Terraria.GameContent.TextureAssets.Item[Item.type].Value;
                Vector2 position = Item.position - Main.screenPosition + new Vector2(Item.width / 2, Item.height - texture.Height * 0.5f);

                spriteBatch.Draw(texture, position, null, lightColor, rotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0f);

                return false;
            }

            public override void AddRecipes()
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.PewMaticHorn);
                recipe.AddIngredient(ItemID.IllegalGunParts);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
            }

            public override Vector2? HoldoutOffset()
            {
                return new Vector2(-36f, -1f);
            }
        }
    }