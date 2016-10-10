using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	private const int POINT_PER_PART = 5;
	private int score = 0;
	public Text scoreBoard = null;
	private string textScoreBoard = "";
	private int numCubes = 0;
	private GameObject player;
	// Use this for initialization
	void Start () {
		if (scoreBoard != null){
			textScoreBoard = scoreBoard.text;
		}
		player = GameObject.FindGameObjectWithTag ("Player");

		numCubes = GameObject.FindGameObjectsWithTag ("Collect Me").Length;
	}
		
	// Update is called once per frame
	void Update () {
		
	}

	//Services provided
	public void PartCollected (){
		score += GameController.POINT_PER_PART;
		numCubes--;
		if (scoreBoard != null){
			scoreBoard.text = textScoreBoard + score;
		}
		if (numCubes.Equals (0)) {
			scoreBoard.text = "You WON! with:" + score + "points";
		}
			
	}
		
	//Auxilar services

}
