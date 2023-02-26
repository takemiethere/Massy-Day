/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public QuestManager questManager;

    // Start is called before the first frame update
    void Start()
    {
        questManager = GameObject.FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Press E to steal " + gameObject.name);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                questManager.ItemStolen();
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Leaving " + gameObject.name);
        }
    }
}
*/