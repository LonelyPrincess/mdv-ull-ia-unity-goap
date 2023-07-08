using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceTypes {
    public const string Bed = "Bed";
    public const string Seat = "Seat";
    public const string ArenaSlotA = "Arena Slot A";
    public const string ArenaSlotB = "Arena Slot B";
}

public class InitWorldResources : MonoBehaviour
{
    void StoreResourcesOfTypeInScene (string resType, string statePropName) {
        WorldResources resources = GWorld.Instance.GetSharedResources();

        // Store all objects found with the resource type tag in the world resources
        GameObject[] objectsFound = GameObject.FindGameObjectsWithTag(resType);
        foreach (GameObject o in objectsFound) {
            resources.AddResource(resType, o);
        }

        // Update state of the world with number of free resources
        if (objectsFound.Length > 0) {
            GWorld.Instance.GetWorld().ModifyState(statePropName, objectsFound.Length);
        }

        Debug.Log(objectsFound.Length + " resources found of type " + resType);
        /* foreach (GameObject r in resources.GetResourcesOfType(resType)) {
            Debug.Log(r.name);
        } */
    }

    // Start is called before the first frame update
    void Start()
    {
        StoreResourcesOfTypeInScene(ResourceTypes.Bed, "freeBeds");        StoreResourcesOfTypeInScene(ResourceTypes.Seat, "freeSeats");
        StoreResourcesOfTypeInScene(ResourceTypes.ArenaSlotA, "freeArenaSlotA");
        StoreResourcesOfTypeInScene(ResourceTypes.ArenaSlotB, "freeArenaSlotB");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
