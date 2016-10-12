using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	private const int POINT_PER_PART = 5;
	private int score = 0;
	public Text scoreBoard = null;
	private string textScoreBoard = "";
	private GameObject player;
	// Use this for initialization
	void Start () {
		if (scoreBoard != null){
			textScoreBoard = scoreBoard.text;
		}
		player = GameObject.FindGameObjectWithTag ("Player");
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	//Services provided
	public void PartCollected (){
		score += GameController.POINT_PER_PART;
		if (scoreBoard != null){
			scoreBoard.text = textScoreBoard + score;
		}
		var remainingElements = GameObject.FindGameObjectsWithTag ("Collect Me");
		//is the last element ?
		if (remainingElements.Length == 1) {
			scoreBoard.text = "You WIN! with:" + score + "points";
		}
			
	}

	public void PlayerGotHit()
	{
		this.score -= 2 *  POINT_PER_PART;
		CheckGameStatus();
	}

	//Auxilar services
	private void CheckGameStatus()
	{
		if (this.score < 0) {
			scoreBoard.text = "You Loose! Score < 0"; 
		}
	}
}
