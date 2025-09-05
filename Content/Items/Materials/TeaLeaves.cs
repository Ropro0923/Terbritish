


namespace Terbritish.Content.Items.Materials
{
	public class TeaLeaves : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = Item.CommonMaxStack;
			Item.value = Item.buyPrice(silver: 1);
		}
	}
}
