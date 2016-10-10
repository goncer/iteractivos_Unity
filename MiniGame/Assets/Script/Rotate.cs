using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float rotateX;
	public float rotateY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (new Vector3 (rotateX, 0, rotateY));
	}
}
