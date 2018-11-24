using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButton : MonoBehaviour {

    public GameObject dialog;
    public GameObject cat;
    public GameObject dog;
    public GameObject bird;
    public GameObject snake;
    public GameObject masi;
    public GameObject masiInShip;

    public void onClickNo()
    {
        dialog.SetActive(false);
    }

    public void onClickYes()
    {
        dialog.SetActive(false);
        Instantiate(cat, new Vector3((float)-2.963233, (float)-3.460521), Quaternion.identity);
        Instantiate(dog, new Vector3((float)2.4, (float)-3.399361), Quaternion.identity);
        Instantiate(snake, new Vector3((float) -5.036814, (float)-1.796026), Quaternion.identity);
        Instantiate(bird, new Vector3((float)4.538657, (float)-2.419545), Quaternion.identity);

        DialogHolder.Instance.AddNewDialogue(new string[]{ "우주선을 모두 고쳤구나!", "이제 떠나는거니?", "덕분에 우리 행성 친구들도 도움을 많이 받았어.", "조심히 가. 행운을 빌어!"}, "모두들");

        Invoke("masiRide", 7f);
        Invoke("toEndingScene", 10f);
    }

    void masiRide()
    {
        Destroy(masi);
        Instantiate(masiInShip, new Vector3((float)1.63, (float)5.83), Quaternion.identity);
    }
    
    void toEndingScene()
    {
        SceneManager.LoadScene("Ending");
    }
    // Use this for initialization
    void Start () {
        dialog.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
