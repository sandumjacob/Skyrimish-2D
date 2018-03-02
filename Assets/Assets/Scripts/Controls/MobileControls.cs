using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour {

	public static bool canClickPad;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void showMobileControls(GameObject go){
		go.transform.GetChild (0).GetComponent<CanvasGroup> ().alpha = 1f;
		go.transform.GetChild (1).GetComponent<CanvasGroup> ().alpha = 1f;
		canClickPad = true;
	}
		

	public static void hideMobileControls(GameObject go){
		go.transform.GetChild (0).GetComponent<CanvasGroup> ().alpha = 0f;
		go.transform.GetChild (1).GetComponent<CanvasGroup> ().alpha = 0f;
		canClickPad = false;
	}
}
