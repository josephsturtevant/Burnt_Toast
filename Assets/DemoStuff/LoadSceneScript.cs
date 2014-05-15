using UnityEngine;
using System.Collections;

public class LoadSceneScript : MonoBehaviour {

	public string TargetLevelName;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseOver() {
		Debug.Log ("mouse over");
	}
	
	void OnMouseUp() {
		Application.LoadLevel(TargetLevelName);
	}
}