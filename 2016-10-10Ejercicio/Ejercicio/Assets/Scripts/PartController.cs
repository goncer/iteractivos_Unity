using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))] //Si ponemos esto hace que se añada el rigidbody al asignar el script a un objeto
public class PartController : MonoBehaviour {
	//degrees to increment 
	private float xDegree = 5f;
	private float yDegree = 7.2f;
	private float speed = 100;
	private Rigidbody rigid;
	private bool incX = false;
	private bool incZ = true;
	// Use this for initialization
	void Start () {
		Random.seed = 57;
		rigid = this.GetComponent<Rigidbody>();
		incX = ((int)Random.value*10)%2 == 0 ;
		incZ = !incX;
		//Debug.Log("Valores:"+ Random.value+" "+Random.value);
	}

	// Update is called once per frame
	/*void Update () {
		//transform.Rotate (new Vector3 (xDegree,yDegree,0));
		float x = speed * Time.deltaTime * ((incX)? 1: -1);
		float z = speed * Time.deltaTime * ((incZ)? 1: -1);	
		rigid.AddForce (new Vector3 (x,0.0f,z));
		rigid.AddTorque(new Vector3 (xDegree,yDegree,0));
	}*/

	void FixedUpdate() {
		float x = speed * Time.deltaTime * ((incX)? 1: -1);
		float z = speed * Time.deltaTime * ((incZ)? 1: -1);	
		rigid.AddForce (new Vector3 (x,0.0f,z));
		//transform.Rotate (new Vector3 (xDegree,yDegree,0));
		rigid.AddTorque(new Vector3 (xDegree,yDegree,0));
	}

	//We have to change direction when there are a collision with a wall
	void OnCollisionEnter (Collision collision)
	{
		switch (collision.gameObject.name) {//SW
		case "NorthWall":
			incZ = false;
			break;
		case "SouthWall":
			incZ = true;
			break;
		case "WestWall":
			incX = true;
			break;
		case "EastWall":
			incX = false;
			break;
		}//SW
	}
	public void increaseSpeed(int percentage)
	{
		Debug.Log ("Incresing Speed from : " + speed );
		speed = speed + (speed * percentage / 100);
		Debug.Log ("To : " + speed );
	}
}
