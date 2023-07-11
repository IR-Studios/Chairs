using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public List<Keys> keyList = new List<Keys>();
}

[System.Serializable]
public class Keys 
{
    public bool keyAcquired;
    public int keyNum;
}
