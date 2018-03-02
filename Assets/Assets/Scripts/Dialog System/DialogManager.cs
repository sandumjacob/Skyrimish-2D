using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	private static string dialogCache; //Idk if this is neccessary...

	private static GameObject dialogPanel;
	private static GameObject dialogUIText;

	private static bool dialogUIIsShowing;

	static DialogManager(){
		dialogPanel = GameObject.Find ("Dialog Panel");
		dialogUIText = GameObject.Find ("Dialog Text");

	}

	public static void startDialog (string dialog){
		dialogCache = dialog;

		//UI
		dialogPanel.GetComponent<CanvasGroup> ().alpha = 1f;
		dialogUIText.GetComponent<Text> ().text = dialogCache;
		dialogUIIsShowing = true;
	}

	public static void removeDialog(){
		dialogCache = "";
		dialogUIText.GetComponent<Text> ().text = "";
	}

	public static void hideDialog(){
		dialogUIIsShowing = false;
		dialogPanel.GetComponent<CanvasGroup> ().alpha = 0f;
	}
}
