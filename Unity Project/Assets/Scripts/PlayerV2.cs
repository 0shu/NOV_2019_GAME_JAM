using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    //Lane Variables
    float[] m_laneHeight = { -2.56f, -1.28f, -0.0f };
    uint m_currentLane = 1;

    public bool m_jumping = false;
    public bool m_sliding = false;
    public bool m_powerSliding = false;

    float m_behaviourTimeout = 0.0f;

    [SerializeField]
    float m_jumpTime;
    [SerializeField]
    float m_slideTime;
    [SerializeField]
    float m_powerSlideTime;

    FrameOfReference m_for;

    int m_slideableCount = 0;
    int m_vaultableCount = 0;
    int m_boostableCount = 0;

    //Obstacle Variables
    [SerializeField]
    float m_blockerPushback;
    //[SerializeField]
    //float m_speedBoost;
    [SerializeField]
    float m_obstSpeedLoss;
    [SerializeField]
    float m_laneChangeSpeedLoss;

    [SerializeField]
    float m_powerSlideSpeedMult;

    Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        m_for = FindObjectOfType<FrameOfReference>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        DoSickShit();
        ChangeLane();
    }

    void ChangeLane()
    {
        //Move Up Lane
        if ((Input.GetKeyDown(KeyCode.W)) && (m_currentLane < 2) && !m_sliding && !m_jumping && !m_powerSliding)
        {
            m_currentLane++;
            m_for.m_desiredSpeed = m_for.m_currentSpeed * (1.0f - m_laneChangeSpeedLoss);
            m_for.m_decelerating = true;
            m_transform.localPosition = new Vector3(m_transform.localPosition.x, m_laneHeight[m_currentLane], 0.0f);
            gameObject.layer--;
        }
        //Move Down Lane
        else if ((Input.GetKeyDown(KeyCode.S)) && (m_currentLane > 0) && !m_sliding && !m_jumping && !m_powerSliding)
        {
            m_currentLane--;
            m_for.m_desiredSpeed = m_for.m_currentSpeed * (1.0f - m_laneChangeSpeedLoss);
            m_for.m_decelerating = true;
            m_transform.localPosition = new Vector3(m_transform.localPosition.x, m_laneHeight[m_currentLane], 0.0f);
            gameObject.layer++;
        }
    }

    void DoSickShit()
    {
        m_behaviourTimeout -= Time.deltaTime;
        if (m_behaviourTimeout < 0.0f)
        {
            m_behaviourTimeout = 0.0f;
            m_sliding = false;
            m_jumping = false;
            m_powerSliding = false;
            // TODO: Animation
        }
        
        // Jumping
        if ((Input.GetKeyDown(KeyCode.A)) && (m_vaultableCount > 0) && !m_sliding && !m_jumping && !m_powerSliding)
        {
            m_jumping = true;
            m_behaviourTimeout = m_jumpTime;

            Debug.Log("Jumping.");

            // TODO: Animation.
        }
        else if ((Input.GetKeyDown(KeyCode.D)) && (m_slideableCount > 0) && !m_jumping && !m_powerSliding)
        {
            m_sliding = true;
            m_behaviourTimeout = m_slideTime;

            Debug.Log("Sliding.");

            // TODO: Animation.
        }
        else if ((Input.GetKeyDown(KeyCode.D)) && (m_boostableCount > 0) && !m_jumping)
        {
            m_powerSliding = true;
            m_behaviourTimeout = m_powerSlideTime;
            m_for.m_powerBoostTime = m_powerSlideTime;
            m_for.m_currentSpeed = m_for.m_maxSpeed * m_powerSlideSpeedMult;

            Debug.Log("Powersliding.");

            // TODO: Animation.
        }

    }

    void OnTriggerEnter2D(Collider2D obstacle)
    {
        //Obstacle
        switch (obstacle.gameObject.tag)
        {
            case "EnableSlide":
                m_slideableCount++;
                break;
            case "EnableVault":
                m_vaultableCount++;
                break;
            case "SpeedBoost":
                m_boostableCount++;
                break;
            case "SlidingObst":
                if (!m_sliding && !m_powerSliding) {
                    m_for.m_desiredSpeed = m_for.m_currentSpeed * (1.0f - m_obstSpeedLoss);
                    m_for.m_decelerating = true;
                }
                break;
            case "VaultingObst":

                if (!m_jumping && !m_powerSliding) {
                    m_for.m_desiredSpeed = m_for.m_currentSpeed * (1.0f - m_obstSpeedLoss);
                    m_for.m_decelerating = true;
                }
                break;
            case "BlockingObst":
                if (!m_powerSliding) {
                    m_for.m_desiredSpeed = m_for.m_currentSpeed * (1.0f - m_obstSpeedLoss);
                    m_for.m_decelerating = true;
                }
                break;
            default:
                break;
        }
        /*if (obstacle.gameObject.tag == "SlidingObst") { }

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
        }*/
    }

    void OnTriggerExit2D(Collider2D obstacle)
    {
        switch (obstacle.gameObject.tag)
        {
            case "EnableSlide":
                m_slideableCount--;
                break;
            case "EnableVault":
                m_vaultableCount--;
                break;
            case "SpeedBoost":
                m_boostableCount--;
                break;
            default:
                break;
        }
    }
}
