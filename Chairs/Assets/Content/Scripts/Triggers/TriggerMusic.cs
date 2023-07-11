using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    public Hook hook;
    public AudioSource music;
    bool isEntered;

    void OnTriggerEnter (Collider other) 
    {
        if (other.tag == "Player") 
        {
            if (!isEntered) 
            {   
                if (hook.hasRope) 
                {
                    music.Play();
                    isEntered = true;
                }
               
            }
        }
    }
}
