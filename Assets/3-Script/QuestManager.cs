/*using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int numItemsToSteal;
    public int numItemsStolen;
    public TextMeshProUGUI itemsStolenText;

    public float theftTimeLimit = 5f;


    // Start is called before the first frame update
    void Start()
    {
        numItemsStolen = 0;
        itemsStolenText = GameObject.Find("ItemsStolenText").GetComponent<TextMeshProUGUI>();
        UpdateItemsStolenText();
    }

    void UpdateItemsStolenText()
    {
        itemsStolenText.text = "Items Stolen: " + numItemsStolen + " / " + numItemsToSteal;
    }


    // Update is called once per frame
    void Update()
    {
        if (numItemsStolen >= numItemsToSteal)
        {
            // TODO: player has won the game, add win condition here
        }
    }

    public void ItemStolen()
    {
        numItemsStolen++;
        UpdateItemsStolenText();
    }
}
*/


using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public int numItemsToSteal;
    public int numItemsStolen;
    public TextMeshProUGUI itemsStolenText;

    public float theftTimeLimit = 5f;
    public GameObject[] itemsToSteal;

    private List<int> itemsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        numItemsStolen = 0;
        itemsStolenText = GameObject.Find("ItemsStolenText").GetComponent<TextMeshProUGUI>();
        UpdateItemsStolenText();

        itemsRemaining = new List<int>();
        for (int i = 0; i < itemsToSteal.Length; i++)
        {
            itemsRemaining.Add(i);
        }
    }

    void UpdateItemsStolenText()
    {
        itemsStolenText.text = "Items Stolen: " + numItemsStolen + " / " + numItemsToSteal;
    }

    int GetItem()
    {
        int randomIndex = Random.Range(0, itemsRemaining.Count);
        int itemIndex = itemsRemaining[randomIndex];
        itemsRemaining.RemoveAt(randomIndex);
        return itemIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (numItemsStolen >= numItemsToSteal)
        {
            Debug.Log("Player Win");
        }
    }

    public void ItemStolen()
    {
        numItemsStolen++;
        UpdateItemsStolenText();

        if (numItemsStolen < numItemsToSteal)
        {
            int itemIndex = GetItem();
            GameObject itemToSteal = itemsToSteal[itemIndex];
            //Instantiate(itemToSteal, new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f)), Quaternion.identity);
           /* ItemRandomizer itemRandomizer = FindObjectOfType<ItemRandomizer>();
            itemRandomizer.RemoveItem(itemToSteal.name);*/

        }
        //GetComponent<ItemRandomizer>().RemoveCurrentItem();

    }
}
