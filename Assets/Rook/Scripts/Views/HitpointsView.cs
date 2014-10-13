using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HitpointsView : CharacterTextView {

    CharacterAttribute hitpoints {
        get {
            return character.hitPoints;
        }
    }


	protected override void Display () {
		textDisplay.text = string.Format("HP: {0}", hitpoints.currentValue);
	}

}
