using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorBehavior : MonoBehaviour
{
    public bool isOpen;
    public bool needsKey;
    public int keyNum;
    public Animation DoorAnim;

    public AudioSource DoorAudio;

    void Start() 
    {
        isOpen = false;
    }

    public void Open() 
    {
        DoorAnim.Play("_DefaultDoorOpen");
        DoorAudio.Play();
        isOpen = true;
    }

    public void Close() 
    {
        DoorAnim.Play("_DefaultDoorClose");
        isOpen = false;
    }
}
