using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
	//This is the Invetory object that is passed through the inventory manager;
	// Use this for initialization
	public List<GameObject> theInventory; //Arraylist filled with GameObjects that contain the Weapon/Equipment script
	public int size;
	public GameObject currentlyEquipped;

	private GameObject nothing;

	public Inventory(){
		theInventory = new List<GameObject>();
	}
		

	public Inventory(int sizeInput){
		theInventory = new List<GameObject>();
		size = sizeInput;
	}

	public List<GameObject> getTheInventory(){
		return theInventory;
	}

	public void addToInventory(GameObject itemToAdd){
		theInventory.Add (itemToAdd);
	}

	public void equipItemInInventory(GameObject itemToEquip){
		currentlyEquipped = itemToEquip;
	}

	public void equipItemInInventory(int index){
		currentlyEquipped = theInventory [index];
	}

	public void logInventory(){
		Debug.Log ("Inventory Size: " + size);
		for (int i = 0; i < theInventory.Count; i++) {
			GameObject go = (GameObject)theInventory [i];
			Item thing = go.GetComponent<Item> ();
			Debug.Log ("Index " + i + ": " + thing.getNameOfItem());
		}
	}

}
