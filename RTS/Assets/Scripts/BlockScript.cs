using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	float X;
	float Y;
	float Z;
	static GameObject[] blocks;
	Camera cam;
	private BlockScript scrpt;
	int var;

	// Use this for initialization
	void Start () {
		X = Mathf.Round (gameObject.transform.position.x*0.5f)/0.5f;
		Y = 1.0f+Mathf.Round (gameObject.transform.position.y*0.5f)/0.5f;
		Z = Mathf.Round (gameObject.transform.position.z*0.5f)/0.5f;
		gameObject.transform.position = new Vector3 (X,Y,Z);
		cam = Camera.main;
	}

	void FixedUpdate(){
		Debug.DrawRay(new Vector3(0,0,0), Vector3.up, Color.green);
	}

	public int checkStructure(){
		transform.tag = "Checked";

		RaycastHit hit;

		Vector3[] dir = new Vector3[6];
		dir[0] = transform.TransformDirection (Vector3.forward);
		dir[1] = transform.TransformDirection (Vector3.left);
		dir[2] = transform.TransformDirection (Vector3.right);
		dir[3] = transform.TransformDirection (Vector3.back);
		dir[4] = transform.TransformDirection (Vector3.up);
		dir[5] = transform.TransformDirection (Vector3.down);
		
		for(int i = 0; i<dir.Length; i++){
			if (Physics.Raycast(transform.position, dir[i], out hit)){
				Debug.Log (hit.distance);
				if(hit.transform.tag == "Block" && hit.distance <= 1.5f){
					hit.transform.tag = "Checked";
					scrpt = hit.transform.GetComponent<BlockScript>();
					var = scrpt.checkStructure();
					//need third party to check that everything has finished checking and then find overall value
				}
			}
		}

		//blocks = GameObject.FindGameObjectsWithTag ("Block");
		return blocks.Length;
	}
}
