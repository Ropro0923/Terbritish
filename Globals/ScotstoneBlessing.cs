        using System;
        using System.Threading;
        using Terbritish.Content.Tiles;
        using Microsoft.Xna.Framework;
        using Terraria;
        using Terraria.Chat;
        using Terraria.ID;
        using Terraria.Localization;
        using Terraria.ModLoader;
        using Terraria.ModLoader.IO;

        namespace Terbritish.Globals
        {
            public class ScotstoneBlessing : ModSystem
            {
                public static LocalizedText ScotstoneBlessMessage1 { get; private set; }
                public static LocalizedText ScotstoneBlessMessage2 { get; private set; }

                private static bool hasBlessedScotstone;

                public override void SetStaticDefaults()
                {
                    ScotstoneBlessMessage1 = Language.GetText("ScotstoneBlessMessage1");
                    ScotstoneBlessMessage2 = Language.GetText("ScotstoneBlessMessage2");
                }

                public override void OnWorldLoad()
                {
                    hasBlessedScotstone = false;
                }

                public override void SaveWorldData(TagCompound tag)
                {
                    tag["HasBlessedScotstone"] = hasBlessedScotstone;
                }

                public override void LoadWorldData(TagCompound tag)
                {
                    hasBlessedScotstone = tag.GetBool("HasBlessedScotstone");
                }

                public static void BlessWorldWithScotstone()
                {
                    if (Main.netMode == NetmodeID.MultiplayerClient || hasBlessedScotstone)
                        return;

                    hasBlessedScotstone = true;

                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        // Gently notify the player(s) of their newfound blessing
                        if (Main.netMode == NetmodeID.SinglePlayer && ScotstoneBlessMessage1 != null)
                        {
                            Main.NewText(ScotstoneBlessMessage1.Value, 67, 128, 28);
                        }
                        else if (Main.netMode == NetmodeID.Server && ScotstoneBlessMessage2 != null)
                        {
                            ChatHelper.BroadcastChatMessage(ScotstoneBlessMessage2.ToNetworkText(), new Color(67, 128, 28));
                        }

                        int totalVeins = (int)(361f * (Main.maxTilesX / 4200f));
                        int cavernStartY = (int)Utils.Lerp(Main.worldSurface, Main.UnderworldLayer, 0.325);

                        for (int i = 0; i < totalVeins; i++)
                        {
                            int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                            int y = WorldGen.genRand.Next(cavernStartY, Main.UnderworldLayer);

                            double strength = WorldGen.genRand.Next(6, 9);
                            int steps = WorldGen.genRand.Next(7, 11);

                            WorldGen.OreRunner(x, y, strength, steps, (ushort)ModContent.TileType<Scotstone>());

                            if (Main.netMode == NetmodeID.Server)
                            {
                                NetMessage.SendTileSquare(-1, x, y, 10);
                            }
                        }
                    });
                }
            }

            public class ScotestoneBlessing : GlobalNPC
            {
                public override bool AppliesToEntity(NPC npc, bool lateInstantiation)
                {
                    return npc.type == NPCID.WallofFlesh;
                }

                public override void OnKill(NPC npc)
                {
                    if (!Main.hardMode)
                    {
                        ScotstoneBlessing.BlessWorldWithScotstone();
                    }
                }
            }
        }