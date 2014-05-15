using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private const int REG_DMG = 35;
	private int HP = 600;
	private float patrolSpeed = 2f;
	private Vector3 patrolDirection;
	void Start () {
		patrolDirection = new Vector3 (0f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!CombatManager.inCombat) {
			if (transform.position.y < -10f)
					patrolSpeed *= -1;
			else if (transform.position.y > 10f)
					patrolSpeed *= -1;
			transform.position += patrolDirection * patrolSpeed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
			CombatManager.StartCombat(other.gameObject, this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Hit!");
		if (other.gameObject.tag == "Player")
			CombatManager.StartCombat(other.gameObject, this.gameObject);
	}

	public int regularAttack(){
		return REG_DMG;
	}

	public int getHP(){
		return HP;
	}

	public void lowerHP(int damage){
		HP -= damage;
	}
}
