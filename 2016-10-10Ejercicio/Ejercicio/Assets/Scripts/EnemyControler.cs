using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]  //With this stament we force Unity to add a NavMeshAgent to a game object
public class EnemyControler : MonoBehaviour
{
	public const int SECONDS_BETWEEN_ATTACK = 2;
	public float powerHit = 0F;
	//public int raisePlayer = 5;
	private GameObject player;
	private Rigidbody playerRigid;
	//Player Rigid Body
	private NavMeshAgent pathFinder;
	private Animator anim;
	private bool isActivate;

	private System.DateTime? lastHitTime = null;
	private GameController gameController;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		pathFinder = this.GetComponent<NavMeshAgent> ();
		anim = this.GetComponent<Animator> ();
		isActivate = false;
		playerRigid = player.GetComponent<Rigidbody> ();

		//Looking for the GameController Script
		gameController = (FindObjectsOfType (typeof(GameController)) 
			as GameController[]) [0];
		//get the speed of the actual onbject.
		float speedAplied = (FindObjectsOfType (typeof(PlayerController)) 
			as PlayerController[]) [0].speed;
		this.powerHit = speedAplied * 3;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ( this.isActivate) {
			//A new destination to NavMesAgent is set
			pathFinder.SetDestination (player.transform.position);
		}
		//is walking
		anim.SetBool ("isWalking", this.isActivate &&
		pathFinder.remainingDistance > pathFinder.stoppingDistance);
	}

	//The enemy activation when he will see the player
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag.Equals ("Player")) {
			this.isActivate = true;
		}
	}

	//If the enemy touches the player, the player is wounded
	void OnCollisionEnter (Collision collision)
	{
		if(collision.gameObject.name.Equals(player.gameObject.name) ){
			
			if (lastHitTime == null || lastHitTime < System.DateTime.Now.AddSeconds(SECONDS_BETWEEN_ATTACK)){
				//there where more than 2 sec between last impact OR null
				lastHitTime = System.DateTime.Now;
				this.gameController.PlayerGotHit();
				//getSpeedValue.
				player.GetComponent<Rigidbody> ()
					.AddExplosionForce ( powerHit, this.transform.position,5.0F);
			}
		}
	}

	//Auxilliary services

}
