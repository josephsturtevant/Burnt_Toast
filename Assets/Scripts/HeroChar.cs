using UnityEngine;
using System.Collections;

public class HeroChar : MonoBehaviour {
	
	public bool isKO;
	public bool[] statusEffects = new bool[5];
	public int tempAtkBonus, tempDefBonus;
	
	//Attacks return damage dealt
	public virtual int powerAttack (){return -1;}
	public virtual int regularAttack (){return -1;}
	public virtual void regenResource (bool inBackRow){}
	public virtual void lowerHP(int damage){}
	public virtual bool lowerResource(int cost){return false;}
	public virtual int getCombatPosition(){return -1;}
	public virtual void setCombatPosition(int n){}
	public virtual int getMaxHP(){return -1;}
	protected GameManager charStats;

	void Start () {
		charStats = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}



//		if (Resource - cost < 0)
//			return false;
//		Resource -= cost;
//		return true;
//	}
//	public int getHP(){
//		return HP;
//	}
//	
//	public int getResource(){
//		return Resource;
//	}
//	
//	protected bool lowerResource(int cost){
//		if (Resource - cost < 0)
//			return false;
//		Resource -= cost;
//		return true;
//	}
//	
//	protected void increaseResource(int amt){
//		Resource += amt;
//		if (Resource > 100)
//			Resource = 100;
//	}
//	
//
//	public void increaseHP(int health){
//		HP += health;
//		if (HP <= 0)
//			HP = -1;
//		if (HP > 100)
//			HP = 100;
//	}
}
