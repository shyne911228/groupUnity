using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;

    public void ItemOnClicked()
    {
        Manager.UpdateItemInfo(slotItem.itemInform);
        //當背包內物品被點擊時 資訊欄位顯示其描述
    }
}
