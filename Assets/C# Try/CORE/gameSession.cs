using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;





public class gameSession : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI usingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int Score = 0;
        Score += (int)Time.fixedTime;
        usingText.text = Score.ToString();  
       // Debug.Log(Score);
    }
}
