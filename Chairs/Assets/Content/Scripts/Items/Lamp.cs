using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light pointLight;
    public Light spotLight;
    public bool isActive = true;

    public void Interact()
    {
        if(isActive)
        {
            pointLight.enabled = false;
            spotLight.enabled = false;
            isActive = false;
        }
        else
        {
            pointLight.enabled = true;
            spotLight.enabled = true;
            isActive = true;
        }
    }

}
