using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Quest Quest { get; set; }
    public int ID { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }
    public Inventory inv;

    public virtual void Init()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    public void Evaluate()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            Complete();
            Debug.Log(this.ID + "  " + CurrentAmount + " " + RequiredAmount);

        }
    }

    public void Complete()
    {
        Debug.Log("컴플릿" + this.ID + "  " + CurrentAmount + " " + RequiredAmount);
        Completed = true;
       // RemoveItem();
        Quest.CheckGoals();
        Debug.Log("Goal completed.");
    }

    public void RemoveItem()
    {
        Debug.Log("리무브 아이템 " + RequiredAmount);
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        for (int i = 0; i < inv.inventoryItemList.Count; i++)
        {
            if (inv.inventoryItemList[i].itemID == this.ID)  // 템 찾으면
            {
                for (int j = 0; j < RequiredAmount; j++) {

                    if (inv.inventoryItemList[i].itemCount > RequiredAmount)
                        inv.inventoryItemList[i].itemCount -= RequiredAmount;
                    else
                        inv.inventoryItemList.RemoveAt(i);

                }
            }

        }

    }

}
