using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

	private GameObject nothing;

	// Use this for initialization
	void Start () {
		nothing = GameObject.Find ("NothingPrefab(Clone)");
	}

	public void onButton(){
		if (InventoryUI.canClick == true) {
			if ((GameObject.Find ("Player").GetComponent<PlayerEntity> ().inventoryOfPlayer.currentlyEquipped == nothing) || (GameObject.Find ("Player").GetComponent<PlayerEntity> ().inventoryOfPlayer.currentlyEquipped != gameObject.transform.GetChild (0).GetComponent<ItemWrapper> ().itemItself)) {
				if (gameObject.transform.GetChild (0).GetComponent<ItemWrapper> ().itemItself != null) {
					GameObject.Find ("Player").GetComponent<PlayerEntity> ().inventoryOfPlayer.equipItemInInventory (gameObject.transform.GetChild (0).GetComponent<ItemWrapper> ().itemItself);
					Debug.Log ("Equip");
				}
			} else if (GameObject.Find ("Player").GetComponent<PlayerEntity> ().inventoryOfPlayer.currentlyEquipped == gameObject.transform.GetChild (0).GetComponent<ItemWrapper> ().itemItself) {
				GameObject.Find ("Player").GetComponent<PlayerEntity> ().inventoryOfPlayer.currentlyEquipped = nothing;
				Debug.Log ("Dequip");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
