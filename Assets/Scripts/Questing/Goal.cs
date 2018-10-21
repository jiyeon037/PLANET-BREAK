using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal{
    
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

    public void Evaluate ()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    { 
        Completed = true;
        Quest.CheckGoals();
        Debug.Log("Goal completed.");
    }

    public void RemoveItem()
    {
        if(ID > 10000)
        {
            for (int i = 0; i < inv.inventoryItemList.Count; i++)
            {
                if (inv.inventoryItemList[i].itemID == this.ID)
                {
                    if (inv.inventoryItemList[i].itemCount > RequiredAmount)
                        inv.inventoryItemList[i].itemCount -= RequiredAmount;
                    else
                    {
                        inv.inventoryItemList.RemoveAt(i);
                        Debug.Log("itemList index : " + i);

                    }

                }
                inv.ShowItem();
                break;
            }
        }
        
    }

}
