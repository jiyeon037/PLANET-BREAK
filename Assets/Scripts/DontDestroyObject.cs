using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObject : MonoBehaviour {

	// Use this for initialization
	void Awake () {

        DontDestroyOnLoad(gameObject);
	}
	
}
