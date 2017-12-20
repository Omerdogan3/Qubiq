using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayHighScores : MonoBehaviour {

	public Text[] highScoreText;
	highScores highScoreManager;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < highScoreText.Length; ++i) {
			highScoreText [i].text = i+1  + ". Fectching...";
		}

		highScoreManager = GetComponent<highScores> ();

		StartCoroutine ("RefreshHighScores");
	}

	public void OnHighScoresDownloaded(HighScore[] highScoreList){
		for (int i = 0; i < highScoreText.Length; ++i) {
			highScoreText [i].text = i+1  + ". ";
			if (highScoreList.Length > i) {
				highScoreText [i].text += highScoreList [i].userName + " - " + highScoreList [i].score;
			}
		}
	}
	
	IEnumerator RefreshHighScores(){
		while (true) {
			highScoreManager.DownloadHighScores ();
			yield return new WaitForSeconds (30);
		}
	}
}
