using UnityEngine;
using System.Collections;

public class XYZCameraScript : MonoBehaviour {
	
	Transform Player = null;
	private Vector3 moveDirection = Vector3.zero;
	public float cameraDistance = -33.5f;
	public float cameraHeight = 1.5f;
	public float cameraTilt = 20.0f;
	public float speed = 10F;
	public float zDepthSpeed = 0.75F;
	float xPos = 0f;
	CharacterController controller = null;

	private float scale = 0.33f;


	void Start()
	{
		Player = GameObject.Find("Player").GetComponent<Transform>();
		xPos = Player.position.x;
		controller = this.GetComponent<CharacterController> ();
	}

	void Update ()
	{
		float vertical = Input.GetAxis("LeftAnalogZ");
		if ((vertical < scale) && (-scale < vertical)) {
			vertical = 0f;
		}
		float horizontal = Input.GetAxis("LeftAnalogX");
		if ((horizontal < scale) && (-scale < horizontal)) {
			horizontal = 0f;
		}
			moveDirection = new Vector3(horizontal, 0, (vertical * zDepthSpeed));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		controller.Move(moveDirection * Time.deltaTime);
		this.transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y + cameraHeight, Player.transform.position.z + cameraDistance);
	}	
}
