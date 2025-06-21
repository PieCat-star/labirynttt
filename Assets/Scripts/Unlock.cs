using UnityEngine;

public class Unlock : MonoBehaviour
{
    public Door[] doors;
    public KeyType myType;
    bool canOpen;
    bool unlocked;

    Animator key;
    private void Start()
    {
        key = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
            Debug.Log("You can open the door");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
            Debug.Log("You cannot open the door");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !unlocked)
        {
            key.SetBool("useKey", true);
        }
    }
}
