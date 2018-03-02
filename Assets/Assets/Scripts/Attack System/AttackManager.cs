using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {
	
	static private GameObject playerGO;

	static AttackManager(){
		playerGO = GameObject.Find ("Player");
	}

	public static void attackEntity(GameObject entity, int damage){
		Component[] components = entity.GetComponents<NPC> ();
		for (int i = 0; i < components.Length; i++) {
			if (components [i] is EnemyEntity) {
				entity.GetComponent<EnemyEntity> ().currentHealth -= damage;
			}
			if (components [i] is NeutralEntity) {
				entity.GetComponent<NeutralEntity> ().currentHealth -= damage;
			}
		}
		//entity.GetComponent<Entity> ().currentHealth -= damage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
