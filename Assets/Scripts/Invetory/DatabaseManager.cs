using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour {

    static public DatabaseManager instance;
    public PlayerHealthManager playerHealthMgr;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    public string[] var_name;
    public float[] var;

    public string[] switch_name;
    public bool[] swiches;

    public List<Item> itemList = new List<Item>();

    public void UseItem(int _itemID)
    {
        switch (_itemID)
        {
            case 10001:
                Debug.Log("반피 회복");
                if (playerHealthMgr.playerCurrentHealth <= 25)
                    playerHealthMgr.playerCurrentHealth += 5;

                break;
            case 10002:
                Debug.Log("풀피 회복");
                break;
            case 30001:
                Debug.Log("설계서 조각1");
                break;
            case 30002:
                Debug.Log("설계서 조각2");
                break;

        }
    }
    

	// Use this for initialization
	void Start () {
        itemList.Add(new Item(10001, "빨간 포션", "HP를 50 채워주는 물약", Item.ItemType.Use));
        itemList.Add(new Item(10002, "농축 빨간 포션", "HP를 350 채워주는 물약", Item.ItemType.Use));
        itemList.Add(new Item(20001, "짧은 검", "기본적인 용사의 검", Item.ItemType.Equip));
        itemList.Add(new Item(30001, "설계서 조각 1", "우주선 수리를 위한 첫번째 설계서 조각", Item.ItemType.Quest));
        itemList.Add(new Item(30002, "설계서 조각 2", "우주선 수리를 위한 두번째 설계서 조각", Item.ItemType.Quest));
        itemList.Add(new Item(30003, "설계서 조각 3", "우주선 수리를 위한 세번째 설계서 조각", Item.ItemType.Quest));
        itemList.Add(new Item(30004, "설계서 조각 4", "우주선 수리를 위한 네번째 설계서 조각", Item.ItemType.Quest));
        itemList.Add(new Item(30005, "설계서 조각 5", "우주선 수리를 위한 다섯번째 설계서 조각", Item.ItemType.Quest));
        itemList.Add(new Item(40002, "오렌지슬라임의 젤리", "오렌지슬라임에서 떨어져나온 조각", Item.ItemType.ETC));
        itemList.Add(new Item(40003, "블루슬라임의 젤리", "블루슬라임에서 떨어져나온 조각", Item.ItemType.ETC));
        itemList.Add(new Item(40004, "통나무", "나무를 해서 얻은 통나무", Item.ItemType.ETC));
        itemList.Add(new Item(40005, "파란 보석", "보석 광맥에서 나온 파란 보석", Item.ItemType.ETC));
        itemList.Add(new Item(40006, "초록슬라임의 구슬", "초록슬라임의 핵", Item.ItemType.ETC));

        playerHealthMgr = FindObjectOfType<PlayerHealthManager>();
        int curHealth = playerHealthMgr.playerCurrentHealth;
    }
	
}
