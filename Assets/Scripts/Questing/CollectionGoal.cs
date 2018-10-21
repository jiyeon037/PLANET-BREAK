using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal {

    public int ItemID { get; set; }

    public CollectionGoal(Quest quest, int itemID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        UIEventHandler.OnItemAdded += ItemPickedUp;
        Debug.Log("Collection Goal Init");
    }

    public void ItemPickedUp(int ID)
    {
        if (ID == this.ItemID)
        {
            Debug.Log("item : " + CurrentAmount);
            this.CurrentAmount++;
            Evaluate();

           
            
        }
    }

    
}
