namespace Terbritish.Content.Items.Knives
{
    public class ExampleKnife : BaseKnifeItem
    {
        public override string Knife => "DawnsEnd";
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.damage = 87;
            Item.knockBack = 1.75f;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(0, 0, 0, 10);
            Item.shootSpeed = 4.5f;
        }
    }
    public class ExampleKnifeThrown : BaseKnifeThrown
    {
        public override string Knife => "DawnsEnd";
    }
    public class ExampleKnifeStab : BaseKnifeStab
    {
        public override string Knife => "DawnsEnd";
    }
}