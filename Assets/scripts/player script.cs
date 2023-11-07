using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public bool grounded;
    HelperScript helper;
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
        sr = GetComponent<SpriteRenderer>();
        print("start");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("player run", false);
        anim.SetBool("player jump", false);
        int speed = 2;
        if (Input.GetKey("x"))
        {
            helper.FlipObject(true);
        }
        if (Input.GetKey("a") == true) // move left
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("player run", true);
            print("player pressed left");
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }

        if (Input.GetKey("d") == true) // move right 
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("player run", true);
            print("player pressed right");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
        if (Input.GetKeyDown("space") == true)
        {
            anim.SetBool("player jump", true);
            rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("f") == true)
        {
            anim.SetTrigger("player attack 1");
        }
        grounded = helper.DoRayCollisionCheck();
        if (Input.GetKeyDown("space") == true && grounded == true)
        {
            anim.SetBool("player jump", true);
            rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
        }

        if (rb.velocity.y != 0)
        {
            anim.SetBool("player jump", true);
        }
    }
}
