using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    static bool Sound;

    private void Awake()
    {
        Screen.SetResolution(1280, 720, false);

    }

    // Use this for initialization
    void Start () {
        if (!Sound)
        {
            Sound = true;
            MusicSource.clip = MusicClip;
            MusicSource.Play();

            DontDestroyOnLoad(transform.gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
