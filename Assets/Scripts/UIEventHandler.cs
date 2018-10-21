using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {   // 템 먹었을때 퀘스트에 먹었다고 알려주는거
    public delegate void ItemEventHandler(int itemID);
    public static event ItemEventHandler OnItemAdded;
	// Use this for initialization
	
    public static void ItemAdded(int itemID)
    {
        OnItemAdded(itemID);
    }
}
