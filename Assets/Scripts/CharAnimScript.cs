using UnityEngine;
using System.Collections;

public class CharAnimScript : MonoBehaviour {

	private float zCardinality = 0.33f;
	private float scale = 0.33f;
	private bool canMove;

	private Animator animator;
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		controller = GameObject.Find("Player").GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		canMove = true;
		bool isMoving = false;
		float vertical = Input.GetAxis("LeftAnalogZ");
		if ((vertical < scale) && (-scale < vertical)) {
			vertical = 0f;
		}
		float horizontal = Input.GetAxis("LeftAnalogX");
		if ((horizontal < scale) && (-scale < horizontal)) {
			horizontal = 0f;
		}
		if ((vertical != 0) || (horizontal != 0)) {
			isMoving = true;
			animator.SetBool("isWalking", true);
		} else {
			isMoving = false;
			animator.SetBool("isWalking", false);
		}
		if (controller.isGrounded) {
			animator.SetBool("isGrounded", true);
		} else {
			animator.SetBool("isGrounded", false);
		}
		if (isMoving) 
		{
			if(vertical <= 0)
			{
				if(horizontal >= zCardinality)
				{
					animator.SetInteger ("Direction", 4);
				}
				else if (horizontal <= -zCardinality)
				{
					animator.SetInteger ("Direction", 0);
				}
				else if ((horizontal < zCardinality) && (horizontal > -zCardinality))
				{
					animator.SetInteger ("Direction", 5);
				}
			}
			else if(vertical > 0)
			{
				if(horizontal >= zCardinality)
				{
					animator.SetInteger ("Direction", 3);
				}
				else if (horizontal <= -zCardinality)
				{
					animator.SetInteger ("Direction", 1);
				}
				else if ((horizontal < zCardinality) && (horizontal > -zCardinality))
				{
					animator.SetInteger ("Direction", 2);
				}
			}
		}
	}

	public void stopMovement(){
		canMove = false;
	}

	public void startMovement(){
		canMove = true;
	}
}
