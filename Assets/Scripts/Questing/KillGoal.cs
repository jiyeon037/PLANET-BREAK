using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal {
    public int EnemyID { get; set; }

    public KillGoal(Quest quest, int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.Quest = quest;
        this.ID = enemyID;
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requiredAmount;
    }

    public override void Init() 
    {
        base.Init();
        CombatEvents.OnEnemyDeath += EnemyDeath;
        Debug.Log("Kill Goal Init");
    }

    public void EnemyDeath(IEnemy enemy)
    {
        if(enemy.ID == this.EnemyID)
        {
            Debug.Log("Detected enemy death : " + CurrentAmount);
            this.CurrentAmount++;
            Evaluate();
        }
    }
    
}
