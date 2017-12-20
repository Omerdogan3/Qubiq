using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starController : MonoBehaviour {

	public int spawnTime;
	public GameObject[] starArray;

	public GameObject playerObj;
	private Player player;

	public List<GameObject> spawnedStarsList;
	private int spawnedStarsNum=0;

	void Awake(){
		player = playerObj.GetComponent<Player> ();
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("starSpawn", 0, spawnTime);
		InvokeRepeating ("Destroyer", 0, spawnTime+5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/* UnNecessary
	public void Destroy(int i){
		foreach (Transform child in Transform) {
			if (child.name == i) {
				GameObject.Destroy(child.gameObject);
			}
		}
	} 
	*/

	void starSpawn(){
		if (player.isAlive) {
			float randX = Random.Range (10, 50);
			int randomCollecible = (int)Random.Range (0, starArray.Length);
			transform.Translate(new Vector3(randX,0,0));
			Vector3 pos = new Vector3 (this.transform.position.x,  this.transform.position.y, 0);
			GameObject tmpObj = Instantiate (starArray [randomCollecible], pos, transform.rotation) as GameObject;
			tmpObj.transform.SetParent (GameObject.Find ("StarGameObject").transform);
			++spawnedStarsNum;
			spawnedStarsList.Add (tmpObj);

		}
	}

	void Destroyer(){
		if (player.isAlive && spawnedStarsNum > 2) {

			GameObject tmp = spawnedStarsList[spawnedStarsNum-1];
			Vector3 tmpPos = new Vector3 (tmp.transform.position.x, 0, 0);
			Destroy (tmp,30);
			Debug.Log ("Destroyed " +  tmpPos.x);
		}
	}

}
