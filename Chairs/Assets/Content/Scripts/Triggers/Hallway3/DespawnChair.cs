using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnChair : MonoBehaviour
{
    public GameObject Chair;
    public Light spotlight;
    public AudioSource audio;
    public AudioSource doorSlam;

    public Transform moveLocation;

    [Header("Lights")]
    public GameObject lightParent;
    Light[] lights;
    PointLightFlicker PF;

    bool isEntered;
    float duration = 1.5f; // Time taken to move the Chair


   void OnTriggerEnter(Collider other) 
   {
        if (other.tag == "Player") 
        {   
            if (!isEntered) 
            {
                lights = lightParent.GetComponentsInChildren<Light>();
                PF = lightParent.GetComponent<PointLightFlicker>();
                PF.flickering = false;

                StartCoroutine(disableChair());
            }
          
        }
    }

    IEnumerator disableChair() 
    {
        

        isEntered = true;
        spotlight.intensity = 0f;
        audio.Play();

        Vector3 initialPosition = Chair.transform.position;
        float elapsedTime = 0f;

        

       while (elapsedTime < duration)
    {
        Chair.transform.position = Vector3.Lerp(initialPosition, moveLocation.position, elapsedTime / duration);
        elapsedTime += Time.deltaTime;
        doorSlam.Play();

        // Calculate the normalized time for light intensity interpolation
        float normalizedTime = Mathf.Clamp01(elapsedTime / duration);

        // Update the intensity of each light in reverse order
        for (int i = lights.Length - 1; i >= 0; i--)
        {
            lights[i].intensity = Mathf.Lerp(0.2f, 0f, normalizedTime);
        }

   

        yield return null;
    }

        yield return new WaitForSeconds(1.5f);

        spotlight.intensity = 1f;
        Chair.SetActive(false);
    }
}
