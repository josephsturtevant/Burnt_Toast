using UnityEngine;
using System.Collections;

public class CharacterBehavior : MonoBehaviour {
	public float speed = 10F;
	public float jumpSpeed = 8.0F;
	public float gravity = 30.0F;
	public float zDepthSpeed = 0.75F;
	private float scale = 0.33f;
	public bool canMove = true;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;
	public SceneManagerScript scene;

	void Start()
	{
		controller = this.GetComponent<CharacterController>();
		scene = GameObject.Find ("SceneManager").GetComponent<SceneManagerScript> ();
	}

	void Update() {
		float vertical = Input.GetAxis("LeftAnalogZ");
		if ((vertical < scale) && (-scale < vertical)) {
			vertical = 0f;
		}
		float horizontal = Input.GetAxis("LeftAnalogX");
		if ((horizontal < scale) && (-scale < horizontal)) {
			horizontal = 0f;
		}
		if (controller.isGrounded) {
			moveDirection = new Vector3(horizontal, 0, (vertical * zDepthSpeed));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetButtonDown("X"))
				moveDirection.y = jumpSpeed;
			if (Input.GetButtonDown("B"))
				Debug.Log("Pressed the B Button!");
			if (Input.GetButtonDown("A"))
				Debug.Log("Pressed the A Button!");
			if (Input.GetButtonDown("Y")){
				Debug.Log("Pressed the Y Button!");
				if(scene.inCombat){
					scene.inCombat = false;
					canMove = true;
				} else {
					scene.inCombat = true;
					canMove = false;

				}
			}
			if (Input.GetButtonDown("Start"))
				Debug.Log("Pressed the Start Button!");
			if (Input.GetButtonDown("Select"))
				Debug.Log("Pressed the Back Button!");
		}
		if(canMove){
			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}
	}

	public void stopControls(){

	}
}