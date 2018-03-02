using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item {
		
	int defenseRating;

	public Equipment(int defenseRatingInput){
		defenseRating = defenseRatingInput;
	}
	public Equipment(){
		defenseRating = 0;
	}
}
