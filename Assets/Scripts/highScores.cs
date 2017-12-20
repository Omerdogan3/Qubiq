using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScores : MonoBehaviour {

	const string publicCode = "59a15bf46b2b66243c586db1";
	const string privateCode = "t-XJ7B87Ok2G_1y0cnDvcQqXFb1hl2EUyN8h4RQP4M7w";
	const string webUrl = "http://dreamlo.com/lb/";

	public HighScore[] highScoresList;
	static highScores instance;
	displayHighScores highscoresDisplay;

	void Awake(){
		instance = this;
		highscoresDisplay = GetComponent<displayHighScores>();
		DownloadHighScores ();

		AddNewHighScore ("Omer", 10);AddNewHighScore ("OdTest", 1230);

	}

	void Start(){
	}

	//-----------HelperMetHods----------
	public static void AddNewHighScore(string userName, int score){
		instance.StartCoroutine (instance.UploadNewHighScore (userName, score));
	}

	public void DownloadHighScores(){
		StartCoroutine ("DownloadHighScoresFromDatabase");
	}
	//----------------------------------


	IEnumerator UploadNewHighScore (string UserName, int score){
		WWW www = new WWW (webUrl + privateCode + "/add/" + WWW.EscapeURL (UserName) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			print ("Upload Successful");
			DownloadHighScores ();
		} else {
			print ("Error Uploading: " + www.error);
		}
	}	
		
	IEnumerator DownloadHighScoresFromDatabase (){
		WWW www = new WWW (webUrl + publicCode + "/pipe/0/10"); // it will download first 10 highscores
		yield return www;

		if (string.IsNullOrEmpty (www.error)) {
			FormatHighScores (www.text);
			highscoresDisplay.OnHighScoresDownloaded (highScoresList);
		} else {
			print ("Error Downloading: " + www.error);
		}
	}	

	void FormatHighScores(string textStream){
		string[] entries = textStream.Split (new char[]{ '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highScoresList = new HighScore[entries.Length];
		for (int i = 0; i < entries.Length; ++i) {
			string[] entryInfo = entries [i].Split (new char[] { '|' });
			string username = entryInfo [0];
			int score = int.Parse(entryInfo [1]);
			highScoresList [i] = new HighScore (username, score);
			print (highScoresList [i].userName + ": " + highScoresList [i].score);
		}
	}
}


	public struct HighScore{
		public string userName;
		public int score;
		public HighScore(string _userName, int _score){
			userName = _userName;
			score = _score;
		}
	}