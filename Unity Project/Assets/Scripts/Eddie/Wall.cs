using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    private Rigidbody2D rb;
    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  rb.velocity = rb.transform.right * Speed;
        rb.velocity = new Vector2(Speed, rb.velocity.y);

    }
}
