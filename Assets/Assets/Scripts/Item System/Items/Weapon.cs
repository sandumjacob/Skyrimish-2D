using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Weapon : Item {
	public int attackDamage;

	public Weapon(int attackDamageInput){
		attackDamage = attackDamageInput;
	}
	public Weapon(){
		attackDamage = 0;
	}
}
