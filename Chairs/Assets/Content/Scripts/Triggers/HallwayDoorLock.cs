using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayDoorLock : MonoBehaviour
{
    public DoorSystem DS;
    public bool firstHallway;
    public GameObject Chair;

    private bool entered;

    [Header("Audio")]
    public AudioSource doorLock;
    public AudioSource chairSlide;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && !entered) 
        {
            DS.requiresKey = false;
            DS.doorLocked = true;
            if (doorLock != null) 
            {
                doorLock.Play();
            }
            entered = true;
           

            if (firstHallway) 
            {
                Chair.SetActive(true);
                chairSlide.Play();
            }
        }
    }   
}
