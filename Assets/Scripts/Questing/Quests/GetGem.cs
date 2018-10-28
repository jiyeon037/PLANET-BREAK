using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGem : Quest {

	// Use this for initialization
	void Start () {

        Goals = new List<Goal>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        QuestName = "보석 모으기";
        Description = "뱀순이를 위해 보석을 5개 모으자!";
        ItemID = 30005;
        ItemCount = 1;

        Goals.Add(new CollectionGoal(this, 40005, "Get Gem", false, 0, 5));

        Goals.ForEach(g => g.Init());
    }

}
