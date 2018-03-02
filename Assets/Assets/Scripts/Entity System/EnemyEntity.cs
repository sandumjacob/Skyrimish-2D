using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : NPC {

	public int detectionRange;

	public bool isWithinDetectionRange;

	GameObject playerGO;

	public bool isRunningAttackLoop = true;


	public bool shouldBeDead = false;
	// Use this for initialization
	void Start () {
		playerGO = GameObject.Find ("Player");
		StartCoroutine (EnemyAttackLoop());
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			//Debug.Log ("Should die");
			if (gameObject.GetComponent<DialogTrigger> ().isShowingDialog == true) {
				DialogManager.hideDialog ();
			}
			shouldBeDead = true;
			isRunningAttackLoop = false;
			Destroy (gameObject, deathDelay);
		}
		if (shouldBeDead == false) {
			if ((playerGO.transform.position - gameObject.transform.position).sqrMagnitude <= detectionRange * detectionRange) {
				isWithinDetectionRange = true;
			}
			if (isWithinDetectionRange == true) {
				if ((playerGO.transform.position - gameObject.transform.position).sqrMagnitude > detectionRange * detectionRange) {
					isWithinDetectionRange = false;
				}
			}
			Vector3 playerPosition = playerGO.transform.position;
			if (isWithinDetectionRange == true) {
				transform.position = Vector3.MoveTowards (transform.position, playerPosition, speed * Time.deltaTime);
			}
			if (isWithinDetectionRange == false) {
				Vector3 vec3 = new Vector3 (UnityEngine.Mathf.Round (transform.position.x), UnityEngine.Mathf.Round (transform.position.y), 0);
				transform.position = Vector3.MoveTowards (transform.position, vec3, speed * Time.deltaTime);
			}
		}

	}
	

	IEnumerator EnemyAttackLoop(){
		while (isRunningAttackLoop){
			if ((playerGO.transform.position - gameObject.transform.position).sqrMagnitude <= 1*1) {
				Debug.Log ("Enemy Entity Attacking Player with " + attack);
				playerGO.GetComponent<PlayerEntity> ().damagePlayer (attack);
			}
			yield return new WaitForSeconds (attackSpeed);
		}
		yield return null;
	}


}
