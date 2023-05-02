using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Coin;

    public int _coinValue;

    public Text woodCollectText, _loadScreenText;

    public GameObject interact, seller, shopMenu, door,doorAnimOpen, doorAnimClose, house, outside, loadScreen, slots;


    PlayerManager playerManager;

    float distanceSellerX, distanceSellerY, distanceDoorX, distanceDoorY;
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

        distanceDoorX = Mathf.Abs(playerManager.transform.position.x - door.transform.position.x);
        distanceDoorY = Mathf.Abs(playerManager.transform.position.y - door.transform.position.y);

        if (distanceSellerX <= 1f && distanceSellerY - 1 <= 1f)
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

        if (distanceDoorX <= 1f && distanceDoorY - 1 <= 1f)
        {
            doorAnimOpen.SetActive(true);
            doorAnimClose.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Entered");
                StartCoroutine(HouseEnter());
            }
        }
        else
        {
            doorAnimOpen.SetActive(false);
            doorAnimClose.SetActive(true);
        }
    }

    IEnumerator HouseEnter()
    {
        loadScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        outside.SetActive(false);
        house.SetActive(true);
        loadScreen.SetActive(false);
        slots.SetActive(false);
    }

    public IEnumerator HouseExit()
    {
        loadScreen.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading.";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading..";
        yield return new WaitForSeconds(0.5f);
        _loadScreenText.text = "Loading...";
        yield return new WaitForSeconds(0.5f);
        house.SetActive(false);
        outside.SetActive(true);
        loadScreen.SetActive(false);
        slots.SetActive(true);
    }
}
