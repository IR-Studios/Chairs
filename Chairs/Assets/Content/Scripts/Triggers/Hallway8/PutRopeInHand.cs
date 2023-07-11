using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRopeInHand : MonoBehaviour
{
   public GameObject ropeInHand;
   PlayerInventory PI;

   void OnDestroy() 
   {
        PI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        PI.hasRope = true;
        ropeInHand.SetActive(true);

   }
}
