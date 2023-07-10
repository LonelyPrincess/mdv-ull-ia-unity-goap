using UnityEngine;

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

        Debug.Log(objectsFound.Length + " resources found of type " + resType + " in scene!");
    }

    // Start is called before the first frame update
    void Start()
    {
        StoreResourcesOfTypeInScene(ResourceTypes.Bed, WorldStateProps.AvailableBeds);
        StoreResourcesOfTypeInScene(ResourceTypes.Seat, WorldStateProps.AvailableSeats);
        StoreResourcesOfTypeInScene(ResourceTypes.ArenaSlot, WorldStateProps.AvailableArenaSlots);
    }
}
