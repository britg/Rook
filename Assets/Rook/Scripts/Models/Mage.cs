using UnityEngine;
using System.Collections;

public class Mage : SubCharacter {

	public override Color color {
		get {
			return GameColors.mageCellColor;
		}
		set {
			base.color = value;
		}
	}

}
