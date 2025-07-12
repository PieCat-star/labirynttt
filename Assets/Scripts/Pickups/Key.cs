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

    public Material red;
    public Material green;
    public Material golden;

    private void Start()
    {
        SetColor();
    }
    void SetColor()
    {
        switch (color)
        {
            case KeyType.Red:
                GetComponent<Renderer>().material = red;
                break;
            case KeyType.Green:
                GetComponent<Renderer>().material = green;
                break;
            case KeyType.Golden:
                GetComponent<Renderer>().material = golden;
                break;
        }
    }

    public override void PickedUp()
    {
        GameManager.gameManager.PlayAudioClip(pickupSound);
        base.PickedUp();
        GameManager.gameManager.AddKey(color);
    }
}
