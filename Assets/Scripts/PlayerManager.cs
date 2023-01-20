using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3f;
    public Animator anim;
    public Sprite[] _sprite;

    public GameObject[] slotsObject;

    public int slot = 1;
    Vector2 movement;

    SpriteRenderer playerSprite;

    public Tile tile;

    [SerializeField] Camera _camera;

    public bool clickEvent = false;

    GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            slot = 1;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            slot = 2;
        }

        switch(slot)
        {
            case 1:
                for (int i = 0; i < slotsObject.Length; i++)
                {
                    slotsObject[i].SetActive(false);
                }
                slotsObject[0].SetActive(true);
                break;

            case 2:
                for (int i = 0; i < slotsObject.Length; i++)
                {
                    slotsObject[i].SetActive(false);
                }
                slotsObject[1].SetActive(true);
                break;
        }

        if((movement.x == 0 && movement.y == 0))
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickEvent = true;
            }
        }
        else
        {
            clickEvent = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            gameManager._coinValue += 1;
        }
    }
}
