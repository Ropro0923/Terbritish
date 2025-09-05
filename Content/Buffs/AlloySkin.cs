

using Terraria.Localization;


namespace Terbritish.Content.Buffs
{
    public class AlloySkin : ModBuff
    {
        public static readonly int DefenseBonus = 10;
       

        public override LocalizedText Description => base.Description.WithFormatArgs(DefenseBonus);

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += DefenseBonus; // Grant a +10 defense boost to the player while the buff is active.
            
        }
    }
}