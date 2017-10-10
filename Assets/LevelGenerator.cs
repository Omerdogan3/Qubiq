using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	//public int minZtoGenerate = 3; //minimum required z position to start generate gameObjects.
	private GameObject player;

	private int generateLocationZ;

	public GameObject tree;
	public int numberOfTrees;

	// Use this for initialization
	void Start () {
		player  = GameObject.FindGameObjectWithTag("Player");




		GenerateTrees (numberOfTrees);
	}

	void Update(){
	}

	void GenerateTrees(int numOfTrees){
		++generateLocationZ;
		PlayerPrefs.SetInt ("generateLocationZ", generateLocationZ);

		for(int i=0; i<numOfTrees; ++i) {
			Vector3 instanPos = new Vector3((int)Random.Range(-20.0f, 20.0f), 0, (int)Random.Range(0f, 3.0f));
			if (!(generateLocationZ == 1 && (instanPos.x <= 1 && instanPos.z <= 0))) { //if trees will be generated in first platform
				GameObject instant = Instantiate(tree, instanPos, Quaternion.identity) as GameObject;	
			}
		}
	}

}
