using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    Transform player;

    public float speed;

    public Animator anim;

    [SerializeField]
    float agroRange;

    public GameObject ghostenemy;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

        speed = 1f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log(distToPlayer);
        if (distToPlayer < agroRange)
        {
            chasePlayer();
        }
        else
        {
            StopChasingplayer();

        }
    }

    void StopChasingplayer()
    {
        rb.velocity = new Vector2 (0, 0);
    }

    void chasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(speed, 0f);
            transform.localScale = new Vector2(-1, 1);

        }
        else 
        {
            rb.velocity = new Vector2 (-speed, 0f);
            transform.localScale = new Vector2(1, 1);
        }
    }
}