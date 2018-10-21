using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour {

    //points는 배열로 담을 수 있도록 한다.
    public Transform[] points;
    public GameObject monster;
    public int monsterMax;
    // 3초마다 몬스터를 만든다.
    public float createTime = 10.0f;


    // Use this for initialization
    void Start()
    {
        // points를 게임시작과 함께 배열에 담기
        points = GameObject.Find("TreeSpawnPoint").GetComponentsInChildren<Transform>();
        monsterMax = points.Length;
        StartCoroutine(this.CreateObject());
    }

    IEnumerator CreateObject()
    {
        int monsterCount = (int)GameObject.FindGameObjectsWithTag("tree").Length;

        if (monsterCount < monsterMax)
        {
            yield return new WaitForSeconds(createTime);
            int idx = Random.Range(1, points.Length);
            Instantiate(monster, points[idx].position, Quaternion.identity);
        }
        else
        {
            yield return new WaitForSeconds(createTime);
        }

        StartCoroutine("CreateObject");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
