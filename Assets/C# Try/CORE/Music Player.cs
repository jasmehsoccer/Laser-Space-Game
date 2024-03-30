using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        setUpSingleton()
    }

    private void setUpSingleton()
    {
        if (FindAnyObjectByType (typeof(MusicPlayer)))  
    }
}
