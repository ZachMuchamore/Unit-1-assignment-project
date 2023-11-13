using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    HelperScript helper;
    public float speed;
    private float distance;
    public Animator anim;
    public GameObject player;
    public GameObject ghostEnemy;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        speed = 1f;
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
        target = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x - ghostEnemy.transform.position.x;
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
        helper.DoRayCollisionCheck();
        print(distance);
        if (distance > 0)
        {
            transform.transform.localScale = new Vector3(-2f, 2f, 2f);
            print("flipped");
        }
        else
        {
            transform.transform.localScale = new Vector3(2f, 2f, 2f);
        }
        Debug.Log("dist=" + distance);

    }
}