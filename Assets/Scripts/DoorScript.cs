using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public float doorDistance = 0.35f;
	private Transform controller = null;
	private bool inRange;
	public string targetArea = null;
	private Transform target;
	public string appearLocation = null;
	public float offsetY = 0.2f;
	//public string targetAreaCameraName, currentAreaCameraName;
	//private Camera CurrentCamera, AreaCamera;

	// Use this for initialization
	void Start () {
		controller = GameObject.Find("Player").GetComponent<Transform>();
		this.target = GameObject.Find(targetArea).GetComponent<Transform> ();
		//AreaCamera = GameObject.Find(targetAreaCameraName).GetComponent<Camera> ();
		//CurrentCamera = GameObject.Find (currentAreaCameraName).GetComponent<Camera> ();
		inRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (withinRange (controller)) {
			inRange = true;
			displayInteractableIcon (inRange);
			if (Input.GetButton("A")){
				Debug.Log ("In range of object!");
				Interact(inRange);
			}
		} else {
			inRange = false;
		}
	}

	bool withinRange(Transform controller){
		if (this.getDistance(controller) <= doorDistance) {
			return true;
		} else {
			return false;
		}
	}
	
	void displayInteractableIcon(bool isInRange){

	}

	void Interact(bool isInRange){
		float positionOffset = 0.0f;
		if(isInRange)
			//Debug.Log (currentAreaCameraName + "  " + targetAreaCameraName);
			//CurrentCamera.gameObject.SetActive(false);
			//AreaCamera.gameObject.SetActive(true);
		if (appearLocation == "Left") {
			positionOffset = -0.7f;
			controller.transform.position = new Vector3 (target.transform.position.x + positionOffset, 
			                                             target.transform.position.y - offsetY, 
			                                             target.transform.position.z);
		} else if (appearLocation == "Front") {
			positionOffset = -0.7f;
			controller.transform.position = new Vector3 (target.transform.position.x, 
			                                             target.transform.position.y - offsetY, 
			                                             target.transform.position.z + positionOffset);
		} else if (appearLocation == "Right") {
			positionOffset = 0.7f;
			controller.transform.position = new Vector3 (target.transform.position.x + positionOffset, 
			                                             target.transform.position.y - offsetY, 
			                                             target.transform.position.z);
		} else if (appearLocation == "Behind") {
			positionOffset = 0.7f;
			controller.transform.position = new Vector3 (target.transform.position.x, 
			                                             target.transform.position.y - offsetY, 
			                                             target.transform.position.z + positionOffset);
		}
	}
	
	public float getDistance( Transform hero ){
		return Vector3.Distance (hero.transform.position, this.transform.position);
	}
	
	/*public Vector3 getDir( Transform hero ){
		Vector3 dir = this.transform.position - hero.transform.position;
		return Vector3.Normalize (dir);
	}*/

}
