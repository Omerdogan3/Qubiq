using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	static bool isAlive = true;


	public float speed = 6; //character's speed
	public float jumpForce = 10; //character's jump velocity
	private bool isGround = false;


	public LayerMask groundLayer;

	private Rigidbody rb; //rigidbody component

	void Awake(){
		rb = this.GetComponent<Rigidbody> ();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


	//Obje haraketliyse ve collider'i farkli objelerle temas halindeyse
	//titreme gibi durumlardan uzak durmak icin FixedUpdate kullanilir.
	void FixedUpdate(){
		//Eger karakter canliysa && user tusa basiyorsa hareket ettir.

		if (isAlive == true) {
			if(Input.GetKey(KeyCode.Space) && isGrounded()){
				Jump ();
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
			}
		} else {
			
		}
	}

	public void Jump(){
		rb.AddForce (transform.up * jumpForce);
	}

	public bool isGrounded(){
		if (Physics.Raycast(transform.position,-Vector3.up,1f,groundLayer)) {
			isGround = true;
			return isGround;
		}
		return !isGround;
	}

}
