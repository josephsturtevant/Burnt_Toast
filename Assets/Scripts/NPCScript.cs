using UnityEngine;
using System.Collections;

public class NPCScript : MonoBehaviour {

	public float NPCDistance = 0.3f;
	private Transform controller = null;
	private bool inRange;
	private string NPCtalkString = "";

	// Use this for initialization
	void Start () {
		controller = GameObject.Find("Player").GetComponent<Transform>();
		inRange = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (withinRange (controller)) {
			inRange = true;
			displayInteractableIcon (inRange);
			if (Input.GetButton("A"))
				Interact(inRange);
		} else {
			inRange = false;
		}
	}

	bool withinRange(Transform controller){
		if (this.getDistance(controller) <= NPCDistance) {
			return true;
		} else {
			return false;
		}
	}
	
	void displayInteractableIcon(bool isInRange){
		
	}

	void OnGUI()
	{
		GUI.contentColor = Color.magenta;
		GUI.Label(new Rect(5,  5, 130, 25), NPCtalkString);
	}

	void Interact(bool isInRange){
		Debug.Log ("Here is text proving that you are talking to an NPC!");
		NPCtalkString = "You talked to an NPC!";
	}

	public float getDistance( Transform hero ){
		return Vector3.Distance (hero.transform.position, this.transform.position);
	}
}
