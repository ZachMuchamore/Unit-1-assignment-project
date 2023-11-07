using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    // Start is called before the first frame update
    LayerMask groundLayerMask;
    public bool grounded;
    public void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    public bool DoRayCollisionCheck()
    {
        float raylength = 0.5f;
        grounded = false;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -Vector2.up, raylength, groundLayerMask);
        Color hitColor = Color.white;
        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            grounded = true;
        }


        Debug.DrawRay(transform.position, -Vector2.up * raylength, hitColor);

        return grounded;
    }

    public void FlipObject(bool flip)
    {

        if (flip == true)
        {

            transform.transform.localScale = new Vector3(-2, 2, 2);
        }
        else
        {
            transform.transform.localScale = new Vector3(2, 2, 2);

        }
        // Update is called once per frame

    }

}