using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    public bool requiresKey; //Does this door require a key to open?
    public int keyNum; //The number of the key required for the GameManager to recognize

    [Header("Doors")]
    public bool doorLocked;
    public GameObject LockedDoor;
    public GameObject UnlockedDoor;

    [Header("Audio")] 
    public AudioSource Audio;

    //References
    KeyManager KM;

    void Start() 
    {
        KM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KeyManager>();
        Audio = GetComponent<AudioSource>();
      
    }

    public void Update() 
    {
        enabledCorrectDoor();
        CheckforKey();
    }

    void CheckforKey() 
    {
        if (requiresKey) 
        {
            foreach (Keys key in KM.keyList) 
            {
                if (key.keyNum == keyNum) 
                {
                    if (key.keyAcquired) 
                    {
                        doorLocked = false;
                    }
                }
            }
        }
        
    }

    void enabledCorrectDoor() 
    {
        if (doorLocked) 
        {
            UnlockedDoor.SetActive(false);
            LockedDoor.SetActive(true);
        }
        else if (!doorLocked) 
        {
            LockedDoor.SetActive(false);
            UnlockedDoor.SetActive(true);
        }
    }
}
