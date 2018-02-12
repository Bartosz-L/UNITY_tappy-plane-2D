using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        // in case of returnig to menu and then playing two copies of MusicManager
        if(FindObjectsOfType<MusicManager>().Length > 1)
        {
            Destroy(gameObject);
        }

        // dont destroy when there is only one MusicManager on load new scene
        DontDestroyOnLoad(gameObject);
	}

}
