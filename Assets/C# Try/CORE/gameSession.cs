using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using JetBrains.Annotations;





public class gameSession : MonoBehaviour
{
    public static gameSession Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI usingText;
    public float mainGameTimer {get; private set;}
    // Start is called before the first frame update

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int Score = 0;
        int mainGameTimer = 0;
        Score += (int)Time.fixedTime;
        mainGameTimer += (int)Time.fixedTime;
        usingText.text = Score.ToString();  
        Debug.Log(mainGameTimer);
    }

    public float GetMainGameTimer() { 
        return mainGameTimer;
    
    }
}
