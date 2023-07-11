using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomSpawner : MonoBehaviour
{
    public GameObject Chair;

    bool isEntered;

    void OnTriggerEnter (Collider other) 
    {
        if (other.tag == "Player") 
        {
            if (!isEntered) 
            {
                Chair.SetActive(true);
                isEntered = true;
            }
        }
    }
}
