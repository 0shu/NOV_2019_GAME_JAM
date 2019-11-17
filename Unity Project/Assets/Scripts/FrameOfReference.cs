using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameOfReference : MonoBehaviour
{
    private Transform m_transform;

    public float m_maxSpeed;

    [SerializeField]
    float m_startMaxSpeed;

    [SerializeField]
    float m_maxSpeedIncreasePerMeter;

    [SerializeField]
    float m_maxAcceleration;

    [SerializeField]
    float m_maxDeceleration;

    [SerializeField]
    float m_minWallSpeedMult;

    public float m_powerBoostTime = 0.0f;

    public float m_currentSpeed;
    public float m_desiredSpeed;
    public bool m_decelerating = false;

    private Wall m_wall;

    [SerializeField]
    GameObject[] m_grounds;
    int m_nextGroundToTeleport = 0;
    float m_nextGroundMovePoint = 9.6f;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        m_maxSpeed = m_startMaxSpeed;

        m_wall = FindObjectOfType<Wall>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        m_powerBoostTime = Mathf.Max(0.0f, m_powerBoostTime - Time.deltaTime);

        m_maxSpeed = m_startMaxSpeed + (m_transform.position.x * m_maxSpeedIncreasePerMeter);
        float wallSpeedMod = Mathf.Max(((m_transform.position.x - m_wall.transform.position.x) / 20.0f), m_minWallSpeedMult);
        m_wall.Speed = m_maxSpeed * wallSpeedMod;

        if (!m_decelerating) {
            if (m_powerBoostTime == 0) {
                m_desiredSpeed = m_maxSpeed;
                if (m_currentSpeed < m_desiredSpeed) { m_currentSpeed = Mathf.Min(m_currentSpeed + (m_maxAcceleration * Time.deltaTime), m_maxSpeed); }
                else { m_currentSpeed = Mathf.Max(m_currentSpeed - (m_maxDeceleration * Time.deltaTime), m_maxSpeed); }
            }
        }
        else
        {
            m_currentSpeed -= (m_maxDeceleration * Time.deltaTime);
            if (m_currentSpeed <= m_desiredSpeed)
            {
                m_decelerating = false;
                m_desiredSpeed = m_maxSpeed;
                m_currentSpeed = m_desiredSpeed;
            }
        }

        float increment = m_currentSpeed * Time.deltaTime;
        m_transform.position = new Vector3(m_transform.position.x + increment, 0.0f, 0.0f);

        if (m_transform.position.x > m_nextGroundMovePoint)
        {
            m_grounds[m_nextGroundToTeleport].transform.position = new Vector3(m_grounds[m_nextGroundToTeleport].transform.position.x + (19.2f * 3.0f), 0.5f, -2.0f);
            m_nextGroundToTeleport++;
            m_nextGroundToTeleport = (m_nextGroundToTeleport >= m_grounds.Length) ? 0 : m_nextGroundToTeleport;
            m_nextGroundMovePoint += 19.2f;
        }
    }
}
