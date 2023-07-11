using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextTrigger : MonoBehaviour
{
    public GameObject TriggerToSpawn;
    public AudioSource sound;
    bool entered = false;


    public void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            if (!entered) 
            {
                TriggerToSpawn.SetActive(true);
                sound.Play();
                entered = true;
            }
            
        }
    }
}
