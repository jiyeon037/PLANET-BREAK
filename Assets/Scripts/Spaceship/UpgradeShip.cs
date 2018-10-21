using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShip : MonoBehaviour {

    private ContactShipZone shipZone;
    public GameObject SpaceshipLV1, SpaceshipLV2, SpaceshipLV3, SpaceshipLV4, SpaceshipLV5, SpaceshipLVFinal;
    Inventory inv;
    DatabaseManager theDatabase;

    static int shipCnt = 0;

    // Use this for initialization
    void Start () {
        shipZone = FindObjectOfType<ContactShipZone>();
        theDatabase = FindObjectOfType<DatabaseManager>();
        inv = FindObjectOfType<Inventory>();

        SpaceshipLV1.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
        if (shipZone.CheckZone)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {

            for(int i=0; i < inv.inventoryItemList.Count; i++)
                {
                    if (inv.inventoryItemList[i].itemID == 30000 + shipCnt + 1)
                    {
                        shipCnt++;

                        switch (shipCnt)
                        {
                            case 1:
                                SpaceshipLV1.SetActive(false);
                                SpaceshipLV2.SetActive(true);
                                break;

                            case 2:
                                SpaceshipLV2.SetActive(false);
                                SpaceshipLV3.SetActive(true);
                                break;

                            case 3:
                                SpaceshipLV3.SetActive(false);
                                SpaceshipLV4.SetActive(true);
                                break;

                            case 4:
                                SpaceshipLV4.SetActive(false);
                                SpaceshipLV5.SetActive(true);
                                break;

                            case 5:
                                SpaceshipLV5.SetActive(false);
                                SpaceshipLVFinal.SetActive(true);
                                break;

                        }

                        inv.inventoryItemList.RemoveAt(i); // 설계도 삭제

                        break;
                    }
                }

            }
        }
		
	}

}
