using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn; //is the flashlight on or off?
    public Light lightSource;
    public AudioSource Audio;

    void Update() 
    {
        lightSource.enabled = isOn;
        toggleFlashlight();
    }   

    void toggleFlashlight() 
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            isOn = !isOn;
            Audio.Play();
        }
    }
}
