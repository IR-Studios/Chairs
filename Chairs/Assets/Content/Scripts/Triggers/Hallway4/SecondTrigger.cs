using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondTrigger : MonoBehaviour
{
    public GameObject chair;
    public GameObject ThirdTrigger;
    public AudioSource Audio;

    bool entered;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") 
        {
            if (!entered) 
            {
                chair.SetActive(true);
                ThirdTrigger.SetActive(true);
                Audio.Play();
                entered = true;
            }
        }
    }
}
