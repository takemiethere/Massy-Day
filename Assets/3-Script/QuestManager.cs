using System.Collections;
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
