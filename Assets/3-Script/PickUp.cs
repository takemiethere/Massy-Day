using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public QuestManager questManager;
    public float stealTime = 5f;
    public float maxStealDistance = 2f;
    //public string itemName;
    private float timeLeft = 0f;
    private bool isStealing = false;
    // Start is called before the first frame update
    void Start()
    {
        questManager = GameObject.FindObjectOfType<QuestManager>();
    }

    public bool IsStealing
    {
        get { return isStealing; }
    }

    void Update()
    {
        // Check if the player is close to the item and holding down the "E" key
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (Input.GetKey(KeyCode.E) && !isStealing && distance <= maxStealDistance)
        {
            isStealing = true;
            timeLeft = stealTime;
            
        
        }

        // Check if the player has stopped holding down the "E" key
        if (isStealing && !Input.GetKey(KeyCode.E))
        {
            isStealing = false;
            timeLeft = 0f;
            return;
        }

        if (isStealing)
        {
            // Update the stealing timer
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0f)
            {
                questManager.ItemStolen();
                Debug.Log("something picked up");
                Destroy(gameObject);
            }
        }

    }

    /*public void NotifyItemPickedUp()
    {
        IsStealing.Invoke();
    }*/

    private void OnGUI()
    {
        if (isStealing)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Stealing: " + Mathf.RoundToInt(timeLeft));
            //GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Stealing " + itemName + ": " + Mathf.RoundToInt(timeLeft));
        }
    }
}
