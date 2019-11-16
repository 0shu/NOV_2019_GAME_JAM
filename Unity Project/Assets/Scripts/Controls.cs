using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody2D player;
    float acceleration = 0.5f;
    float maxVelocity = 2;

    float[] laneheight = {0, 10, 20};
    uint currentLane;

    float maxJumpVel = 2.0f;
    float jumpVelocity = 2;
    bool jumped = false;

    float obsticalPushBack = 5f;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        player.velocity = new Vector2(0, 0);

        currentLane = 1;
        player.position = new Vector2(player.position.x, laneheight[currentLane]);
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //Move Up Lane
        if ((Input.GetKeyDown(KeyCode.W)) && (currentLane < 2))
        {
            currentLane++;
            player.position = new Vector2(player.position.x, laneheight[currentLane + 1]);
        }  
        //Move Down Lane
        else if ((Input.GetKeyDown(KeyCode.S)) && (currentLane > 0))
        {
            currentLane--;
            player.position = new Vector2(player.position.x, laneheight[currentLane - 1]);
        }

        //Move Left
        if ((Input.GetKey(KeyCode.A) && (player.velocity.x > -maxVelocity)))
        {
            player.velocity = new Vector2(player.velocity.x - acceleration, player.velocity.y);
        }
        //Decellerating
        else if (player.velocity.x <= 0)
        {
            player.velocity = new Vector2(player.velocity.x + acceleration, player.velocity.y);
        }
        //Move Right
        if ((Input.GetKey(KeyCode.D)) && (player.velocity.x < maxVelocity))
        {
            player.velocity = new Vector2(player.velocity.x + acceleration, player.velocity.y);
        }
        //Decellerating
        else if (player.velocity.x >= 0)
        {
            player.velocity = new Vector2(player.velocity.x - acceleration, player.velocity.y);
        }

        //Jump
        if ((Input.GetKeyDown(KeyCode.Space) && (player.position.x > -maxVelocity)) && (jumped == false))
        {
            player.velocity = new Vector2(player.velocity.x, jumpVelocity);
        }
        else if (player.position.y > laneheight[currentLane])
        {
            player.velocity = new Vector2(player.velocity.x, -acceleration);
        }
        else if (player.position.y < laneheight[currentLane])
        {
            player.position = new Vector2(player.position.x, laneheight[currentLane]);
        }
    }

    void OnCollisionEnter(Collision obstical)
    {
        if (obstical.gameObject.tag == "StoppingObst")
        {
            player.velocity = new Vector2(player.velocity.x - obsticalPushBack, player.velocity.y);
        }
    }
}
