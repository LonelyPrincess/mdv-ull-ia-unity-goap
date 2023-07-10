using UnityEngine;

public class InitWorldResources : MonoBehaviour
{
    void StoreResourcesOfTypeInScene (string resTag, string resType) {
        WorldResources resources = GWorld.Instance.GetSharedResources();

        // Store all objects found with the resource type tag in the world resources
        GameObject[] objectsFound = GameObject.FindGameObjectsWithTag(resTag);
        foreach (GameObject o in objectsFound) {
            resources.AddResource(resType, o);
        }

        // Update state of the world with number of free resources
        if (objectsFound.Length > 0) {
            GWorld.Instance.GetWorld().ModifyState(resType, objectsFound.Length);
        }

        Debug.Log(objectsFound.Length + " resources found of type " + resTag + " in scene!");
    }

    // Start is called before the first frame update
    void Start()
    {
        StoreResourcesOfTypeInScene(ResourceTags.Bed, ResourceTypes.AvailableBeds);
        StoreResourcesOfTypeInScene(ResourceTags.Seat, ResourceTypes.AvailableSeats);
        StoreResourcesOfTypeInScene(ResourceTags.ArenaSlot, ResourceTypes.AvailableArenaSlots);
    }
}
