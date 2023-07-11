using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusicH6 : MonoBehaviour
{
    public AudioSource music;
    bool isEntered = false;

    void OnTriggerEnter(Collider other) 
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
