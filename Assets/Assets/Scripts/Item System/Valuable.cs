using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuable : MonoBehaviour {

	public double value;
	public Sprite icon = new Sprite();
	public string description;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Sprite getIcon(){
		return icon;
	}

	public double getValue(){
		return value;
	}
}
