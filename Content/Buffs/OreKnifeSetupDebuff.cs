


using Terraria.ID;
using Terraria.Localization;


namespace Terbritish.Content.Buffs
{
    public class OreKnifeSetupDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; //ICON DOES NOT MATTER FOR COMBO SETUP DEBUFFS, IT WILL NEVER BE SEEN
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
           
            if (Main.rand.NextBool(11))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Copper,
                    npc.velocity.X * 0.79f, npc.velocity.Y * 0.79f, 70, default, 1.75f);
                Main.dust[dust].noGravity = true;
            }
            if (Main.rand.NextBool(11))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Tin,
                    npc.velocity.X * 0.79f, npc.velocity.Y * 0.79f, 70, default, 1.75f);
                Main.dust[dust].noGravity = true;
            }
            if (Main.rand.NextBool(11))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Iron,
                    npc.velocity.X * 0.79f, npc.velocity.Y * 0.79f, 70, default, 1.75f);
                Main.dust[dust].noGravity = true;
            }
            if (Main.rand.NextBool(11))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Lead,
                    npc.velocity.X * 0.79f, npc.velocity.Y * 0.79f, 70, default, 1.75f);
                Main.dust[dust].noGravity = true;
            }
            if (Main.rand.NextBool(12))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Silver,
                    npc.velocity.X * 0.79f, npc.velocity.Y * 0.79f, 70, default, 1.75f);
                Main.dust[dust].noGravity = true;
            }
            if (Main.rand.NextBool(12))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Tungsten,
                    npc.velocity.X * 0.79f, npc.velocity.Y * 0.79f, 70, default, 1.75f);
                Main.dust[dust].noGravity = true;
            }
            if (Main.rand.NextBool(12))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Gold,
                    npc.velocity.X * 0.79f, npc.velocity.Y * 0.79f, 70, default, 1.75f);
                Main.dust[dust].noGravity = true;
            }
            if (Main.rand.NextBool(12))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Platinum,
                    npc.velocity.X * 0.79f, npc.velocity.Y * 0.79f, 70, default, 1.75f);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}