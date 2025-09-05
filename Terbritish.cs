global using Terraria.ModLoader;
global using Terraria;
global using System;
global using Terraria.ID;
global using Microsoft.Xna.Framework;
using System.IO;
using Terbritish.Content.NPCs.DapperChapper;

namespace Terbritish
{
	public class Terbritish : Mod
	{
		public override void Load()
		{
			TerbritishConfig.Instance = ModContent.GetInstance<TerbritishConfig>();
		}

		public override void Unload()
		{
			TerbritishConfig.Instance = null;
		}

		internal enum MessageType : byte
		{
			DapperChapperTeleportToStatue,
		}
		public override void HandlePacket(BinaryReader reader, int whoAmI)
		{
			MessageType msgType = (MessageType)reader.ReadByte();

			switch (msgType)
			{
				case MessageType.DapperChapperTeleportToStatue:
					if (Main.npc[reader.ReadByte()].ModNPC is DapperChapper person && person.NPC.active)
					{
						person.StatueTeleport();
					}
					break;
			}
		}
	}
}