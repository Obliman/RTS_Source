using UnityEngine;
using System.Collections;

public class InGameGUI : MonoBehaviour {

	public static bool isPlacing = false;
	public static bool building = false;
	public GameObject gBlock;
	Camera cam;

	float accumTime;
	float buildTime;
	private BlockScript scrpt;
	GameObject lastHit;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void OnGUI(){
		DrawQuad(new Rect(0,Screen.height-80,Screen.width,80),new Color (0.0f, 0.0f, 0.0f, 1.0f),"");
		if (GUI.Button (new Rect (Screen.width/2 - 45, Screen.height - 50, 100, 40), "Box")) {
			if(isPlacing){
				isPlacing = false;
			}else{
				isPlacing = true;
				Instantiate(gBlock,Input.mousePosition,Quaternion.identity);
			}
		}
		if(building){ //replace with scaled plane 
			DrawQuad(new Rect(Screen.width/2,Screen.height/2,120,40),new Color (0.0f, 0.0f, 0.0f, 1.0f),"BUILDING");
			DrawQuad(new Rect(Screen.width/2,Screen.height/2,15+Mathf.Round(105 * accumTime/buildTime),40),new Color (0.0f, 1.0f, 0.0f, 0.5f),"");
		}
	}

	void Update(){
		if(!isPlacing){
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
				if(hit.transform.tag == "Block"){
					lastHit = hit.transform.gameObject;
					if(Input.GetMouseButtonDown(1) && !building){
						building = true;
						accumTime = 0;
					}
				}
				if (building) {
					scrpt = lastHit.transform.GetComponent<BlockScript>();
					buildTime = scrpt.checkStructure();
					building = progBar();
				}
			}
		}
	}

	bool progBar(){
		accumTime += Time.deltaTime;
		return !(accumTime >= buildTime);
	}

	void DrawQuad(Rect position, Color color, string strng) {
		Texture2D texture = new Texture2D(1, 1);
		texture.SetPixel(0,0,color);
		texture.Apply();
		GUI.skin.box.normal.background = texture;
		GUI.skin.box.fontSize = 24;
		GUI.Box(position, strng);
	}
}
