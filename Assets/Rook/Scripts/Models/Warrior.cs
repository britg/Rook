using UnityEngine;
using System.Collections;

public class Warrior : SubCharacter {

	public Warrior (GameObject _go) : base(_go) {

	}

	public override Color color {
		get {
			return GameColors.warriorCellColor;
		}
	}

}
