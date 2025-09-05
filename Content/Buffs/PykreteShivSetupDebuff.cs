


using Terraria.ID;
using Terraria.Localization;


namespace Terbritish.Content.Buffs
{
    public class PykreteShivSetupDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; //ICON DOES NOT MATTER FOR COMBO SETUP DEBUFFS, IT WILL NEVER BE SEEN
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
           
            if (Main.rand.NextBool(3))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.BorealWood,
                    npc.velocity.X * 1.43f, npc.velocity.Y * 1.43f, 50, default, 1.95f);
                Main.dust[dust].noGravity = true;
            }
            if (Main.rand.NextBool(10))
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.IceTorch,
                     npc.velocity.X * 1.43f, npc.velocity.Y * 1.43f, 70, default, 1.25f);
                Main.dust[dust].noGravity = true;
            }
           
        }
    }
}