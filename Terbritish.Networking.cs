using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terbritish.Content.NPCs;

namespace Terbritish
{
	public partial class Terbritish
	{
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