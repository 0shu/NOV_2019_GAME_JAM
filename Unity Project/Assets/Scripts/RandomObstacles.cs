using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnSlot
{
    public GameObject prefab;
    public float weight;
}

class ObstacleSpawnSlot : IComparer<ObstacleSpawnSlot>
{
    public float spawnProb;
    public int spawnPreset;
    public Vector3 position;
    public int lane;

    public int Compare(ObstacleSpawnSlot x, ObstacleSpawnSlot y)
    {

        if (x == null || y == null)
        {
            return 0;
        }
        float output = (x.spawnProb - y.spawnProb);
        if (output < 0.0f) { return -1; }
        if (output > 0.0f) { return 1; }
        return 0;
    }
}


public class RandomObstacles : MonoBehaviour
{

    public float minDistBetweenSpawn;
    public float maxDistBetweenSpawn;

    public float maxDesiredDistBetweeenLaneItems;

    float nextSpawn;
    public SpawnSlot[] m_Spawnables;
    private Transform m_transform;

    float[] m_posAtLastSpawn = new float[3];

    float m_totalSlotWeighting = 0;

    GameObject m_spawnObj;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        for (int i = 0; i < 3; i++) { m_posAtLastSpawn[i] = 0.0f; }

        foreach (SpawnSlot s in m_Spawnables) { m_totalSlotWeighting += s.weight; }

        m_spawnObj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        m_transform.position = new Vector3(m_transform.position.x + 0.05f, 0.0f, -10.0f);
        float x = m_transform.position.x;
        if (x > nextSpawn)
        {
            // Spawn
            Debug.Log("Spawnwave Triggered at " + x + ".");
            List<ObstacleSpawnSlot> spawnSlots = new List<ObstacleSpawnSlot>();
            for (int i = 0; i < 3; i++) {
                float x_offset = Random.Range(-2.0f, 2.0f);
                x_offset += x + 20.0f;
                float y_offset = -2.5f + (i * 1.25f);

                ObstacleSpawnSlot slot = new ObstacleSpawnSlot();

                float r = Random.Range(0, m_totalSlotWeighting);
                float rolling = 0;
                bool found = false;
                for (int k = 0; k < m_Spawnables.Length && !found; k++) {
                    rolling += m_Spawnables[k].weight;
                    if (r < rolling) { slot.spawnPreset = k; found = true; }
                }
                //slot.spawnPreset = Random.Range(0, m_Spawnables.Length);

                slot.position = new Vector3(x_offset, y_offset, 0.0f);

                float j = (x - m_posAtLastSpawn[i]) / maxDesiredDistBetweeenLaneItems;
                slot.spawnProb = Mathf.Clamp(Random.Range(j - 0.15f, j + 0.15f), 0.0f, 1.0f);

                spawnSlots.Add(slot);
            }

            spawnSlots.Sort(spawnSlots[0].Compare);

            int spawned = 0;
            for (int i = 0; i<3 && spawned < 2; i++) {
                float prob = spawnSlots[i].spawnProb + (-0.5f * spawned);

                if (Random.Range(0.0f, 1.0f) < prob)
                {
                    m_posAtLastSpawn[spawnSlots[i].lane] = x;
                    GameObject temp = Instantiate(m_Spawnables[spawnSlots[i].spawnPreset].prefab, spawnSlots[i].position, Quaternion.identity);
                    temp.transform.SetParent(m_spawnObj.transform);
                    spawned++;
                }
            }
            nextSpawn = x + Random.Range(minDistBetweenSpawn, maxDistBetweenSpawn);

            // Clean up old objects
            foreach (Transform child in m_spawnObj.transform)
            {
                if (child.position.x < x - 20.0f) {
                    Destroy(child.gameObject);
                }
            }
        }
        // if x > nextSpawn
        // spawn some objects
        // set next spawn randomly within bounds
    }
}
