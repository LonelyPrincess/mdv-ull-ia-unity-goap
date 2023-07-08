using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgents : MonoBehaviour
{
    public int numAgentsOnStart;
    public GameObject agentPrefab;
    public bool keepSpawningRandomly = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numAgentsOnStart; i++)
        {
            Instantiate(agentPrefab, this.transform.position, Quaternion.identity, this.transform);
        }

        if (keepSpawningRandomly) {
            Invoke("SpawnAgent", 5);
        }
    }

    void SpawnAgent()
    {
        Instantiate(agentPrefab, this.transform.position, Quaternion.identity);
        Invoke("SpawnAgent", Random.Range(2, 10));
    }
}
