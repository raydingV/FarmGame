using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceObject : MonoBehaviour
{
    PlayerManager playerManager;
    GameManager gameManager;

    bool Click = false;

    float distX , distY;
    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        distX = Mathf.Abs(playerManager.transform.position.x - transform.position.x);
        distY = Mathf.Abs(playerManager.transform.position.y - (transform.position.y + 1));

        if (Click && playerManager.slot == 1 && playerManager.clickEvent)
        {
            Destroy(gameObject);
            Instantiate(gameManager.Coin, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }

    private void OnMouseDown()
    {
        if (distX <= 1.25f && distY <= 1.25f)
        {
            Click = true;
        }
    }
}
