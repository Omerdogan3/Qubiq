using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour {

	public int backgroundSpawnTime;

	public GameObject[] backgroundArray;
	public List<GameObject> inScene;

	private int counter=30;
	private int spawnedObjNum = 0;

	public GameObject playerObj;
	private Player player;

	void Awake(){
		player = playerObj.GetComponent<Player> ();
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("backgroundSpawn", 0, backgroundSpawnTime);
		//InvokeRepeating ("Destroyer", 5, backgroundSpawnTime);
	}

	void backgroundSpawn(){
		float randX = Random.Range (60, 80);
		int randomBackground = (int)Random.Range (0, backgroundArray.Length);
		transform.Translate(new Vector3(randX,0,0));
		Vector3 pos = new Vector3 (this.transform.position.x,  this.transform.position.y, 0);
		GameObject tmpObj = Instantiate (backgroundArray [randomBackground], pos, transform.rotation) as GameObject;
		tmpObj.transform.SetParent (GameObject.Find ("BackgroundGameObject").transform);
		++spawnedObjNum;
		inScene.Add (tmpObj);
	}

	void Destroyer(){
		if (player.isAlive) {
			GameObject tmp = inScene[spawnedObjNum-1];
			Destroy (tmp,counter);
		}
	}


}
