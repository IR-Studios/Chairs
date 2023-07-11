using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChair : MonoBehaviour
{
    public GameObject Chair01, Chair02;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            Chair01.SetActive(false);
            Chair02.SetActive(true);
        }
    }
}
