using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public int minZtoGenerate = 3; //minimum required z position to start generate gameObjects.
	private GameObject player;

	// Use this for initialization
	void Start () {
		player  = GameObject.FindGameObjectWithTag("Player");

	}

}
