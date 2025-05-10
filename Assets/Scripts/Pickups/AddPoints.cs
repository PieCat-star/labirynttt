using UnityEngine;

public class AddPoints : Pickup
{
    public int additionalPoints = 100;

    public override void PickedUp()
    {
        base.PickedUp();
        GameManager.gameManager.AddPoints(additionalPoints);
    }
}
