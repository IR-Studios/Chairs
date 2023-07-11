using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnChairH7 : MonoBehaviour
{
   public GameObject chair;
   public Light spotLight;
   public Light pointLight;

   public AudioSource hit;

   bool isEntered = false;

   void OnTriggerEnter(Collider other) 
   {
        if (other.tag == "Player") 
        {
            if (!isEntered) 
            {
                spotLight.intensity = 0f;
                pointLight.intensity = 0f;
                chair.SetActive(false);
                hit.Play();isEntered = true;
            }
         
   
            
        }
   }
}
