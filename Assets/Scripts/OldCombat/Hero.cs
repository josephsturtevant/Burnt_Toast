using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	private float kHeroSpeed = 10f;
	private float kHeroRotateSpeed = 90/2f; // 90-degrees in 2 seconds
	protected int HP = 100;
	protected int Resource = 100;
	//Attacks return damage dealt
	public virtual int powerAttack (){return -1;}
	public virtual int regularAttack (){return -1;}
	public virtual void regenResource (bool inGuard){}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!CombatManager.inCombat)
			Move ();
	}

	void Move(){
		transform.position += Input.GetAxis ("Vertical")  * transform.up * (kHeroSpeed * Time.smoothDeltaTime);
		transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (kHeroRotateSpeed * Time.smoothDeltaTime));
	}

	public int getHP(){
		return HP;
	}

	public int getResource(){
		return Resource;
	}

	protected bool lowerResource(int cost){
		if (Resource - cost < 0)
			return false;
		Resource -= cost;
		return true;
	}

	protected void increaseResource(int amt){
		Resource += amt;
		if (Resource > 100)
			Resource = 100;
	}

	public void lowerHP(int damage){
		HP -= damage;
		if (HP <= 0)
			HP = -1;
		if (HP > 100)
			HP = 100;
	}

	public void increaseHP(int health){
		HP += health;
		if (HP <= 0)
			HP = -1;
		if (HP > 100)
			HP = 100;
	}

}
