using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

	public bool retrieveItem;
	public bool retrieveInformation;
	public bool pay;
	public double amountToPay; //For the pay type quest
	public bool assassinate;
	public bool clearOut;
	string description;
	string dialog; //What the character will say to initiate the quest
	GameObject target; 
	//Retrieve Item: The Item gameobject in the gameworld to retrieve. 
	//Retrieve Information: The Entity gameobject to retrieve information from.
	//Assassinate: The Entity gameobject to assassinate.
	//Clear Out: The Dungeon gameobject to clear out.


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
