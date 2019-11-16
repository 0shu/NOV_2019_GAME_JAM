using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    //Player Variables
    Rigidbody2D player;
    float acceleration = 0.25f;
    float maxVelocity = 10;

    //Lane Variables
    float[] laneHeight = {-5, 0, 5};
    uint currentLane;

    //Jump Variables
    float maxJumpHeight = 3f;
    float jumpandFallAcc = 7.5f;
    bool jumping = false;

    bool sliding = false;

    bool gotSpeedBoost = false;
    bool gotSpeedSteal = false;

    //Obstacle Variables
    float obstaclePushBack = 15f;
    float speedBoost = 2.5f;
    float speedSteal = -1f;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        player.velocity = new Vector2(0, 0);

        currentLane = 1;
        player.position = new Vector2(player.position.x, laneHeight[currentLane]);
    }

    void Update()
    {
        //Check for Action
        ChangeLaneCheck();
        CheckMovement();
        CheckJump();
        CheckSlide();

       if ((gotSpeedBoost == false) && (player.velocity.x > maxVelocity))
       {
            player.velocity = new Vector2(player.velocity.x - (acceleration / 20), player.velocity.y);
       }

        Debug.Log(player.velocity);
    }

    void ChangeLaneCheck()
    {
        //Move Up Lane
        if ((Input.GetKeyDown(KeyCode.W)) && (currentLane < 2))
        {
            currentLane++;
            player.position = new Vector3(player.position.x, laneHeight[currentLane]);
            gameObject.layer--;
        }
        //Move Down Lane
        else if ((Input.GetKeyDown(KeyCode.S)) && (currentLane > 0))
        {
            currentLane--;
            player.position = new Vector2(player.position.x, laneHeight[currentLane]);
            gameObject.layer++;
        }
    }

    void CheckMovement()
    {
        //Move Left
        if (Input.GetKey(KeyCode.A) && (player.velocity.x > -maxVelocity))
        {
            player.velocity = new Vector2(player.velocity.x - acceleration, player.velocity.y);
        }
        //Decellerating
        else if (player.velocity.x < 0)
        {
            player.velocity = new Vector2(player.velocity.x + (acceleration / 2), player.velocity.y);
        }

        //Move Right
        if (Input.GetKey(KeyCode.D) && (player.velocity.x < maxVelocity))
        {
            player.velocity = new Vector2(player.velocity.x + acceleration, player.velocity.y);
        }
        //Decellerating
        else if (player.velocity.x > 0)
        {
            player.velocity = new Vector2(player.velocity.x - (acceleration / 2), player.velocity.y);
        }
    }

    void CheckJump()
    {
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

        //Falling Back Down
        if ((player.position.y > laneHeight[currentLane]) && (jumping == true))
        {
            player.velocity = new Vector2(player.velocity.x, -jumpandFallAcc);
        }
        //Reallignment with Lane
        else if (player.position.y <= laneHeight[currentLane])
        {
            player.position = new Vector2(player.position.x, laneHeight[currentLane]);
            jumping = false;
        }
    }

    void CheckSlide()
    {
        //Slide
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (player.velocity.x > 0)
            {
                player.velocity = new Vector2(player.velocity.x - (acceleration / 10), player.velocity.y);
            }
            else if (player.velocity.x < 0)
            {
                player.velocity = new Vector2(player.velocity.x + (acceleration / 10), player.velocity.y);
            }
            sliding = true;
        }
        else
        {
            sliding = false;
        }
    }

    void OnTriggerEnter2D(Collider2D obstacle)
    {
        //Obstacle
        if (obstacle.gameObject.tag == "BlockingObst")
        {
            player.velocity = new Vector2(player.velocity.x - obstaclePushBack, player.velocity.y);
        }
        else if (obstacle.gameObject.tag == "SlidingObst")
        {
            if (sliding == true)
            {
                gotSpeedBoost = true;
            }
            else
            {
                gotSpeedSteal = true;
            }
        }
        else if (obstacle.gameObject.tag == "VaultingObst")
        {
            if (sliding == true)
            {
                gotSpeedBoost = true;
            }
            else
            {
                gotSpeedSteal = true;
            }
        }
        else if (obstacle.gameObject.tag == "SpeedBoost")
        {
            gotSpeedBoost = true;
        }
    }

    void OnTriggerExit2D(Collider2D obstacle)
    {
        if (gotSpeedBoost == true)
        {
            player.velocity = new Vector2(player.velocity.x + (player.velocity.x * speedBoost), player.velocity.y);
            gotSpeedBoost = false;
        }

        if (gotSpeedSteal == true)
        {
            player.velocity = new Vector2(player.velocity.x + (player.velocity.x * speedSteal), player.velocity.y);
            gotSpeedSteal = false;
        }
    }
}