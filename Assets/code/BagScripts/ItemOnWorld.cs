using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        thisItem.itemHeld = 0;  //物品持有量設為0
        Manager.Restart();  //背包物品重置
    }

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

            thisItem.itemHeld = 1;
        }
        else
        {
            thisItem.itemHeld += 1;     //已擁有則直接在持有數量加上1
        }

        Manager.RefreshItem();
    }
}
