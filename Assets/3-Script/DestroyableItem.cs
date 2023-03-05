/*using UnityEngine;

public class DestroyableItem : MonoBehaviour
{
    private ItemRandomizer itemRandomizer;

    void Start()
    {
        itemRandomizer = transform.parent.GetComponent<ItemRandomizer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            itemRandomizer.ItemDestroyed(gameObject);
            Destroy(gameObject);
        }
    }
}*/
