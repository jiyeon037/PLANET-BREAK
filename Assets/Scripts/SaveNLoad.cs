using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveNLoad : MonoBehaviour {

    [System.Serializable]
    public class Data
    {
        public float playerX;
        public float playerY;
        public float playerZ;

//        public string mapName;
        public string sceneName;

        public int shipLV;
        public int playerHP;
        public List<int> playerItemInventory;
        public List<int> playerItemInventoryCount;
        
    }

    private PlayerControl thePlayer;
    private DatabaseManager theDatabase;
    private Inventory theInven;
    private UpgradeShip theShip;
    private Heart theHeart;
    private PlayerHealthManager theHealthMgr;

    public Data data;

    public Vector3 vector;

    public void CallSave()
    {
        theDatabase = FindObjectOfType<DatabaseManager>();
        thePlayer = FindObjectOfType<PlayerControl>();
        theInven = FindObjectOfType<Inventory>();
        theShip = FindObjectOfType<UpgradeShip>();
        theHeart = FindObjectOfType<Heart>();
        theHealthMgr = FindObjectOfType<PlayerHealthManager>();

        data.playerX = thePlayer.transform.position.x;
        data.playerY = thePlayer.transform.position.y;
        data.playerZ = thePlayer.transform.position.z;

        //  data.mapName = thePlayer.currentMapName;
        data.sceneName = thePlayer.currentSceneName;
        Debug.Log( " @@@ " + thePlayer.currentSceneName);
        Debug.Log( " @@@ " + SceneManager.GetActiveScene().name);

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

//            thePlayer.currentMapName = data.mapName;
            thePlayer.currentSceneName = data.sceneName;
            Debug.Log("@@@ " + thePlayer.currentSceneName);

            vector.Set(data.playerX, data.playerY, data.playerZ);
            thePlayer.transform.position = vector;

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

            SceneManager.LoadScene(data.sceneName);

        } else
        {
            Debug.Log("저장된 세이브 파일이 없습니다.");
        }

        file.Close();

    }
}
