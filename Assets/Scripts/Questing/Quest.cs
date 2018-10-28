using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour{
   
    public List<Goal> Goals { get; set; }
    //public int QuestID { get; set; }
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ItemID { get; set; }
    public int ItemCount { get; set; }
    public bool Completed { get; set; }
    public Inventory inv;
    Goal goal = new Goal();

    private void Start()
    {
        
    }
    
    public void CheckGoals()
    {
        Debug.Log("전  " + goal.ID + "  " + goal.CurrentAmount + " " + goal.RequiredAmount);
        Completed = Goals.All(g => g.Completed);
        Debug.Log("후  " + goal.ID + "  " + goal.CurrentAmount + " " + goal.RequiredAmount);

    }

    public void GiveReward()
    {
        Debug.Log("Give Reward");

        if (ItemID != 0)
            inv.GetAnItem(ItemID,ItemCount);
    }
    
    
}
