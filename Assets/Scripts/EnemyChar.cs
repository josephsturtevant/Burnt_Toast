using UnityEngine;
using System.Collections;

public class EnemyChar : MonoBehaviour {

	public int currentHP, maxHP;
	public bool isKO;
	public bool[] statusEffects = new bool[5];
	public int tempAtkBonus, tempDefBonus;
	private const int REG_DMG = 35;
	private int HP = 600;


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
