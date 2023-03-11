using System.Collections;
using System.Collections.Generic;

/*using UnityEngine;

public class DestroyChild : MonoBehaviour
{
    // Assuming you have a reference to the player object and the instantiated prefab
    public GameObject player;
    public GameObject prefabInstance;

    // Use this method to destroy the prefab clone
    public void DestroyPrefabInstance()
    {
        // Make sure the prefab instance is not null
        if (prefabInstance != null)
        {
            // Unparent the prefab instance from the player object
            prefabInstance.transform.parent = null;

            // Destroy the prefab instance
            Destroy(prefabInstance);
        }
    }
}
*/
using UnityEngine;

public class DestroyChild : MonoBehaviour
{
    public string cloneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Find the clone's transform
            Transform cloneTransform = transform.Find(cloneName);

            // Destroy the clone
            Destroy(cloneTransform.gameObject);
        }
    }
}
