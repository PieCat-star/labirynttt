using UnityEngine;

public class AddPoints : Pickup
{
    public int additionalPoints = 100;

    public override void PickedUp()
    {
        GameManager.gameManager.PlayAudioClip(pickupSound);
        base.PickedUp();
        GameManager.gameManager.AddPoints(additionalPoints);
    }
}
