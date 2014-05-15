using UnityEngine;
using System.Collections;

public class Luke : HeroChar {
	

	public int MaxHP = 15;
	public int CurrentHP;
	public int MaxStamina;
	public int CurrentStamina;
	public int AttackModifier;
	public int DefenseModifier;
	public int CombatPosition = 0;

	
	public override int getCombatPosition(){
		return CombatPosition;
	}

	public override void setCombatPosition(int n){
		CombatPosition = n;
	}

	public override int getMaxHP(){
		return MaxHP;
	}
}


