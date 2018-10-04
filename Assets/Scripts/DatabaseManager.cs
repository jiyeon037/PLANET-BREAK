using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour {

    static public DatabaseManager instance;

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
    

	// Use this for initialization
	void Start () {
        itemList.Add(new Item(10001, "빨간 포션", "HP를 50 채워주는 물약", Item.ItemType.Use));
        itemList.Add(new Item(10002, "농축 빨간 포션", "HP를 350 채워주는 물약", Item.ItemType.Use));
        itemList.Add(new Item(20001, "짧은 검", "기본적인 용사의 검", Item.ItemType.Equip));
        itemList.Add(new Item(30001, "설계서 조각 1", "우주선 수리를 위한 설계서 조각", Item.ItemType.Quest));
        itemList.Add(new Item(30002, "설계서 조각 2", "우주선 수리를 위한 설계서 조각", Item.ItemType.Quest));
        itemList.Add(new Item(30003, "설계서", "우주선 수리를 위한 설계서", Item.ItemType.Quest));
        itemList.Add(new Item(40002, "오렌지슬라임의 젤리", "오렌지슬라임에서 떨어져나온 조각", Item.ItemType.ETC));
        itemList.Add(new Item(40003, "블루슬라임의 젤리", "블루슬라임에서 떨어져나온 조각", Item.ItemType.ETC));

    }
	
}
