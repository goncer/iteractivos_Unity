using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float fuerza;
	private Rigidbody _rBody;
	//public long velocidad = 10;
	// Use this for initialization
	void Start () {
		_rBody = GetComponent<Rigidbody> ();


	}

	void FixedUpdate () {


		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		Vector3 force = new Vector3 (0, 0, 0);
		force.x += x * fuerza  ;
		force.z += z * fuerza  ;

		_rBody.AddForce (force);
	}
	
	// Update is called once per frame
	 /** void Update () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		Vector3 posicion = gameObject.transform.position;

		posicion.x += x * velocidad + Time.deltaTime;
		posicion.z += z * velocidad + Time.deltaTime;
		gameObject.transform.position = posicion;
			
	} ***/



}
