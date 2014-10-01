using UnityEngine;
using System.Collections;

public abstract class SubCharacter : Character {

	public Player player;

    public override CharacterAlignment alignment {
        get {
            return CharacterAlignment.Player;
        }
    }

	public override CharacterAttribute actionPoints {
		get {
			return player.actionPoints;
		}
		set {
		}
	}

}
