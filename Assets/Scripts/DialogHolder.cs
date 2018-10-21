using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogHolder : MonoBehaviour
{
    public GameObject dBox;
    public Text nameText, contentText;
    public Button continueButton;

    public bool dialogActive = false;

    public static DialogHolder Instance { get; set; }
    public List<string> dString = new List<string>();
    public string npcName;


    private PlayerControl playerCtrl;
    bool cBool;
    int cnt = 0;
    int dialogIndex;


    private void Awake()
    {
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
           
        }
    }

    // Use this for initialization
    void Start()
    {

        dBox.SetActive(false);

        playerCtrl = FindObjectOfType<PlayerControl>();

    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        contentText.text = dialogue;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (cBool)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dialogActive = true;
                playerCtrl.playerMove = false;

                ContinueDialogue();
            }
        }*/
    }
   
    public void AddNewDialogue(string[] lines, string name)
    {
        dialogIndex = 0;
        npcName = name;
        foreach(string line in lines)
        {
            dString.Add(line);
        }

        
        CreateDialogue();
        
        Debug.Log("dString : " + dString.Count);
        
    }

    public void CreateDialogue()
    {
        contentText.text = dString[dialogIndex];
        nameText.text = npcName;
        dBox.SetActive(true);
        playerCtrl.playerMove = false;
    }

    public void ContinueDialogue()
    {
        if(dialogIndex < dString.Count)
        {
            
            contentText.text = dString[dialogIndex];
            dialogIndex++;

        }
        else
        {
            dBox.SetActive(false);
            dialogActive = false;
            playerCtrl.playerMove = true;
            dialogIndex = 0;
            dString.Clear();
        }
    }

    public void MasiIn()
    {
        cBool = true;
    }
    public void MasiOut()
    {
        cBool = false;
    }
}