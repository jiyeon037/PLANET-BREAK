using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public int itemID;  // 데이터베이스에 넣었던 item의 ID를 검색하여 참조
    public int count;
    // public string pickUpSound;

    private Inventory inv;
    public NPC npc;

    private void Start()
    {
        inv = FindObjectOfType<Inventory>();
        npc = FindObjectOfType<NPC>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // AudioManager.instance.Play(pickUpSoind);
            inv.GetAnItem(itemID, count);

            if (npc.questStart) {
                UIEventHandler.ItemAdded(itemID);
            }
            Destroy(this.gameObject); // 맵에서 삭제

        }
    }
}
