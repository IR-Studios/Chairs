using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertedFuseHallway4 : MonoBehaviour
{
    FuseBox FB;
    bool happened;

    [Header("GameObjects")] 
    public GameObject chairToDespawn;
    public GameObject chairToSpawn;
    public GameObject Code;
    public AudioSource AS;
    public DrawerSystem DS;



    void Start() 
    {
        FB = GetComponent<FuseBox>();
    }

    void Update() 
    {
        if (FB.fuse && !happened)  
        {
            happened = true;
            chairToDespawn.SetActive(false);
            chairToSpawn.SetActive(true);
            Code.SetActive(true);

            AS.Play();
            DS.Interact();

        }
    }
}
