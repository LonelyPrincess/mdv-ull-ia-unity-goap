using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResources
{
    public Dictionary<string, Queue<GameObject>> resources;

    public WorldResources ()
    {
        resources = new Dictionary<string, Queue<GameObject>>();
    }

    public void AddResource (string resType, GameObject res)
    {
        if (!resources.ContainsKey(resType)) {
            resources.Add(resType, new Queue<GameObject>());
        }

        resources[resType].Enqueue(res);
    }

    public GameObject RemoveResource (string resType)
    {
        if (!resources.ContainsKey(resType) || resources[resType].Count == 0) {
            return null;
        }
        return resources[resType].Dequeue();
    }

    public Dictionary<string, Queue<GameObject>> GetResources ()
    {
        return resources;
    }

    public Queue<GameObject> GetResourcesOfType (string resType)
    {
        return resources[resType];
    }
}
