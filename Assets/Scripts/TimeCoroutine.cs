using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCoroutine : MonoBehaviour
{
    [SerializeField] Text timeText;
    float time;
    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + time.ToString("F0");
    }
}
