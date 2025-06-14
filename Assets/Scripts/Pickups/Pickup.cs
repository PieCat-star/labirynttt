using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int rotationSpeedx = 100;
    public int rotationSpeedy = 100;
    public int rotationSpeedz = 100;
    public virtual void PickedUp()
    {
        Debug.Log("Picked up " + gameObject.name);
        Destroy(this.gameObject);
    }
    public void Rotate()
    {
        transform.Rotate(new Vector3(rotationSpeedx * Time.deltaTime,
         rotationSpeedy * Time.deltaTime,rotationSpeedz * Time.deltaTime));
    }
    private void Update()
    {
        Rotate();
    }
}
