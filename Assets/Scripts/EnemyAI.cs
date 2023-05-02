using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject playerValues;

    float distance, step;
    void Start()
    {
        step = 0.5f * Time.deltaTime;
    }

    void Update()
    {
        distance = Vector3.Distance(playerValues.transform.position, transform.position);
        if (distance < 20f)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerValues.transform.position, step);
        }
    }
}
