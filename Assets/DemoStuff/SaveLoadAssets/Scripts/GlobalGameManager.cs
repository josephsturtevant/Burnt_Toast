using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class GlobalGameManager : MonoBehaviour {
	public static GlobalGameManager control;

	public float Health;
	public float Experience;
	public float Score;
	public int currentLevel;

	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		}
	}
	void Start(){
		GameObject go = GameObject.Find ("Main Camera");
		currentLevel = go.GetComponent<LoadLevelOnMouse> ().MyLevel;
	}
	void OnGUI(){
		GUILayout.BeginArea (new Rect (10, 10, 200, 200));
		GUILayout.FlexibleSpace ();
		GUILayout.Label ("Health: " + Health);
		GUILayout.Label ("Experience: " + Experience);
		GUILayout.Label ("Score: " + Score);
		GUILayout.FlexibleSpace ();
		GUILayout.EndArea ();
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.Experience = Experience;
		data.Health = Health;
		data.Score = Score;
		data.currentLevel = currentLevel;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData) bf.Deserialize(file);
			file.Close();

			Health = data.Health;
			Experience = data.Experience;
			Score = data.Score;
			currentLevel = data.currentLevel;

			Application.LoadLevel(currentLevel);
		}
	}
}


// this is a container class
[Serializable]
class PlayerData{
	public float Health;
	public float Experience;
	public float Score;
	public int currentLevel;
}