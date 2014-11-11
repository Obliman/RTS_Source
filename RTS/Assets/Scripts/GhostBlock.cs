using UnityEngine;
using System.Collections;

public class GhostBlock : MonoBehaviour {

	public GameObject Block;
	public static bool canPlace = true;
	Camera cam;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}

	void FixedUpdate () {
		if(InGameGUI.isPlacing && canPlace){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
				gameObject.transform.position = new Vector3(Mathf.Round(hit.point.x*0.5f)/0.5f,1.0f+Mathf.Round(hit.point.y*0.5f)/0.5f,Mathf.Round(hit.point.z*0.5f)/0.5f);
				if(Input.GetMouseButtonDown(0)){
					Instantiate(Block,new Vector3(transform.position.x,transform.position.y-1.0f,transform.position.z),transform.localRotation);
				}
			}
		}else if(!InGameGUI.isPlacing){
			Destroy(gameObject);
		}

		if(Input.mousePosition.y < 80){
			canPlace = false;
		}else{ //if count is high enough
			canPlace = true;
		}
	}
}
