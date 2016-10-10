using UnityEngine;
using System.Collections;

public class MoveRandom : MonoBehaviour {

	private Rigidbody _rBody;
	// Use this for initialization
	void Start () {
		_rBody = GetComponent<Rigidbody> ();
		float x = Random.Range (-50, 50);
		float z = Random.Range (-50, 50);
		Vector3 force = new Vector3 (0, 0, 0);

		force.x = x ;
		force.z = z ;

		_rBody.AddForce (force);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision){
		
		_rBody.AddForce (new Vector3 ( (collision.impulse).x * (-1), 0, (collision.impulse).z * (-1)) );
	}
}
