﻿using UnityEngine;
using System.Collections;

public class Yogurt : HeroChar {

	public int MaxHP = 10;
	public int CurrentHP;
	public int MaxStamina;
	public int CurrentStamina;
	public int AttackModifier;
	public int DefenseModifier;
	public int CombatPosition = 2;

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