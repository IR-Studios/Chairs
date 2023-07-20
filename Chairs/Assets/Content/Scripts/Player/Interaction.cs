using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public float range;
    public GameObject cam;
    public Image crosshair;

    [Header("Crosshair")]
    public Color normalCrosshair;
    public Color highlightedCrosshair;

    void Start() 
    {
        cam = Camera.main.gameObject;
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        
        crosshair.color = normalCrosshair;
    }

   void Update() 
   {
        Interact();
   }

   void Interact() 
   {
        PlayerInventory PI = GetComponent<PlayerInventory>();


        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) 
        {
            if (hit.transform.CompareTag("flashlight") ||
            hit.transform.CompareTag("key") ||
            hit.transform.CompareTag("drawer") ||
            hit.transform.CompareTag("Door") ||
            hit.transform.CompareTag("numpad") ||
            hit.transform.CompareTag("fuse") ||
            hit.transform.CompareTag("fusebox") ||
            hit.transform.CompareTag("key") ||
            hit.transform.CompareTag("radio") ||
            hit.transform.CompareTag("lamp") || hit.transform.CompareTag("hook") ||
            hit.transform.CompareTag("weapon"))
            {
                if (crosshair != null) 
                {
                    crosshair.color = highlightedCrosshair;
                }
          

            if (hit.transform.tag == "flashlight") 
            {
                Key K = hit.transform.GetComponent<Key>();
                
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    if (K != null) 
                    {
                        KeyManager KM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KeyManager>();
                        KM.keyList[K.keyNum].keyAcquired = true;
                    }
                    PI.hasFlashlight = true;
                    Destroy(hit.transform.gameObject);
                }
                
            }  

            if (hit.transform.tag == "Door") //DEPRECATED
            {
                DoorBehavior DB = hit.transform.GetComponent<DoorBehavior>();
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    if (!DB.isOpen) 
                    {
                        DB.Open();
                    } else if (DB.isOpen) 
                    {
                        DB.Close();
                    }
                }
            }  

            if (hit.transform.tag == "numpad") 
            {
                NumpadItem NI = hit.transform.GetComponent<NumpadItem>();
                Numpad N = hit.transform.GetComponentInParent<Numpad>();

                if (Input.GetKeyDown(KeyCode.E) && N.isPowered) 
                {
                    N.beep.Play();
                    switch (N.currentNum) 
                    {
                        case 0: 
                        N.num1 = NI.number;
                        N.currentNum++;
                        N.DisplayText.text = N.num1.ToString();
                        break;
                        case 1:
                        N.num2 = NI.number;
                        N.currentNum++;
                        N.DisplayText.text = N.num1.ToString() + N.num2.ToString();
                        break;
                        case 2:
                        N.num3 = NI.number;
                        N.currentNum++;
                        N.DisplayText.text = N.num1.ToString() + N.num2.ToString() + N.num3.ToString();
                        break;
                        case 3:
                        N.num4 = NI.number;
                        N.currentNum++;
                        N.DisplayText.text = N.num1.ToString() + N.num2.ToString() + N.num3.ToString() + N.num4.ToString();
                        N.checkInput();
                        break;
                    }
                }
            }  

            if (hit.transform.tag == "fuse") 
            {
                Fuse fuse = hit.transform.GetComponent<Fuse>();


                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    if (!fuse.inserted) 
                    {
                        PI.hasFuse = true;
                        Destroy(hit.transform.gameObject);
                    } else if (fuse.inserted) 
                    {
                        FuseBox fusebox = hit.transform.GetComponentInParent<FuseBox>();
                        PI.hasFuse = true;
                        fusebox.fuse = false;
                        
                    }
                    
                }
            }  

            if (hit.transform.tag == "fusebox") 
            {
                FuseBox fusebox = hit.transform.GetComponent<FuseBox>();

                
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    if (PI.hasFuse) 
                    {
                        fusebox.InsertFuse();
                        PI.hasFuse = false;
                    }
                }
            }  
           
            if (hit.transform.tag == "key") 
            {
                Key K = hit.transform.GetComponent<Key>();
                KeyManager KM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<KeyManager>();
                
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    KM.keyList[K.keyNum].keyAcquired = true;
                    Destroy(hit.transform.gameObject);
                }
            } 

            if (hit.transform.tag == "drawer") 
            {

                DrawerSystem DS = hit.transform.GetComponent<DrawerSystem>();

                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    DS.Interact();
                }
            }  

            if (hit.transform.tag == "radio") 
            {

                Radio R = hit.transform.GetComponent<Radio>();

                if(Input.GetKeyDown(KeyCode.E))
                {
                    R.Interact();
                }
            }  

            if (hit.transform.tag == "lamp")
            {

                Lamp L = hit.transform.GetComponent<Lamp>();

                if(Input.GetKeyDown(KeyCode.E))
                {
                    L.Interact();
                }
            } 
            if (hit.transform.tag == "hook")
            {

                Hook hook = hit.transform.GetComponent<Hook>();

                if(Input.GetKeyDown(KeyCode.E))
                {
                    hook.rope.SetActive(true);
                    hook.ropeInHand.SetActive(false);
                    hook.chair.SetActive(false);
                    hook.door.doorLocked = true;
                    hook.music.Stop();
                    hook.hasRope = true;
                    hook.safeSound.Play();
                    hook.banging.Play();

                    hook.chairsToDespawn1.SetActive(false);
                    hook.chairsToDespawn2.SetActive(false);

                    FirstPersonAIO player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonAIO>();
                    player.sprintSpeed = 3;
                }
            } 
            if (hit.transform.tag == "weapon") 
            {
                if (Input.GetKeyDown(KeyCode.E) && !PI.hasShotgun) 
                {
                    PI.hasShotgun = true;
                    PI.Shotgun.SetActive(true);
                    Shotgun shotgun = PI.Shotgun.GetComponent<Shotgun>();
                    shotgun.FirstDraw();
                    Destroy(hit.transform.gameObject);
                }
            }

            }  else 
            {
                crosshair.color = normalCrosshair;
            } 
        } else 
        {
            crosshair.color = normalCrosshair;
        }
   }
}
