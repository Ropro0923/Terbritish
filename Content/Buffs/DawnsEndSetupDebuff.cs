


using Terraria.ID;
using Terraria.Localization;


namespace Terbritish.Content.Buffs
{
    public class DawnsEndSetupDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; //ICON DOES NOT MATTER FOR COMBO SETUP DEBUFFS, IT WILL NEVER BE SEEN
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
           
            if (Main.rand.NextBool(2))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Demonite,
                    npc.velocity.X * 0.88f, npc.velocity.Y * 0.88f, 66, default, 1.95f);
                Main.dust[dust].noGravity = true;
            }
           
        }


    }
}