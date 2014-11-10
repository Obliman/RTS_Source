using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	float X;
	float Y;
	float Z;

	// Use this for initialization
	void Start () {
		X = Mathf.Round (gameObject.transform.position.x*0.5f)/0.5f;
		Y = 1.0f+Mathf.Round (gameObject.transform.position.y*0.5f)/0.5f;
		Z = Mathf.Round (gameObject.transform.position.z*0.5f)/0.5f;
		gameObject.transform.position = new Vector3 (X,Y,Z);
	}

	void FixedUpdate () {
	
	}
}
