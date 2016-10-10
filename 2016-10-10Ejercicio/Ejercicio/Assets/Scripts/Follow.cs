using UnityEngine;
using System.Collections;


public class Follow : MonoBehaviour {
	//Public attribute in order so, it is accesible in the editor
	public GameObject follow;
	//Relative Position among the follower and the follow
	private Vector3 relativePosition;
	// Use this for initialization
	void Start () {
		relativePosition = follow.transform.position - transform.position;
	}
	
	// We have to updaate position follower after update the frame
	void LateUpdate () {
		transform.position = follow.transform.position - this.relativePosition;
	}
}
