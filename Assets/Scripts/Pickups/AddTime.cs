using UnityEngine;

public class AddTime : Pickup
{
   public int timeModifier = 5;

    public override void PickedUp()
    {
        base.PickedUp();
        GameManager.gameManager.AddTime(timeModifier);
    }
}
