using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public QuestManager qm;
    public bool Helped { get; set; }
    public string[] rewardString;
    public string[] undoneString;
    public string[] doneString;
    public GameObject doneObject;
    public float donePosX, donePosY;
    public Inventory inv;

    Transform trans;
    Goal goal = new Goal();

    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;
    private Quest Quest { get; set; }

    private void Start()
    {
        qm = GameObject.Find("QuestManager").GetComponent<QuestManager>();

        trans = GetComponent<Transform>();

        donePosX += trans.position.x;
        donePosY += trans.position.y;
    }

    public override void Interacts()
    {
        
        if (!qm.AssignedQuest && !Helped )
        {
            base.Interacts();
            AssignQuest();

        }
        else if (qm.AssignedQuest && !Helped )
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
        qm.AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));

    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            inv = GameObject.Find("Inventory").GetComponent<Inventory>();

            goal.RemoveItem();
            Quest.GiveReward();
            Helped = true;
            qm.AssignedQuest = false;

            DialogHolder.Instance.AddNewDialogue(rewardString, name);

            Instantiate(doneObject, new Vector3(donePosX, donePosY), Quaternion.identity);

        }
        else
        {
            if (!DialogHolder.Instance)
            {

            }
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

