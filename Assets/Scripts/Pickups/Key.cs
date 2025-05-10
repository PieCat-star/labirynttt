using UnityEngine;
public enum KeyType
{
    Red,
    Green,
    Golden
}
public class Key : Pickup
{
    public KeyType color;

    public override void PickedUp()
    {
        base.PickedUp();
        GameManager.gameManager.AddKey(color);
    }
}
