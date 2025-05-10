using UnityEngine;

public class FreezeTime : Pickup
{
    public int freezeTime = 5;
    public override void PickedUp()
    {
        base.PickedUp();
        GameManager.gameManager.FreezeTime(freezeTime);
    }
}


