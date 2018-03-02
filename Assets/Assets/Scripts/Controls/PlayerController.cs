using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float playerMoveSpeed;
	private Rigidbody2D rb2d;

	private bool moveToPoint = false;
	private Vector3 endPosition;
	private float distanceToMove = 1;

	private bool invUIOpen = false;

	private Animator anim;
	private bool isMoving = false;

	private bool isMobile;

	GameObject[] entities;
	// Use this for initialization
	void Start () {
		//float y = GameObject.Find ("Control Pad").transform.position.x;
		//y += 50;
		//GameObject.Find ("Control Pad").transform.position.Set (GameObject.Find ("Control Pad").transform.position.x, y, 0);
		PlayerEntity playerEntity = gameObject.GetComponent<PlayerEntity> ();
		playerMoveSpeed = playerEntity.getEntitySpeed();
		rb2d = GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		endPosition = transform.position;
		anim.SetBool ("isIdle", true);
		if (Application.isMobilePlatform) {
			isMobile = true;
			MobileControls.showMobileControls (GameObject.Find ("Mobile Controls"));
		}
		MobileControls.showMobileControls (GameObject.Find ("Mobile Controls"));
	}

	//Mobile Control Methods
	public void onRightButtonClick(){
		if (MobileControls.canClickPad == true) {
			endPosition = new Vector3 (endPosition.x + distanceToMove, endPosition.y, endPosition.z);
			moveToPoint = true;
			anim.SetBool ("isRight", true);

			anim.SetBool ("isLeft", false);
			anim.SetBool ("isNorth", false);
			anim.SetBool ("isSouth", false);
		}
	}

	public void onLeftButtonClick(){
		if (MobileControls.canClickPad == true) {
			endPosition = new Vector3 (endPosition.x - distanceToMove, endPosition.y, endPosition.z);
			moveToPoint = true;
			anim.SetBool ("isLeft", true);

			//turn off others
			anim.SetBool ("isRight", false);
			anim.SetBool ("isNorth", false);
			anim.SetBool ("isSouth", false);
		}
	}

	public void onUpButtonClick(){
		if (MobileControls.canClickPad == true) {
			endPosition = new Vector3 (endPosition.x, endPosition.y + distanceToMove, endPosition.z);
			moveToPoint = true;
			anim.SetBool ("isNorth", true);

			anim.SetBool ("isLeft", false);
			anim.SetBool ("isRight", false);
			anim.SetBool ("isSouth", false);
		}
	}

	public void onDownButtonClick(){
		if (MobileControls.canClickPad == true) {
			endPosition = new Vector3 (endPosition.x, endPosition.y - distanceToMove, endPosition.z);
			moveToPoint = true;
			anim.SetBool ("isSouth", true);

			anim.SetBool ("isLeft", false);
			anim.SetBool ("isRight", false);
			anim.SetBool ("isNorth", false);
		}
	}

	public void onInventoryButtonClick(){
		if (invUIOpen == false) {
			GameObject.Find ("Canvas").transform.GetChild (2).GetComponent<InventoryUI>().showInventoryUI();
			invUIOpen = true;
			MobileControls.hideMobileControls(GameObject.Find ("Mobile Controls"));
		} else if (invUIOpen == true) {
			GameObject.Find ("Canvas").transform.GetChild (2).GetComponent<InventoryUI>().hideInventoryUI();
			invUIOpen = false;
			MobileControls.showMobileControls(GameObject.Find ("Mobile Controls"));
		}
	}

	public void onAttackButtonClick(){
		foreach (GameObject go in entities) {
			if (anim.GetBool ("isRight")) {
				float dif = go.transform.position.x - transform.position.x;
				if (0<dif && dif<=1) { 
					Debug.Log("To Right");
					AttackManager.attackEntity (go, gameObject.GetComponent<PlayerEntity> ().attack);
				}
			}
			else if (anim.GetBool ("isLeft")) {
				float dif = go.transform.position.x - transform.position.x;
				if (0>dif && dif>=-1) {
					Debug.Log("To Left");
					AttackManager.attackEntity (go, gameObject.GetComponent<PlayerEntity> ().attack);
				}
			}
			else if (anim.GetBool ("isNorth")) {
				//Attack North
				float dif = go.transform.position.y - transform.position.y;
				if (0<dif && dif<=1) {
					Debug.Log("To North");
					AttackManager.attackEntity (go, gameObject.GetComponent<PlayerEntity> ().attack);
				}
			}
			else if (anim.GetBool ("isSouth")) {
				//Attack South
				float dif = go.transform.position.y - transform.position.y;
				if (0>dif && dif>=-1) {
					Debug.Log("To South");
					AttackManager.attackEntity (go, gameObject.GetComponent<PlayerEntity> ().attack);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
		entities = GameObject.FindGameObjectsWithTag("Entity");
		if (Input.GetKeyDown(KeyCode.A)) //Left
		{
			endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
			moveToPoint = true;
			anim.SetBool ("isLeft", true);

			//turn off others
			anim.SetBool ("isRight", false);
			anim.SetBool ("isNorth", false);
			anim.SetBool ("isSouth", false);
		}

		if (Input.GetKeyDown(KeyCode.D)) //Right
		{
			endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
			moveToPoint = true;
			anim.SetBool ("isRight", true);

			anim.SetBool ("isLeft", false);
			anim.SetBool ("isNorth", false);
			anim.SetBool ("isSouth", false);
		}

		if (Input.GetKeyDown(KeyCode.W)) //Up
		{
			endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
			moveToPoint = true;
			anim.SetBool ("isNorth", true);

			anim.SetBool ("isLeft", false);
			anim.SetBool ("isRight", false);
			anim.SetBool ("isSouth", false);
		}

		if (Input.GetKeyDown(KeyCode.S)) //Down
		{
			endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
			moveToPoint = true;
			anim.SetBool ("isSouth", true);

			anim.SetBool ("isLeft", false);
			anim.SetBool ("isRight", false);
			anim.SetBool ("isNorth", false);

		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			//Attack...
			//TODO: Add attack speed delay
			foreach (GameObject go in entities) {
				if (anim.GetBool ("isRight")) {
					float dif = go.transform.position.x - transform.position.x;
					if (0<dif && dif<=1) { 
						Debug.Log("To Right");
						AttackManager.attackEntity (go, gameObject.GetComponent<PlayerEntity> ().attack);
					}
				}
				else if (anim.GetBool ("isLeft")) {
					float dif = go.transform.position.x - transform.position.x;
					if (0>dif && dif>=-1) {
						Debug.Log("To Left");
						AttackManager.attackEntity (go, gameObject.GetComponent<PlayerEntity> ().attack);
					}
				}
				else if (anim.GetBool ("isNorth")) {
					//Attack North
					float dif = go.transform.position.y - transform.position.y;
					if (0<dif && dif<=1) {
						Debug.Log("To North");
						AttackManager.attackEntity (go, gameObject.GetComponent<PlayerEntity> ().attack);
					}
				}
				else if (anim.GetBool ("isSouth")) {
					//Attack South
					float dif = go.transform.position.y - transform.position.y;
					if (0>dif && dif>=-1) {
						Debug.Log("To South");
						AttackManager.attackEntity (go, gameObject.GetComponent<PlayerEntity> ().attack);
					}
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.I)) { //Inventory Open
			if (invUIOpen == false) {
				GameObject.Find ("Canvas").transform.GetChild (2).GetComponent<InventoryUI>().showInventoryUI();
				invUIOpen = true;
			} else if (invUIOpen == true) {
				GameObject.Find ("Canvas").transform.GetChild (2).GetComponent<InventoryUI>().hideInventoryUI();
				invUIOpen = false;
			}
		}


		foreach (GameObject go in entities) {
			if (go.transform.position == endPosition) {
				Debug.Log ("Blah");
				moveToPoint = false;
				endPosition = transform.position;
			}
		}
	}

	void FixedUpdate(){
		/*//Gets the horizontal input value (-1 to 1)
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");

		//Gets the vertical input value (-1 to 1)
		float moveVertical = Input.GetAxisRaw("Vertical");

		//Using the two input values, create a Vector2 variable movement
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		//Apply the movement vector to the rigid body (multiplied by the speed factor)
		rb2d.velocity = movement * playerMoveSpeed;*/

		/*if (transform.position.x != UnityEngine.Mathf.Round (transform.position.x)) {
			
		}*/
		if (moveToPoint)
		{
			isMoving = true;
			anim.SetBool ("isMoving", isMoving);
			anim.SetBool ("isIdle", !isMoving);
			anim.SetBool ("isMoving", moveToPoint);
			Vector3 vec3 = new Vector3(UnityEngine.Mathf.Round (endPosition.x), UnityEngine.Mathf.Round (endPosition.y), 0);
			endPosition = vec3;
			transform.position = Vector3.MoveTowards(transform.position, endPosition, playerMoveSpeed * Time.deltaTime);
			if (transform.position == endPosition) {
				isMoving = false;
				anim.SetBool ("isIdle", !isMoving);
				anim.SetBool ("isMoving", isMoving);
				//anim.SetBool ("isRight", isMoving);
				//anim.SetBool ("isLeft", isMoving);
				//anim.SetBool ("isNorth", isMoving);
				//anim.SetBool ("isSouth", isMoving);
			}
		}
	}
}
