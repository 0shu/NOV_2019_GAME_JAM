using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Rigidbody2D player;
    float acceleration = 0.25f;
    float maxVelocity = 10;

    float[] laneHeight = {-5, 0, 5};
    uint currentLane;

    float maxJumpHeight = 1.75f;
    float jumpVelocity = 4;
    bool jumping = false;
    float jumpandFallAcc = 3.5f;

    float obsticalPushBack = 5f;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        player.velocity = new Vector2(0, 0);

        currentLane = 1;
        player.position = new Vector2(player.position.x, laneHeight[currentLane]);
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
            player.position = new Vector2(player.position.x, laneHeight[currentLane]);
        }  
        //Move Down Lane
        else if ((Input.GetKeyDown(KeyCode.S)) && (currentLane > 0))
        {
            currentLane--;
            player.position = new Vector2(player.position.x, laneHeight[currentLane]);
        }

        //Move Left
        if ((Input.GetKey(KeyCode.A) && (player.velocity.x > -maxVelocity)))
        {
            player.velocity = new Vector2(player.velocity.x - acceleration, player.velocity.y);
        }
        //Decellerating
        else if (player.velocity.x < 0)
        {
            player.velocity = new Vector2(player.velocity.x + (acceleration/2), player.velocity.y);
        }

        //Move Right
        if ((Input.GetKey(KeyCode.D)) && (player.velocity.x < maxVelocity))
        {
            player.velocity = new Vector2(player.velocity.x + acceleration, player.velocity.y);
        }
        //Decellerating
        else if (player.velocity.x > 0)
        {
            player.velocity = new Vector2(player.velocity.x - (acceleration/2), player.velocity.y);
        }

        //Jump
        if (Input.GetKey(KeyCode.Space) && (jumping == false))
        {
            player.velocity = new Vector2(player.velocity.x, jumpandFallAcc);

            if (player.position.y >= (laneHeight[currentLane] + maxJumpHeight))
            {
                jumping = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = true;
        }
      
        if ((player.position.y > laneHeight[currentLane]) && (jumping == true))
        {
            player.velocity = new Vector2(player.velocity.x, -jumpandFallAcc);
        }
        else if (player.position.y <= laneHeight[currentLane])
        {
            player.position = new Vector2(player.position.x, laneHeight[currentLane]);
            jumping = false;
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
