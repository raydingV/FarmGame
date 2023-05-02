using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceObject : MonoBehaviour
{
    PlayerManager playerManager;
    GameManager gameManager;

    bool Click = false;

    float distX , distY;

    [SerializeField] float rangeX, rangeY;
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
        Debug.Log("x: " + distX + "y: " + distY);
        if (distX <= rangeX && distY <= rangeY)
        {
            Click = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Distance")
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

}
