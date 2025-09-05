


namespace Terbritish.Content
{
    public class ScaldingGlobalNPC : GlobalNPC
    {
        // Keep track if NPC has the debuff
        public bool scalding;

        public override bool InstancePerEntity => true; // One instance per NPC

        public override void ResetEffects(NPC npc)
        {
            scalding = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (scalding)
            {
                // Reduce life regen and add damage
                damage += 10;          // Damage per second applied
                npc.lifeRegen -= 20;   // Reduce life regeneration
            }
        }

        public override void PostAI(NPC npc)
        {
            if (scalding)
            {
            }
        }
    }
}
