using UnityEngine;

public class AddTime : Pickup
{
   public int timeModifier = 5;

    public override void PickedUp()
    {
        GameManager.gameManager.PlayAudioClip(pickupSound);
        base.PickedUp();
        GameManager.gameManager.AddTime(timeModifier);
    }
}
