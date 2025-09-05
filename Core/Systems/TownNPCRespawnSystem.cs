using System.IO;
using Terraria.ModLoader.IO;


using Terbritish.Content.NPCs;
using Terbritish.Content.NPCs.DapperChapper;

namespace Terbritish.Core.Systems
{
	// This class tracks if specific Town NPC have ever spawned in this world. If they have, then their spawn conditions are not required anymore to respawn in the same world. This behavior is new to Terraria v1.4.4 and is not automatic, it needs code to support it.
	// Spawn conditions that can't be undone, such as defeating bosses, would not require tracking like this since those conditions will still be true when the Town NPC attempts to respawn. Spawn conditions checking for items in the player inventory like ExamplePerson does, for example, would need tracking.
	public class TownNPCRespawnSystem : ModSystem
	{
		// Tracks if Dapper Chapper has ever been spawned in this world
		public static bool unlockedDapperChapperSpawn = false;

		// Town NPC rescued in the world would follow a similar implementation, the only difference being how the value is set to true.
		// public static bool savedDapperChapper = false;

		public override void ClearWorld() {
			unlockedDapperChapperSpawn = false;
		}

		public override void SaveWorldData(TagCompound tag) {
			tag[nameof(unlockedDapperChapperSpawn)] = unlockedDapperChapperSpawn;
		}

		public override void LoadWorldData(TagCompound tag) {
			unlockedDapperChapperSpawn = tag.GetBool(nameof(unlockedDapperChapperSpawn));

			// This line sets unlockedDapperChapperSpawn to true if an Dapper Chapper is already in the world. This is only needed because unlockedDapperChapperSpawn was added in an update to this mod, meaning that existing users might have unlockedDapperChapperSpawn incorrectly set to false.
			// If you are tracking Town NPC unlocks from your initial mod release, then this isn't necessary.
			unlockedDapperChapperSpawn |= NPC.AnyNPCs(ModContent.NPCType<DapperChapper>());
		}

		public override void NetSend(BinaryWriter writer) {
			writer.WriteFlags(unlockedDapperChapperSpawn);
		}

		public override void NetReceive(BinaryReader reader) {
			reader.ReadFlags(out unlockedDapperChapperSpawn);
		}
	}
}
