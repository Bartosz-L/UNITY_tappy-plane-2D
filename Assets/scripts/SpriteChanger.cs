﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour {

    public Sprite[] Sprites;
    public float Duration = 1f;


	// Use this for initialization
	void Start () {
        StartCoroutine(ChangeSpriteCoroutine());
	}
	
    IEnumerator ChangeSpriteCoroutine()
    {
        var renderer = GetComponent<SpriteRenderer>();
        for (int i=0; true; i++)
        {
            renderer.sprite = Sprites[i % Sprites.Length];
            yield return new WaitForSeconds(Duration);
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
