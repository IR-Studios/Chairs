using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    [Tooltip("Whether or not the fusebox has the fuse inserted")]
    public bool fuse;
    [Header("Gameobjects")]
    public GameObject fuseObject;
    [Header("References")]
    public Numpad itemToPower;

    public void Update() 
    {
        CheckforFuse();

        if (!fuse) 
        {
            fuseObject.SetActive(false);
        }
    }

    public void CheckforFuse() 
    {
        if (itemToPower != null) 
        {
             if (fuse) 
            {
                itemToPower.isPowered = true;
            } else 
            {
            itemToPower.isPowered = false;
            }
        }
       
    }

    public void InsertFuse() 
    {
        fuse = true;
        fuseObject.SetActive(true);   
        if (itemToPower != null) 
        {
            itemToPower.DisplayText.text = "";
            Debug.Log("test");
        }
       
    }
   
}
