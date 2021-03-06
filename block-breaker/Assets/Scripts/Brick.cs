﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// Keep track of breakable bricks
		if(isBreakable) {
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if(isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke ();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}

	void PuffSmoke() {
		GameObject puffOfSmoke = (GameObject)Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		puffOfSmoke.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

	// TODO delete this method once proper channel for victory is complete
	void winSimulator () {
		levelManager.LoadNextLevel();
	}
}
