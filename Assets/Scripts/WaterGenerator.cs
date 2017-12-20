using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour {

	public GameObject waterObj;
	public int waterSpawnTime;

	public GameObject player;

	// Use this for initialization
	void Start () {
		//waterSpawn ();
		//InvokeRepeating ("waterSpawn", 0, waterSpawnTime);
	}
	/*
	void waterSpawn(){
		transform.Translate(new Vector3(100,0,0));
		Vector3 pos = new Vector3 (this.transform.position.x,  this.transform.position.y, this.transform.position.z);
		GameObject waterIns = Instantiate (waterObj, pos, transform.rotation) as GameObject;
	}*/

	void Update(){
		
		transform.position = new Vector3 (player.transform.position.x, 0f, 0f);
	}

}
