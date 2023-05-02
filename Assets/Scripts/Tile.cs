using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //[SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject _highlight;
    
    int tileSprite;
    PlayerManager player;
    GridManager grid;
    ShopNpc npc;


    public Vector2 positionTile;

    bool breakMove = false;

    public bool canDig, seed, busy = false;

    public GameObject[] tree;

    GameObject[] npcObjectsTag, treesTag;
    public void Init(bool isOffset)
    {
        //_renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    private void Start()
    {
        for (int i = 0; i < sprites.Length - 1; i++)
        {
            tileSprite = Random.Range(0, 16);
        }

        _renderer.sprite = sprites[tileSprite];

        npc = GameObject.Find("NPC").GetComponent<ShopNpc>();
        player = GameObject.Find("Player").GetComponent<PlayerManager>();
        grid = GameObject.Find("GridManager").GetComponent<GridManager>();

        npcObjectsTag = GameObject.FindGameObjectsWithTag("Distance");
        treesTag = GameObject.FindGameObjectsWithTag("Tree");

        int rand = Random.Range(0, 10);
        float distNpc, distTrees = 0;

        float dist = 0;

        for (int i = 0; i < npcObjectsTag.Length; i++)
        {
            distNpc = Vector3.Distance(gameObject.transform.position, npcObjectsTag[i].transform.position);

            if(distNpc < 8f)
            {
                dist = 0f;
                break;
            }
            else
            {
                dist = 1f;
            }
        }

        for (int j = 0; j < treesTag.Length; j++)
        {
            distTrees = Vector3.Distance(gameObject.transform.position, treesTag[j].transform.position);

            if(distTrees < 5f)
            {
                dist = 0f;
                break;
            }
            else
            {
                dist = 1f;
            }
        }

        if (rand == 0 && dist > 0f)
        {
            int a = Random.Range(0, 9);
            GameObject newTree = Instantiate(tree[a], gameObject.transform.position, Quaternion.identity);
            newTree.transform.parent = gameObject.transform;
        }

    }

    private void Update()
    {
        if(transform.childCount > 1)
        {
            busy = true;
        }
        else
        {
            busy = false;
        }

        _renderer.size += new Vector2(0.05f, 0.01f);
    }

    void OnMouseEnter()
    {
        float distX = Mathf.Abs(player.transform.position.x - transform.position.x);
        float distY = Mathf.Abs(player.transform.position.y - (transform.position.y + 1));
        //Debug.Log("distx: " + distX + " disty: " + distY);

        if (distX <= 1.5f && distY <= 1.5f && !busy && player.slot == 2)
        {
            _highlight.SetActive(true);
            canDig = true;
            seed = true;
        }
        //Debug.Log(gameObject.transform.position);
    }

    private void OnMouseDown()
    {
        //StopAllCoroutines();
        //StartCoroutine(move());
        if (canDig && player.slot == 2 && !busy)
        {
            _renderer.sprite = sprites[16];
            seed = true;
        }

        //if(seed)
        //{
        //    tree = Instantiate(tree, gameObject.transform.position, Quaternion.identity);
        //    busy = true;
        //}
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    IEnumerator move()
    {
        while (player.transform.position.x != transform.position.x)
        {
            float step = player.speed * Time.deltaTime;
            player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2(transform.position.x, player.transform.position.y), step);
            yield return new WaitForSeconds(0.0000001f);
            if(Input.GetMouseButtonDown(0) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                breakMove = true;
                break;
            }
            else
            {
                breakMove = false;
            }
        }

        if(!breakMove)
        {
            while (player.transform.position.y != transform.position.y)
            {
                float step = player.speed * Time.deltaTime;
                player.transform.position = Vector2.MoveTowards(player.transform.position, new Vector2(transform.position.x, transform.position.y), step);
                yield return new WaitForSeconds(0.0000001f);
                if (Input.GetMouseButtonDown(0) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
                {
                    break;
                }
            }
        }
    }
}
