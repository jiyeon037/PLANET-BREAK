using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // private Bound[] bounds; // 여기 내용 47분에 나옴
    private PlayerControl thePlayer;
    private CameraControl theCamera;

    public void LoadStart()
    {
        StartCoroutine(LoadWaitCoroutine());
    }

    IEnumerator LoadWaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        thePlayer = FindObjectOfType<PlayerControl>();
        theCamera = FindObjectOfType<CameraControl>();
        // Bounds = FindObjectsOfType<Bound>();
        // 카메라스크립트 48:22
        // theCamera.target = GameObject.Find("Masi");
    }
}
