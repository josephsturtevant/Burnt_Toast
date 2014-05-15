using UnityEngine;
using System.Collections;

public class GoBackToMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Start")){
			Application.LoadLevel ("PrototypeMenu");
		}
	}
}
