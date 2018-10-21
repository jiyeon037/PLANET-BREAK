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

    private void Start()
    {
        
    }
    
    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed);
        
    }

    public void GiveReward()
    {
        Debug.Log("Give Reward");
        
        if (ItemID != 0)
            inv.GetAnItem(ItemID,ItemCount);
    }
    
    
}
