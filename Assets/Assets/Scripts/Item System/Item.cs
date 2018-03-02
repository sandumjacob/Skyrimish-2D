using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Item : MonoBehaviour {

	public int itemId;
	public string nameOfItem;
	public Sprite icon = new Sprite();
	public Sprite spriteImageWithItem;
	public string description;


	public string getNameOfItem(){
		return nameOfItem;
	}

	public Sprite getIcon(){
		return icon;
	}
}
