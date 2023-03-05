/*using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemRandomizer : MonoBehaviour
{
    public List<GameObject> itemsToSteal;
    public TextMeshProUGUI itemNameText;

    private List<int> itemIndices;

    void Start()
    {
        itemIndices = new List<int>();
        for (int i = 0; i < itemsToSteal.Count; i++)
        {
            itemIndices.Add(i);
        }
        RandomizeItems();
    }

    void RandomizeItems()
    {
        // Randomly select five items from the list
        List<int> selectedIndices = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, itemIndices.Count);
            int itemIndex = itemIndices[randomIndex];
            selectedIndices.Add(itemIndex);
            itemIndices.RemoveAt(randomIndex);
        }

        // Display the names of the selected items
        string itemNames = "";
        for (int i = 0; i < selectedIndices.Count; i++)
        {
            int itemIndex = selectedIndices[i];
            GameObject itemToSteal = itemsToSteal[itemIndex];
            string itemName = itemToSteal.name;
            itemNames += itemName + "\n";
        }
        itemNameText.text = itemNames;
    }

    void Update()
    {
        // Check if player presses "R" to randomize items again
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandomizeItems();
        }
    }
}*/


/*using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ItemRandomizer : MonoBehaviour
{
    public List<GameObject> itemsToSteal;
    public TextMeshProUGUI itemNameText;

    private List<int> itemIndices;
    private Dictionary<string, int> itemNameToIndex;


    void Start()
    {
        itemIndices = new List<int>();
        itemNameToIndex = new Dictionary<string, int>();
        for (int i = 0; i < itemsToSteal.Count; i++)
        {
            itemIndices.Add(i);
            itemNameToIndex[itemsToSteal[i].name] = i;
        }
        RandomizeItems();
    }

    void RandomizeItems()
    {
        // Randomly select five items from the list
        List<int> selectedIndices = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, itemIndices.Count);
            int itemIndex = itemIndices[randomIndex];
            selectedIndices.Add(itemIndex);
            itemIndices.RemoveAt(randomIndex);
        }

        // Display the names of the selected items
        string itemNames = "";
        for (int i = 0; i < selectedIndices.Count; i++)
        {
            int itemIndex = selectedIndices[i];
            GameObject itemToSteal = itemsToSteal[itemIndex];
            string itemName = itemToSteal.name;
            itemNames += itemName + "\n";
        }
        itemNameText.text = itemNames;
    }

    public void ItemDestroyed(GameObject destroyedItem)
    {
        // Remove the name of the destroyed item from the itemNameText UI
        int destroyedIndex;
        if (itemNameToIndex.TryGetValue(destroyedItem.name, out destroyedIndex))
        {
            itemNameToIndex.Remove(destroyedItem.name);
            string currentText = itemNameText.text;
            int startIndex = currentText.IndexOf(destroyedItem.name);
            if (startIndex >= 0)
            {
                int endIndex = currentText.IndexOf('\n', startIndex);
                if (endIndex < 0)
                {
                    endIndex = currentText.Length;
                }
                itemNameText.text = currentText.Remove(startIndex, endIndex - startIndex + 1);
            }
        }
    }


    void Update()
    {
        // Check if player presses "R" to randomize items again
        if (Input.GetKeyDown(KeyCode.R))
        {
            RandomizeItems();
        }
    }
}*/

using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemRandomizer : MonoBehaviour
{
    public List<GameObject> itemsToSteal;
    public TextMeshProUGUI itemNameText;

    private List<int> itemIndices;

    private List<int> selectedIndices;

    void Start()
    {
        itemIndices = new List<int>();
        for (int i = 0; i < itemsToSteal.Count; i++)
        {
            itemIndices.Add(i);
        }
        RandomizeItems();
    }

    void RandomizeItems()
    {
        // Randomly select five items from the list
        selectedIndices = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, itemIndices.Count);
            int itemIndex = itemIndices[randomIndex];
            selectedIndices.Add(itemIndex);
            itemIndices.RemoveAt(randomIndex);
        }

        // Display the names of the selected items
        string itemNames = "";
        for (int i = 0; i < selectedIndices.Count; i++)
        {
            int itemIndex = selectedIndices[i];
            GameObject itemToSteal = itemsToSteal[itemIndex];
            string itemName = itemToSteal.name;
            itemNames += itemName + "\n";
        }
        itemNameText.text = itemNames;
    }

    public void OnItemDestroyed(GameObject itemToDestroy)
    {
        // Check if the destroyed item is one of the selected items
        int indexToRemove = selectedIndices.FindIndex(index => itemsToSteal[index] == itemToDestroy);
        if (indexToRemove >= 0)
        {
            selectedIndices.RemoveAt(indexToRemove);

            // Update the text on the UI to remove the name of the destroyed item
            string[] itemNames = itemNameText.text.Split('\n');
            itemNames[indexToRemove] = "";
            itemNameText.text = string.Join("\n", itemNames);
        }
    }
}