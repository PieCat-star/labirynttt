using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int rotationSpeed = 100;
    public virtual void PickedUp()
    {
        Debug.Log("Picked up " + gameObject.name);
        Destroy(this.gameObject);
    }
    public void Rotate()
    {
        transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime, 0f,0f));
    }
    private void Update()
    {
        Rotate();
    }
}
