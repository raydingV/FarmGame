using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Coin;

    public int _coinValue;

    public Text woodCollectText;

    public GameObject interact, seller, shopMenu;

    PlayerManager playerManager;

    float distanceSellerX, distanceSellerY;
    void Start()
    {
        _coinValue = 0;
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    void Update()
    {
        woodCollectText.text = "Coin: " + _coinValue;

        distanceSellerX = Mathf.Abs(playerManager.transform.position.x - seller.transform.position.x);
        distanceSellerY = Mathf.Abs(playerManager.transform.position.y - seller.transform.position.y);

        if(distanceSellerX <= 1f && distanceSellerY - 1 <= 1f)
        {
            interact.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                shopMenu.SetActive(true);
            }
        }
        else
        {
            interact.SetActive(false);
            shopMenu.SetActive(false);
        }
    }
}
