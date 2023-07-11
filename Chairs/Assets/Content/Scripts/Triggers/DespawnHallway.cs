using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnHallway : MonoBehaviour
{
    public int HallwayToDespawn;
    public int HallwayToSpawn;

    HallwayManager HM;

    void Start() 
    {
        HM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<HallwayManager>();
        HallwayToSpawn = HallwayToDespawn + 3;
    }


    public void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            HM.Hallways[HallwayToDespawn].SetActive(false);
            HM.Hallways[HallwayToSpawn].SetActive(true);
        }
    }
}
