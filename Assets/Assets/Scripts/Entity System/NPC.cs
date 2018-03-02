using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity {

	public GameObject weapon;
	public int deathDelay;
	public string dialog;

	// Use this for initialization
	void Start () {
		attack = weapon.GetComponent<Weapon> ().attackDamage;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			Debug.Log ("Should die");
			Destroy (gameObject, deathDelay);
		}
	}
}
