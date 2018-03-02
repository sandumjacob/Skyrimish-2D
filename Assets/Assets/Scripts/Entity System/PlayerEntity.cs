using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerEntity : Entity  {

	public Inventory inventoryOfPlayer = new Inventory(16);


	private GameObject nothing;
	private GameObject playerGO;

	public void addGems(double amount){
		this.gemCount += amount;
	}

	public double getGemCount(){
		return gemCount;
	}

	public float getEntitySpeed(){
		return this.speed;
	}

	public Inventory getInventoryOfPlayer(){
		return inventoryOfPlayer;
	}

	public void addItemToPlayerInventory(GameObject item){
		inventoryOfPlayer.addToInventory (item);
	}

	void Start(){
		playerGO = GameObject.Find ("Player");
		GameObject Fists = Instantiate (Resources.Load ("Prefabs/Weapons/FistsPrefab")) as GameObject;
		nothing = Instantiate(Resources.Load ("Prefabs/Weapons/NothingPrefab")) as GameObject;
		inventoryOfPlayer.currentlyEquipped = nothing;
		this.addItemToPlayerInventory(Fists);
		Fists.transform.SetParent (GameObject.Find("Inventory").transform);
		nothing.transform.SetParent (GameObject.Find("Inventory").transform);
		//Fists.SetActive (false);
		//nothing.SetActive (false);
	}

	void Update(){
		//For animations I'm gonna need to add a string animation requirement that shows what is equipped
		playerGO.GetComponent<SpriteRenderer> ().sprite = playerGO.GetComponent<PlayerEntity> ().inventoryOfPlayer.currentlyEquipped.GetComponent<Item> ().spriteImageWithItem;
		if (currentHealth <= 0) {
			//Debug.Log ("Player Dead");
		}
	}

	public void damagePlayer(int damage){
		currentHealth -= damage;
	}
}
