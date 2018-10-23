using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioStatus : MonoBehaviour {

    public AudioSource gameAudio;
    private int numberofAudioSources;


    private void Awake()
    {
        numberofAudioSources = FindObjectsOfType<AudioStatus>().Length;

        if(numberofAudioSources>1)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}
}
