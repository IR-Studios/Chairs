using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
   [Header("Does the Player have this?")]
   public bool hasFlashlight;
   public bool hasPistol;
   public bool hasShotgun;
   public bool hasFuse;
   public bool hasRope;

   [Header("Inventory Ints")]
   public int shotgunShells;

   [Header("Inventory Objects")]
   public GameObject Flashlight;
   public GameObject Shotgun;

   void Update() 
   {
        CheckInventory();
   }

   void CheckInventory() 
   {
        Flashlight.active = hasFlashlight;
   }
}
