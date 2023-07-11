using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isActive = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if(isActive)
        {
            audioSource.enabled = false;
            isActive = false;
        }
        else
        { 
            audioSource.enabled = true;
            isActive = true;
            audioSource.Play();
        }
        
    }
}
