using UnityEngine;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

	// Use this for initialization
	//sizing and scaling
	private float width, height,minX,minY,lastChange=-1;
	private float changeInterval=.3f;
	public int index, choiceSize;
	public bool shouldCopy=true;

	public GameObject cursor;
	public GameObject popup;



	void Start () {
		Camera mainCamera = Camera.main;
		int scaleX = 5;
		int scaleY = 10;
		index = 0;
		choiceSize = 3;

		width = mainCamera.orthographicSize / scaleX;
		height = mainCamera.orthographicSize / scaleY * mainCamera.aspect;
		minX = transform.position.x - width;
		minY = transform.position.y - height;
		cursor = new GameObject ();
		cursor.AddComponent ("SpriteRenderer");
		SpriteRenderer SR = cursor.GetComponent ("SpriteRenderer")as SpriteRenderer;
		SR.sprite =Resources.Load<Sprite> ("Arrow"); //image;
		//cursor.transform.localScale=new Vector3 (mainCamera.orthographicSize / scaleX/4,		                                     mainCamera.orthographicSize / scaleY * mainCamera.aspect/3, 0);
		cursor.transform.localScale = new Vector3 (width/5, height/5);
		cursor.transform.position = new Vector3 (minX, minY);
		transform.localScale = new Vector3 (width,height, 0);
		this.gameObject.AddComponent ("SpriteRenderer");
		SpriteRenderer SpRen = this.gameObject.GetComponent ("SpriteRenderer")as SpriteRenderer;
		SpRen.sprite = Resources.Load<Sprite> ("Box2");




	}



	void makeChange(float num){
		lastChange = num;
		}
	// Update is called once per frame
	void Update () {
		if (popup==null) {
						if (Input.GetAxis ("LeftAnalogZ") > 0f && Time.realtimeSinceStartup - lastChange > changeInterval) {
								lastChange = Time.realtimeSinceStartup;
								index += 1;
						}
						if (Input.GetAxis ("LeftAnalogZ") < 0f && Time.realtimeSinceStartup - lastChange > changeInterval) {
								lastChange = Time.realtimeSinceStartup;
								index--;
						}
						if (index < 0)
								index = choiceSize - 1;
						if (index >= choiceSize)
								index = 0;
						//index=index%choiceSize;
						cursor.transform.position = new Vector3 (cursor.transform.position.x, minY + index * height, 0);

						if (Input.GetButton ("A") && Time.realtimeSinceStartup - lastChange > changeInterval) {
								lastChange = Time.realtimeSinceStartup;
								Debug.Log ("A Button");
								if(index==2){
								//shouldCopy=false;
									popup = new GameObject ();
									popup.AddComponent ("MenuBehavior");
									popup.transform.position = transform.position + new Vector3 (width*1.5f, height*1.5f, 0);
									MenuBehavior MB=(MenuBehavior)popup.GetComponent("MenuBehavior");
									MB.makeChange(lastChange);

									index=1;
								}
								if(index==1){
									Debug.Log("AHOY!");
					gameObject.AddComponent("GUIText");
					GUIText txt= (GUIText)this.gameObject.GetComponent("GUIText");
					txt.text="Ahoy!";
								}
								if(index==0){

					Destroy(cursor.gameObject);
					Destroy(this.gameObject);
				}
							
						}
				}


	}
}
