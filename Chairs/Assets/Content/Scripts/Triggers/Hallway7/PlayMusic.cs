using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource music;
    bool isEntered;

    void OnTriggerEnter (Collider other) 
    {
        if (other.tag == "Player") 
        {
            if (!isEntered) 
            {
                music.Play();
                isEntered = true;
            }
        }
    }
}
