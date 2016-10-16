using UnityEngine;
using System.Collections;

public class AreaController : MonoBehaviour {

	private GameController gameController;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		gameController = (FindObjectsOfType (typeof(GameController)) 
			as GameController[]) [0];
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerExit(Collider other) {
		if (other.gameObject.name.Equals(player.gameObject.name) )
		{
			gameController.scoreBoard.text = "EndOfGame! you fall!";
			SendMessage ("EndGame");
		}
	}

}
