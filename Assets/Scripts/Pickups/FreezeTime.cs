using UnityEngine;

public class FreezeTime : Pickup
{
    public int freezeTime = 5;
    public override void PickedUp()
    {
        GameManager.gameManager.PlayAudioClip(pickupSound);
        base.PickedUp();
        GameManager.gameManager.FreezeTime(freezeTime);
    }
}


