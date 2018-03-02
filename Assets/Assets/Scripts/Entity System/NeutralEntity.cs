using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralEntity : NPC {

	public bool aggro;

	private bool isWithinDetectionRange;

	public int detectionRange;

	private GameObject playerGO;

	public string aggroDialog;

	public bool shouldBeDead;
	// Use this for initialization
	void Start () {
		playerGO = GameObject.Find ("Player");
		StartCoroutine (NeutralAttackLoop());
	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			//Debug.Log ("Should die");
			Destroy (gameObject, 5);
			if (gameObject.GetComponent<DialogTrigger> ().isShowingDialog == true) {
				DialogManager.hideDialog ();
			}
			shouldBeDead = true;
		}
		if (aggro == false) {
			if (currentHealth < maxHealth) {
				aggro = true;
			}
		}
		if (shouldBeDead == false){
			if (aggro == true) {
				dialog = aggroDialog;
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
	}

	IEnumerator NeutralAttackLoop(){
		while (aggro) {
			if ((playerGO.transform.position - gameObject.transform.position).sqrMagnitude <= 1*1) {
				Debug.Log ("Neutral Entity Attacking Player with " + attack);
				playerGO.GetComponent<PlayerEntity> ().damagePlayer (attack);
			}
			yield return new WaitForSeconds (attackSpeed);
		}
		yield return null;
	}

}
