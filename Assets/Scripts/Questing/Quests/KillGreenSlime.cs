using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGreenSlime : Quest {

	// Use this for initialization
	void Start () {
        Goals = new List<Goal>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        QuestName = "초록 슬라임 잡기";
        Description = "초록 슬라임을 잡아 슬라임 구슬을 5개 모으자!";
        ItemID = 30004;
        ItemCount = 1;

        
        Goals.Add(new CollectionGoal(this, 40006, "Collect 5 Slime Balls", false, 0, 5));

        Goals.ForEach(g => g.Init());

    }
	
}
