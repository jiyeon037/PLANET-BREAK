using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }
    public bool Helped { get; set; }
    public string[] rewardString;
    public string[] undoneString;
    public string[] doneString;
    public GameObject doneObject;
    public float donePosX, donePosY;
    Transform trans;
    CollectionGoal cGoal;

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;
    private Quest Quest { get; set; }

    private void Start()
    {
        trans = GetComponent<Transform>();
        cGoal = (CollectionGoal)new Goal();
        donePosX += trans.position.x;
        donePosY += trans.position.y;
    }

    public override void Interacts()
    {

        if (!AssignedQuest && !Helped)
        {
            base.Interacts();
            AssignQuest();
        }
        else if (AssignedQuest && !Helped)
        {
            CheckQuest();
        }
        else
        {
            DialogHolder.Instance.AddNewDialogue(doneString, name);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));

    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogHolder.Instance.AddNewDialogue(rewardString, name);

            cGoal.RemoveItem();
            Instantiate(doneObject, new Vector3(donePosX, donePosY), Quaternion.identity);

        }
        else
        {
            DialogHolder.Instance.AddNewDialogue(undoneString, name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            DialogHolder.Instance.MasiIn();
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Masi")
        {
            DialogHolder.Instance.MasiOut();

        }
    }
}

