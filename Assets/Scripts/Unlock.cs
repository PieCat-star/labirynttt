using Unity.VisualScripting;
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
            key.SetBool("useKey", CheckKey());
        }
    }
    public void UseKey()
    {
        foreach (var door in doors)
        {
            door.Open();
        }
    }
    public bool CheckKey() 
    {
        if(GameManager.gameManager.redKey>0 && myType==KeyType.Red)
        {
           unlocked = true;
            GameManager.gameManager.redKey--;
            return true;
        }
        else if (GameManager.gameManager.greenKey > 0 && myType == KeyType.Green)
        {
            unlocked = true;
            GameManager.gameManager.greenKey--;
            return true;
        }
        else if (GameManager.gameManager.goldenKey > 0 && myType == KeyType.Golden)
        {
            unlocked = true;
            GameManager.gameManager.goldenKey--;
            return true;
        }
        Debug.Log("You do not have the key to unlock this door");
        return false;
    }
}
