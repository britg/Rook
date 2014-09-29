using UnityEngine;
using System.Collections;

[System.Serializable]
public class Enemy : Character {

	public override CharacterAlignment alignment {
		get {
			return CharacterAlignment.Enemy;
		}
	}

}
