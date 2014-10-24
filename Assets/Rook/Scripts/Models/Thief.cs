using UnityEngine;
using System.Collections;

public class Thief : SubCharacter {

	public Thief (GameObject _go) : base(_go) {
		
	}

	public override Color color {
		get {
			return GameColors.thiefCellColor;
		}
	}

}
