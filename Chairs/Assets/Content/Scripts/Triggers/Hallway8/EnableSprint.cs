using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSprint : MonoBehaviour
{
    FirstPersonAIO player;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            player = other.GetComponent<FirstPersonAIO>();
            player.sprintSpeed = 7;
        }
    }
}
