using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public GameObject toFollow;
	//private float descInicial = 10;
	private Vector3 posCamera;
	// Use this for initialization
	void Start () {
		posCamera = toFollow.transform.position  -  this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.position = toFollow.transform.position - posCamera;

	}
}
