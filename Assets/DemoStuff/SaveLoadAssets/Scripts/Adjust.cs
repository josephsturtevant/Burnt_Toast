using UnityEngine;
using System.Collections;

public class Adjust : MonoBehaviour {

	void OnGUI(){
		GUILayout.BeginArea (new Rect (Screen.width - 200, Screen.height - 200, 200, 200));
		GUILayout.FlexibleSpace ();
		if(GUILayout.Button ("Experience Up")){
			GlobalGameManager.control.Experience += 10;
		}
		if(GUILayout.Button ("Experience Down")){
			GlobalGameManager.control.Experience -= 10;
		}
		if(GUILayout.Button ("Health Up")){
			GlobalGameManager.control.Health += 10;
		}
		if(GUILayout.Button ("Health Down")){
			GlobalGameManager.control.Health -= 10;
		}
		if(GUILayout.Button ("Save")){
			Debug.Log("SAVE SUCCEEDED");
			GlobalGameManager.control.Save();
		}
		if(GUILayout.Button ("Load")){
			Debug.Log("LOAD SUCCEEDED");
			GlobalGameManager.control.Load();
		}
		GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
	}
}
