using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Transform target;


    
    public float smoothTime = .15f;

    public bool YMaxEnabled = false;
    public float YMax = 0;

    public bool YMinEnabled = false;
    public float YMin = 0;

    public bool XMaxEnabled = false;
    public float XMax = 0;

    public bool XMinEnabled = false;
    public float XMin = 0;

    private static bool playerExists;

    void Start()
    {
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void LateUpdate()
    {
        Vector3 targetPos = target.position;

        //vertical
        if (YMinEnabled && YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMin, YMax);

        //horizontal
        if (XMinEnabled && XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMin, XMax);


        targetPos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothTime);
        
    }
}
