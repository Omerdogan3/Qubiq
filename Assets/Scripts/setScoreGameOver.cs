using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setScoreGameOver : MonoBehaviour {

	public GameObject controllerObj;
	public Text scoreText;
	private GameController gameController;
	public Text moneyEarnedText;

	// Use this for initialization
	void Start () {
		gameController = controllerObj.GetComponent<GameController> ();
		SetPersonalHighScore ();
		PlayerPrefs.SetInt ("Score", gameController.GetScore ());
		moneyEarnedText.text = (gameController.GetScore () / 100).ToString();
		moneyManager.moneyOwned = moneyManager.moneyOwned +  gameController.GetScore () / 100;
		PlayerPrefs.SetInt ("moneyOwned", moneyManager.moneyOwned);
		scoreText.text = gameController.GetScore ().ToString();
	}
	
	void SetPersonalHighScore(){
		if (gameController.GetScore () > PlayerPrefs.GetInt ("PersonalHighScore")) {
			PlayerPrefs.SetInt ("PersonalHighScore", gameController.GetScore ());
			highScores.AddNewHighScore (PlayerPrefs.GetString("UserName"), PlayerPrefs.GetInt("PersonalHighScore"));
		}
	}
}
