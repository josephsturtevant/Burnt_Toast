using UnityEngine;
using System.Collections;

public class LoadLevelOnMouse : MonoBehaviour {
	public int MyLevel;
	public int NextLevel;

	void Start(){
		GlobalGameManager.control.currentLevel = MyLevel;
	}

	void OnGUI(){
		GUILayout.BeginArea (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Current Level: " + (Application.loadedLevel + 1));
		if(GUILayout.Button ("Load Level: " + (NextLevel + 1))){
			Application.LoadLevel(NextLevel);
		}
		GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
	}
}
