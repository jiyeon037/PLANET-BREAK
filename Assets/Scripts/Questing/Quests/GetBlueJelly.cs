using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBlueJelly : Quest {

	// Use this for initialization
	void Start () {

        Goals = new List<Goal>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        QuestName = "블루 젤리 모으기";
        Description = "절미를 위해 블루 젤리를 5개 모으자!";
        ItemID = 30003;
        ItemCount = 1;

        Goals.Add(new CollectionGoal(this, 40003, "Get 5 Blue Jelly", false, 0, 5));

        Goals.ForEach(g => g.Init());
    }
	
}
