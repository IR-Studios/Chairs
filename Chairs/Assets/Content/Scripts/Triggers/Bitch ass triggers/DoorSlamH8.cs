using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlamH8 : MonoBehaviour
{
    public Animation A;
    public Light groundLight, groundLight2, lampSpotlight, lampPointlight;
    public PointLightFlicker PF;
    bool isEntered = false;

    void OnTriggerEnter (Collider other) 
    {
        if (other.tag == "Player") 
        {
            if(!isEntered) 
            {
                groundLight.enabled = false;
                groundLight2.enabled = false;
                lampPointlight.enabled = false;
                lampSpotlight.enabled = false;
                PF.flickering = false;
                foreach(Light L in PF.pointLights) 
                {  
                    L.enabled = false;
                }

                A.Play();
                isEntered = true;
            }
            
        }
    }
}
