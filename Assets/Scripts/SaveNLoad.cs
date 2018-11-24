using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveNLoad : MonoBehaviour {

    [System.Serializable]
    public class Data
    {
        public float playerX;
        public float playerY;
        public float playerZ;

        public string sceneName;

//        public bool questStatus;

        public int shipLV;
        public int playerHP;
        public List<int> playerItemInventory;
        public List<int> playerItemInventoryCount;

        public int noteStatus;
        
    }

    private PlayerControl thePlayer;
    private DatabaseManager theDatabase;
    private Inventory theInven;
    private UpgradeShip theShip;
    private Heart theHeart;
    private PlayerHealthManager theHealthMgr;
    private RemainControl theRemainCtrl;
    //private QuestGiver theQuestGiver;
    //private Quest theQuest;

    public Data data;

    public Vector3 vector;

    public GameObject floatingText;
    public bool textCheck;

    public void CallSave()
    {
        textCheck = true;

        //floatingText = GameObject.Find("Canvas/FloatingText");
        theDatabase = FindObjectOfType<DatabaseManager>();
        thePlayer = FindObjectOfType<PlayerControl>();
        theInven = FindObjectOfType<Inventory>();
        theShip = FindObjectOfType<UpgradeShip>();
        theHeart = FindObjectOfType<Heart>();
        theHealthMgr = FindObjectOfType<PlayerHealthManager>();
        //theQuestGiver = FindObjectOfType<QuestGiver>();
        //theQuest = FindObjectOfType<Quest>();
        theRemainCtrl = FindObjectOfType<RemainControl>();

        data.playerX = thePlayer.transform.position.x;
        data.playerY = thePlayer.transform.position.y;
        data.playerZ = thePlayer.transform.position.z;

        data.sceneName = thePlayer.currentSceneName;
        Debug.Log(" @@@ " + thePlayer.currentSceneName);
        Debug.Log(" @@@ " + data.sceneName);

        //data.questStatus = theQuest.Completed;
        //Debug.Log(" @@@@ " + data.questStatus + theQuest.Completed);

        data.shipLV = theShip.shipCnt;
        data.playerHP = theHealthMgr.playerCurrentHealth;

        Debug.Log("기초 데이터 성공");

        data.playerItemInventory.Clear();
        data.playerItemInventoryCount.Clear();

        List<Item> itemList = theInven.SaveItem();
        for(int i = 0; i < itemList.Count; i++)
        {
            Debug.Log("인벤토리 아이템 저장 완료" + itemList[i].itemID);
            data.playerItemInventory.Add(itemList[i].itemID);
            data.playerItemInventoryCount.Add(itemList[i].itemCount);
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/SaveFile.dat");

        bf.Serialize(file, data);   //data를 file에 기록 후 직렬화
        file.Close();

        Debug.Log(Application.dataPath + "의 위치에 저장했습니다.");

        floatingText.gameObject.SetActive(true);
        StartCoroutine(func());

    }

    public void CallLoad()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.dataPath + "/SaveFile.dat", FileMode.Open);

        Debug.Log(Application.dataPath + "의 위치에 저장했습니다.");

        if (file != null && file.Length > 0)
        {
            data = (Data)bf.Deserialize(file);

            theDatabase = FindObjectOfType<DatabaseManager>();
            thePlayer = FindObjectOfType<PlayerControl>();
            theInven = FindObjectOfType<Inventory>();
            theShip = FindObjectOfType<UpgradeShip>();
            theHealthMgr = FindObjectOfType<PlayerHealthManager>();
            //theQuestGiver = FindObjectOfType<QuestGiver>();
            //theQuest = FindObjectOfType<Quest>();
            theRemainCtrl = FindObjectOfType<RemainControl>();

            thePlayer.currentSceneName = data.sceneName;
            Debug.Log("@@@ " + thePlayer.currentSceneName);

            vector.Set(data.playerX, data.playerY, data.playerZ);
            thePlayer.transform.position = vector;

            //theQuest.Completed = data.questStatus;
            //Debug.Log("@@@@@ " + data.questStatus);

            theHealthMgr.playerCurrentHealth = data.playerHP;
            theShip.shipCnt = data.shipLV;

            List<Item> itemList = new List<Item>();

            for(int i=0; i < data.playerItemInventory.Count; i++)
            {
                for(int x = 0; x < theDatabase.itemList.Count; x++)
                {
                    if(data.playerItemInventory[i] == theDatabase.itemList[x].itemID)
                    {
                        itemList.Add(theDatabase.itemList[x]);
                        Debug.Log("인벤토리 아이템을 로드했습니다 : " + theDatabase.itemList[x].itemID);
                    }
                }
            }

            for(int i=0; i < data.playerItemInventoryCount.Count; i++)
            {
                itemList[i].itemCount = data.playerItemInventoryCount[i];
            }

            theInven.LoadItem(itemList);

            GameManager theGM = FindObjectOfType<GameManager>();
            theGM.LoadStart();

            SceneManager.LoadScene(data.sceneName);   // 씬을 새로 로드하면 정보 사라짐.. 원래 문제랑 같은 원리인듯

        } else
        {
            Debug.Log("저장된 세이브 파일이 없습니다.");
        }

        file.Close();

    }

    void Start()
    {
        floatingText = GameObject.Find("Canvas/FloatingText");
        floatingText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (textCheck == true)
            StartCoroutine(func());
    }

    IEnumerator func()
    {
        yield return new WaitForSeconds(2.0f);
        floatingText.gameObject.SetActive(false);
        this.textCheck = false;
    }
}
