using UnityEngine;
using System.Collections;

public class BattleAnimMenuScript : MonoBehaviour {

	public Animator animator;
	public SceneManagerScript scene;
	public BattleManager battleManager;
	public string currentState;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		battleManager = GameObject.Find ("BattleManager").GetComponent<BattleManager> ();
		scene = GameObject.Find ("SceneManager").GetComponent<SceneManagerScript> ();
		animator.SetBool ("MenuInUse", false);
		currentState = "NotInUse";
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (currentState);
		if((scene.inCombat) && (battleManager.enemyTurn == false)) {
			if(!animator.GetBool("MenuInUse")) {
				currentState = "Switch";
			} else {
				if(animator.GetCurrentAnimatorStateInfo(0).IsName("SwitchIdle")){
					currentState = "Switch";
				} else if(animator.GetCurrentAnimatorStateInfo(0).IsName("DefendIdle")){
					currentState = "Defend";
				} else if(animator.GetCurrentAnimatorStateInfo(0).IsName("AttackIdle")){
					currentState = "Attack";
				} else if(animator.GetCurrentAnimatorStateInfo(0).IsName("ItemIdle")){
					currentState = "Item";
				} else {
					currentState = "NotInUse";
				}
			}
			animator.SetBool("MenuInUse", true);
			int Direction = 0;
			float inputDir = 0.0f;
			inputDir = Input.GetAxis("LeftAnalogX");
			if (( -0.5f < inputDir) && (inputDir < 0.5f)){
				Direction = 0;
			}
			else if (inputDir < -0.5f){
				Direction = -1;
			} else if (0.5f < inputDir){
				Direction = 1;
			}
			animator.SetInteger("Direction", Direction);
			if(battleManager.enemyTurn){
				animator.SetBool("MenuInUse", false);
			}
		}
	}
}

		