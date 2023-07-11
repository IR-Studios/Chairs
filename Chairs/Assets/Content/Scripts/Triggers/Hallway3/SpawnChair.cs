using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChair : MonoBehaviour
{
   public GameObject Chair;
   public GameObject secondTrigger;

   public Light spotlight;

   public AudioSource sound;

   public AudioSource chairSound;

   bool isEntered;

   void OnTriggerEnter(Collider other) 
   {
        if (other.tag == "Player") 
        {
            if (!isEntered) 
            {
                chairSound.Play();
                spotlight.intensity = 1f;
                Chair.SetActive(true);
                secondTrigger.SetActive(true);

                sound.Play();
                isEntered = true;
            }
        }

      
   }
}
