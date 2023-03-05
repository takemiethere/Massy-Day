/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSelector : MonoBehaviour
{

    public GameObject[] itemsToSteal;
    private List<int> itemIndices;

    // Start is called before the first frame update
    void Start()
    {
        // Create a list of indices to select from
        itemIndices = new List<int>();
        for (int i = 0; i < itemsToSteal.Length; i++)
        {
            itemIndices.Add(i);
        }

        // Check if this is a new game
        if (PlayerPrefs.GetInt("NewGame", 1) == 1)
        {
            StartNewGame();
        }
    }

    void StartNewGame()
    {
        // Set the number of items to steal
        int numItemsToSteal = 5;
        PlayerPrefs.SetInt("NumItemsToSteal", numItemsToSteal);

        // Randomly select five items from the list
        List<int> selectedIndices = new List<int>();
        for (int i = 0; i < numItemsToSteal; i++)
        {
            int randomIndex = Random.Range(0, itemIndices.Count);
            int itemIndex = itemIndices[randomIndex];
            selectedIndices.Add(itemIndex);
            itemIndices.RemoveAt(randomIndex);
        }

        // Display the names of the selected items on the screen
        for (int i = 0; i < selectedIndices.Count; i++)
        {
            int itemIndex = selectedIndices[i];
            GameObject itemToSteal = itemsToSteal[itemIndex];
            string itemName = itemToSteal.name;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25 + i * 20, 100, 50), itemName);
        }

        // Set the "NewGame" flag to false
        PlayerPrefs.SetInt("NewGame", 0);
    }

    void OnGUI()
    {
        if (PlayerPrefs.GetInt("NewGame", 1) == 1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Press 'N' to start a new game");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.SetInt("NewGame", 1);
            StartNewGame();
        }
    }














    *//*public GameObject[] itemsToSelectFrom;
    public int numItemsToSelect = 5;
    public float displayTime = 2f;
    public GUIStyle style;

    private List<GameObject> selectedItems = new List<GameObject>();
    private float displayTimer = 0f;

    void Start()
    {
        SelectRandomItems();
    }

    void Update()
    {
        if (displayTimer > 0f)
        {
            displayTimer -= Time.deltaTime;
        }
    }

    void OnGUI()
    {
        if (displayTimer > 0f)
        {
            string itemsText = "";
            foreach (GameObject item in selectedItems)
            {
                itemsText += item.name + "\n";
            }
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), itemsText, style);
        }
    }

    void SelectRandomItems()
    {
        List<GameObject> itemsList = new List<GameObject>(itemsToSelectFrom);
        for (int i = 0; i < numItemsToSelect; i++)
        {
            int randomIndex = Random.Range(0, itemsList.Count);
            selectedItems.Add(itemsList[randomIndex]);
            itemsList.RemoveAt(randomIndex);
        }
    }

    public void DisplaySelectedItems()
    {
        SelectRandomItems();
        displayTimer = displayTime;
    }*//*



}


*/




/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSelector : MonoBehaviour
{
    public GameObject[] itemsToSelectFrom;

    void Start()
    {
        // Randomly select five items from the list
        List<int> selectedIndices = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, itemsToSelectFrom.Length);
            if (!selectedIndices.Contains(randomIndex)) // make sure we don't select the same item twice
            {
                selectedIndices.Add(randomIndex);
            }
            else
            {
                i--; // if we selected a duplicate, try again with a new index
            }
        }

        // Display the names of the selected items on the screen
        for (int i = 0; i < selectedIndices.Count; i++)
        {
            int itemIndex = selectedIndices[i];
            GameObject itemToSelect = itemsToSelectFrom[itemIndex];
            string itemName = itemToSelect.name;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25 + i * 20, 100, 50), itemName);
        }
    }
}*/