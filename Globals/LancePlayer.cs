using Terraria;
using Terraria.ModLoader;

public class LanceDirectionPlayer : ModPlayer
{

    public override void OnEnterWorld()
    {
        lockedDirection = 0;
    }

    public void LockDirection()
    {
        lockedDirection = Player.direction;
    }

    public override void PostUpdate()
    {
        if (lockedDirection != 0)
        {
            Player.direction = lockedDirection;
        }
    }
}
