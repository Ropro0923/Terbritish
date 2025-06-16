using System;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using System.Reflection;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;
using Terraria.UI;
using Fargowiltas.Items.CaughtNPCs;
using Terbritish.CrossMod.Fargowiltas;
using Terbritish.Core;

namespace Terbritish
{
	public partial class Terbritish : Mod
	{
		public override void Load()
		{
			//
		}

		public override void Unload()
		{
			//
		}
	}

	
	[ExtendsFromMod(ModCompatibility.Fargowiltas.Name)]
    [JITWhenModsEnabled(ModCompatibility.Fargowiltas.Name)]
	public partial class TerbritishFargowiltas : ModSystem
	{
		internal static Terbritish Instance;
		public static readonly BindingFlags UniversalBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

		public static void Add(string internalName, int id)
		{
			if (ModLoader.TryGetMod("Fargowiltas", out Mod fgw))
			{
				if (Instance == null)
				{
					Instance = ModContent.GetInstance<Terbritish>();
				}
				CaughtNPCItem item = new(internalName, id);
				TerbritishFargowiltas.Instance.AddContent(item);
				FieldInfo info = typeof(CaughtNPCItem).GetField("CaughtTownies", UniversalBindingFlags);
				Dictionary<int, int> list = (Dictionary<int, int>)info.GetValue(info);
				list.Add(id, item.Type);
				info.SetValue(info, list);
			}
		}

		public override void Load()
		{
			if (ModLoader.TryGetMod("Fargowiltas", out Mod fgw))
			{
				TerbritishCaughtNpcs.RegisterItems();
			}

		}

		public override void Unload()
		{

		}
	}
}
