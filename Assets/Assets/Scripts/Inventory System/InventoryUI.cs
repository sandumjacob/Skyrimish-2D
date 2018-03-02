using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	public GameObject slots;
	int x = -150;
	int y = 150;

	GameObject playerGO;

	static public bool canClick;

	// Use this for initialization
	void Start () {
		playerGO = GameObject.Find ("Player");
		for (int i = 0; i < 4; i++) {

			for (int k = 0; k < 4; k++) {
				GameObject slot = (GameObject)Instantiate (slots);
				slot.transform.SetParent(this.gameObject.transform);
				slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
				x = x + 100;
				if (k == 3) {
					x = -150;
					y = y - 100;
				}
			}

		}
		GameObject.Find ("Inventory Panel").GetComponent<CanvasGroup> ().alpha = 0f;
		canClick = false;
	}

	public void showInventoryUI(){
		for (int i = 0; i < gameObject.transform.childCount; i++) {
			Inventory inv = playerGO.GetComponent<PlayerEntity> ().getInventoryOfPlayer ();
			List<GameObject> invlist = inv.getTheInventory();
			if (i < invlist.Count) {
				GameObject itm = invlist [i];
				Sprite test = new Sprite ();
				gameObject.transform.GetChild (i).GetChild (0).GetComponent<Image> ().sprite = itm.GetComponent<Item>().getIcon ();
				gameObject.transform.GetChild (i).GetChild (0).GetComponent<ItemWrapper> ().itemItself = itm;
			}
		}
		GameObject.Find ("Inventory Panel").GetComponent<CanvasGroup> ().alpha = 1f;
		canClick = true;
	}

	public void hideInventoryUI(){
		canClick = false;
		GameObject.Find ("Inventory Panel").GetComponent<CanvasGroup> ().alpha = 0f;
	}
		

	// Update is called once per frame
	void Update () {
		
	}
}
