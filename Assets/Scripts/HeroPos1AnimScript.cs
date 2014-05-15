using UnityEngine;
using System.Collections;

public class HeroPos1AnimScript : MonoBehaviour {

	private Animator animator;
	private CharacterController controller;
	public bool canGiveInput;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		controller = GameObject.Find("Player").GetComponent<CharacterController>();
		canGiveInput = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
