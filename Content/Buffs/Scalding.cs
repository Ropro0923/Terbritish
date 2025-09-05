


namespace Terbritish.Content.Buffs
{
	public class Scalding : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<ScaldingPlayer>().scalding = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (npc.lifeRegen > 0)
				npc.lifeRegen = 0;

			npc.lifeRegen -= 8;

			if (npc.buffTime[buffIndex] % 60 == 0) // once per second
			{	
				npc.damage = 2; // displayed damage
			}
		}

		public class ScaldingPlayer : ModPlayer
		{
			public bool scalding;

			public override void ResetEffects()
			{
				scalding = false;
			}

			public override void UpdateBadLifeRegen()
			{
				if (scalding)
				{
					if (Player.lifeRegen > 0)
					Player.lifeRegen = 0;
					Player.lifeRegenTime = 0;
					Player.lifeRegen -= 16;
				}
			}
		}
	}
}
