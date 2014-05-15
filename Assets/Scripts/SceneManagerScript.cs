using UnityEngine;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {

	public bool inCombat = false;
	private static Camera BattleCamera, Player_Camera;
	public static Camera[] otherCameras;
	private GameObject Player;
	public GameManager manager;
	private AudioSource houseMusic, battleMusic;

	// Use this for initialization
	void Start () {
		BattleCamera = GameObject.Find("BattleCamera").GetComponent<Camera> ();
		Player_Camera = GameObject.Find("Player_Camera").GetComponent<Camera> ();
		//Player = GameObject.Find("Player").GetComponent<Camera> ();
		houseMusic = GameObject.Find ("HouseMusic").GetComponent<AudioSource> ();
		battleMusic = GameObject.Find ("BattleMusic").GetComponent<AudioSource> ();
		BattleCamera.gameObject.SetActive (false);
		//manager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(inCombat){
			Player_Camera.gameObject.SetActive(false);
			BattleCamera.gameObject.SetActive(true);
			if(!battleMusic.isPlaying){
				houseMusic.Stop();
				battleMusic.Play();
			}
		} else {
			BattleCamera.gameObject.SetActive(false);
			Player_Camera.gameObject.SetActive(true);
			if(!houseMusic.isPlaying){
				battleMusic.Stop();
				houseMusic.Play();
			}
		}
	}
}
