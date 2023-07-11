using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChairH5 : MonoBehaviour
{
    public GameObject chair;

    void OnTriggerEnter(Collider other) 
    {
        chair.SetActive(true);
    }
}
