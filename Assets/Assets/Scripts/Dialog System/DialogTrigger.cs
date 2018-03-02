using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

	//public Dialog dialog;
	private string dialogCache;
	private GameObject playerGO;


	public bool proximity; //Dialog triggered by proximity
	public int proximityDistance; //Radius of activation by proximity
	private bool isEntered;
	public bool isShowingDialog;

	public bool activation; //Dialog triggered by action button

	public bool onDeath; //Dialog triggered by the entity dying

	// Use this for initialization
	void Start () {
		playerGO = GameObject.Find ("Player");
		Component[] components = gameObject.GetComponents<NPC> ();
		for (int i = 0; i < components.Length; i++) {
			if (components [i] is EnemyEntity) {
				dialogCache = gameObject.name + ": " + gameObject.GetComponent<EnemyEntity> ().dialog;
			}
			if (components [i] is NeutralEntity) {
				dialogCache = gameObject.name + ": " + gameObject.GetComponent<NeutralEntity> ().dialog;
			}
		}

	}
		

	// Update is called once per frame
	void Update () {
		if (proximity == true) {
			if ((playerGO.transform.position - gameObject.transform.position).sqrMagnitude <= proximityDistance * proximityDistance) {
				DialogManager.startDialog (this.dialogCache);
				isEntered = true;
				isShowingDialog = true;
			}
			if (isEntered == true) {
				if ((playerGO.transform.position - gameObject.transform.position).sqrMagnitude > proximityDistance * proximityDistance) {
					DialogManager.hideDialog ();
					isEntered = false;
					isShowingDialog = false;
				}
			}
		} else if (onDeath == true) {
			
		}
	}
}