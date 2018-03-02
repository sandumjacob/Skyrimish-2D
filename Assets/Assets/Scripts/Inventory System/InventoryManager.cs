using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	GameObject playerGO;
	GameObject invGO;
	GameObject gemCounterText;
	GameObject healthCounterText;

	// Use this for initialization
	void Start () {
		playerGO = gameObject;
		invGO = GameObject.Find ("Inventory");
		gemCounterText = GameObject.Find ("Gem Counter");
		healthCounterText = GameObject.Find ("Health Counter");
	}
	
	// Update is called once per frame
	void Update () {
		gemCounterText.GetComponent<Text> ().text = "Gems: " + playerGO.GetComponent<PlayerEntity> ().getGemCount ();
		float frac = (float)playerGO.GetComponent<PlayerEntity> ().currentHealth / (float)playerGO.GetComponent<PlayerEntity> ().maxHealth;
		healthCounterText.GetComponent<Text> ().text = "Health: " + Mathf.Round(frac * 100) + "%";

		playerGO.GetComponent<PlayerEntity> ().attack = playerGO.GetComponent<PlayerEntity> ().inventoryOfPlayer.currentlyEquipped.GetComponent<Weapon>().attackDamage;
	}

	void OnTriggerEnter2D (Collider2D other){
		Debug.Log ("Collision Detected");
		if (other.gameObject.tag == "Item") {
			Debug.Log ("Player Collided with Item");
			playerGO.GetComponent<PlayerEntity>().addItemToPlayerInventory(other.gameObject);
			//Destroy (other.gameObject);
			other.gameObject.transform.SetParent(invGO.transform);
			other.gameObject.SetActive(false);
		}
		if (other.gameObject.tag == "Valuable") {
			Debug.Log ("Player Collided with Valuable");
			double val = other.gameObject.GetComponent<Valuable> ().getValue ();
			playerGO.GetComponent<PlayerEntity> ().addGems (val);
			Destroy (other.gameObject);
		}
	}


}
