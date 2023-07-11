using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairJumpscare : MonoBehaviour
{
    public Animation jumpscare;
    public AudioSource jumpscareSound;
    public GameObject chairobj;
    public GameObject rope;
    public TriggerChairChase trigger;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            FirstPersonAIO player = other.GetComponent<FirstPersonAIO>();
            Player p = other.GetComponent<Player>();
          

            player.controllerPauseState = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            chairobj.SetActive(true);
            rope.SetActive(false);
            StartCoroutine(Startjumpscare(p));
            
            //this.gameObject.SetActive(false);
        }
    }

   IEnumerator Startjumpscare(Player p) 
    {
    DeathScreen DS = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeathScreen>();
    this.gameObject.transform.position = DS.chairRespawnPoint.position;

    trigger.StopAllCoroutines();
    jumpscare.Play();
    jumpscareSound.Play();
    
    p.inJumpscare = true;

    

    yield return new WaitForSeconds(3f);
    jumpscare.Stop();
    jumpscareSound.Stop();
    p.dead();
}
}
