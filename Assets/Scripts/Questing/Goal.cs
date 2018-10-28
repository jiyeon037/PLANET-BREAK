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
        Completed = true; //////////////////
        Debug.Log("컴플릿 후" + this.ID + "  " + CurrentAmount + " " + RequiredAmount);
        Quest.CheckGoals();
        Debug.Log("컴플릿 후후" + this.ID + "  " + CurrentAmount + " " + RequiredAmount);
        Debug.Log("Goal completed.");
    }

    public void RemoveItem()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        for (int i = 0; i < inv.inventoryItemList.Count; i++)
        {
            Debug.Log(inv.inventoryItemList[i].itemID + "  " + this.ID + "  " + CurrentAmount + " " + RequiredAmount);
            if (inv.inventoryItemList[i].itemID == this.ID)  // 템 찾으면
            {
                Debug.Log("33333333333333");
                for (int j = 0; j < RequiredAmount; j++) {
                    Debug.Log("444444444444444");
                    if (inv.inventoryItemList[i].itemCount > RequiredAmount)
                        inv.inventoryItemList[i].itemCount -= RequiredAmount;
                    else
                        inv.inventoryItemList.RemoveAt(i);

                }
            }

        }

    }

}
