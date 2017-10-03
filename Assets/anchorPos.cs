using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anchorPos : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//this is a player anchor object. It moves on only x and z positions of player object.
		//attached to camera
		gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
	}
}
