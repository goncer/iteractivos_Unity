using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]  //With this stament we force Unity to add a rigidbody to a game object
public class PlayerController : MonoBehaviour {
	public float speed = 150; //Points per unit of time
	public GameObject plane;
	private const string TAG_COLLECT = "Collect Me";
	private GameController gameController;
	private Rect limits = new Rect();
	/*
	 *  In order to illustrate how Collision detection works, set speed to 15000
	 * and then ensure that collision detection in the rigdbody is set to Discrete. 
	 * Run the game and move the player straight to a wall.
	 * After that, change to continuous and try again
	 */ 
	private Rigidbody rigid;
	// Use this for initialization
	void Start (){
		rigid = gameObject.GetComponent<Rigidbody> ();
		//Looking for the GameController Script
		gameController = (FindObjectsOfType (typeof(GameController)) 
			as GameController[]) [0];
		//create an object rect to check if the player is between the limits
		limits = new Rect(plane.transform.position,new Vector2 (plane.transform.lossyScale.x,plane.transform.lossyScale.z));
	}
	
	// Update is called once per frame
	/*void Update () {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 position = transform.position;
		position.x += x * speed * Time.deltaTime;
		position.z += z * speed * Time.deltaTime;
		transform.position = position;

	
	}*/

	void FixedUpdate (){
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 force = new Vector3 (x * speed * Time.deltaTime,0,z * speed * Time.deltaTime);
		rigid.AddForce(force);
	}

	//Collecting
	/*
	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag.Equals (TAG_COLLECT))
		{//IF //The object was collected and must be destroyed
			GameObject.Destroy(collision.gameObject);
		}//IF
	}*/
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals (TAG_COLLECT))
		{//IF //The object was collected and must be destroyed
			GameObject.Destroy(other.gameObject);
			SendMessage("PartCollected");
		}//IF
	}

	//Services provided


}
