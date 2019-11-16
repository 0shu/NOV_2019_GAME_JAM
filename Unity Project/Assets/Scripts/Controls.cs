using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody2D player;
    float speedIncreaser = 0.5f;
    float maxVelocity = 2;

    GameObject ground;
    float maxJumpVel = 2;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        player.velocity = new Vector2(0, 0);

        ground = GameObject.FindGameObjectWithTag("Ground");
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if ((Input.GetKey(KeyCode.RightArrow)) && (player.velocity.x < maxVelocity))
        {
            player.velocity = new Vector2(player.velocity.x + speedIncreaser, player.velocity.y);
        }
        else if (player.velocity.x != 0)
        {
            player.velocity = new Vector2(player.velocity.x - speedIncreaser, player.velocity.y);
        }

        if ((Input.GetKey(KeyCode.LeftArrow) && (player.velocity.x > -maxVelocity)))
        {
            player.velocity = new Vector2(player.velocity.x - speedIncreaser, player.velocity.y);
        }
        else if (player.velocity.x != 0)
        {
            player.velocity = new Vector2(player.velocity.x + speedIncreaser, player.velocity.y);
        }

        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.W) && (GroundedCheck() == true)))
        {
            player.velocity = new Vector2(player.velocity.x, player.velocity.y + maxJumpVel);
        }
    }

    bool GroundedCheck()
    {
        float distToGround;
        bool grounded;
        distToGround = Vector2.Distance(ground.transform.position, transform.position);

        if (distToGround < 0.01f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        return grounded;
    }
}
