using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTree : Quest {

    // Use this for initialization

    void Start()
    {
        Goals = new List<Goal>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();

        QuestName = "나무 하기";
        Description = "나무를 해서 통나무 10개를 야옹이에게 가져다주자";
        ItemID = 30001;
        ItemCount = 2;

        Goals.Add(new CollectionGoal(this, 40004, "Collect 10 Log", false, 0, 5));

        Goals.ForEach(g => g.Init());
    }


}
