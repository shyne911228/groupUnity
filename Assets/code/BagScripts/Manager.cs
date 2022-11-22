using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    static Manager instance;

    public Inventory myBag;
    public GameObject slotGrid;     //背包內的格子
    public GameObject emptySlot;    //物品預製物件
    public Text itemInformation;    //物品資訊 _須加上第4行(.UI)

    public List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
        //物品資訊欄位 應默認為不顯示
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
        //將物品描述文字 更新於資訊欄位
    }

    /* public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        // Slot為一腳本型別
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        // 將生成的新item設置為物件下的子籍
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
        // text中的文字必須為字串 而itemHeld持有數目為整數 因此ToString轉字串
    } */

    public static void Restart()    //當遊戲每次重新開始 都將背包的物品清除重置
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
    }

    public static void RefreshItem()
    {
        for (int i=0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;  
            // 若背包格內沒有任何item 則不進行下述
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            // 摧毀格子內所有item(child of grid)
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
        
        }
    }
}
