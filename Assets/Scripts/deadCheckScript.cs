using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadCheckScript : MonoBehaviour {
	public GameObject playerObj;
	private Player player;
	public GameObject gameOverCanvas;

	// Use this for initialization
	void Start () {
		player = playerObj.GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "DeadZone") {
			player.isAlive = false;
			gameOverCanvas.SetActive (true);
		}
	}
}
