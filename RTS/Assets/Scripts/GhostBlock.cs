using UnityEngine;
using System.Collections;

public class GhostBlock : MonoBehaviour {

	RaycastHit hit;
	public GameObject Block;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit)){
			gameObject.transform.position = new Vector3(Mathf.Round(hit.point.x*0.5f)/0.5f,1.0f+Mathf.Round(hit.point.y*0.5f)/0.5f,Mathf.Round(hit.point.z*0.5f)/0.5f);
			if(Input.GetMouseButtonDown(0)){
				Instantiate(Block,new Vector3(transform.position.x,transform.position.y-1.0f,transform.position.z),transform.localRotation);
				//Destroy (this.gameObject);
			}
		}
	}
}
