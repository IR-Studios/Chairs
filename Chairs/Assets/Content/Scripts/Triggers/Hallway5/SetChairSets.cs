using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChairSets : MonoBehaviour
{
    public GameObject ChairSet01, ChairSet02;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            ChairSet01.SetActive(false);
            ChairSet02.SetActive(true);
        }
    }
}
