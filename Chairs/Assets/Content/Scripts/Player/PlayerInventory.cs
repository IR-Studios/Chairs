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
          DrawWeapons();
   }

   void CheckInventory() 
   {
        Flashlight.active = hasFlashlight;
   }

   void DrawWeapons() 
   {
     Shotgun gun = Shotgun.GetComponent<Shotgun>();
     if (Input.GetKeyDown(KeyCode.Alpha1) && hasShotgun) 
        {
            if (gun.isDrawn) 
            {
                gun.ShotgunPutAway();
            } else {
               Shotgun.SetActive(true);
                gun.ShotgunDraw();
            }
        }
   }
}
