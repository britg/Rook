using UnityEngine;
using System.Collections;

public class Mage : SubCharacter {

	public Mage (GameObject _go) : base(_go) {

	}

	public override Color color {
		get {
			return GameColors.mageCellColor;
		}
		set {
			base.color = value;
		}
	}

}
