using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]  //With this stament we force Unity to add a NavMeshAgent to a game object
public class EnemyControler : MonoBehaviour
{
	public const int SECONDS_BETWEEN_ATTACK = 2;
	//public int raisePlayer = 5;
	private GameObject player;
	private Rigidbody playerRigid;
	//Player Rigid Body
	private NavMeshAgent pathFinder;
	private Animator anim;
	private bool isActivate;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		pathFinder = this.GetComponent<NavMeshAgent> ();
		anim = this.GetComponent<Animator> ();
		isActivate = false;
		playerRigid = player.GetComponent<Rigidbody> ();
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
	}

	//Auxilliary services

}
