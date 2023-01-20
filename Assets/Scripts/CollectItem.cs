using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    float distance;
    PlayerManager player;
    float step;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerManager>();
        step = 1.5f * Time.deltaTime;
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);


        if (distance < 10.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }
    }
}
