using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLoad : MonoBehaviour
{
    public bool isFirstLoad = true;

    void Start()   
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
