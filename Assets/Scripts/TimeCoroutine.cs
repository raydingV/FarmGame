using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCoroutine : MonoBehaviour
{
    [SerializeField] Text timeText;
    float timer;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        timeText.text = "Time: " + timer.ToString("F0");
    }
}
