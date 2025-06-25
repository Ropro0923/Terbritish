    using Terraria;
    using Terraria.ModLoader;

public class LanceAcceleration : ModPlayer
{
    public bool applyAccel;

    public override void ResetEffects()
    {
        applyAccel = false;
    }

    public override void PostUpdateMiscEffects()
    {
        if (applyAccel)
        {
            Player.Movespeed = 0.25f;
        }
    }
}