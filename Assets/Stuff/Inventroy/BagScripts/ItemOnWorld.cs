using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))   //若背包內無此item
        {
            playerInventory.itemList.Add(thisItem);     //新增此item
            // Manager.CreateNewItem(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;     //已擁有則直接在持有數量加上1
        }

        Manager.RefreshItem();
    }
}
