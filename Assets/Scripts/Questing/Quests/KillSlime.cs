using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSlime : Quest {


	void Start()
    {
        Goals = new List<Goal>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        QuestName = "주황 슬라임 잡기";
        Description = "주황 슬라임을 5마리 잡고 젤리를 3개 모으자!";
        ItemID = 30001;
        ItemCount = 2;

        Goals.Add(new CollectionGoal(this, 40002, "Collect 3 Slime Jelly", false, 0, 3));
        Goals.Add(new KillGoal(this, 0, "Kill 5 Orange Slimes", false, 0, 5));

        Goals.ForEach(g => g.Init());
    }
   
}
