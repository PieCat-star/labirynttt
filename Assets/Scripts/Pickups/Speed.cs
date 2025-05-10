using UnityEngine;

public class Speed : Pickup
{
    public int time = 5;
    public float speedModifier = 2f;
    public override void PickedUp()
    {
        base.PickedUp();
        GameManager.gameManager.SetSpeedModifier(speedModifier, time);
    }
}
