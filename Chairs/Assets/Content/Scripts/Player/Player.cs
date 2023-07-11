using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Vitals")]
    public int health;

    [Header("Other")]
    public bool inJumpscare;
    public bool isDead;

    public void dead() 
    {
        inJumpscare = false;
        isDead = true;

        DeathScreen DS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathScreen>();
        DS.Menu.SetActive(true);
    }
}
