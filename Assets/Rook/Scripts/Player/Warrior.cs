using UnityEngine;
using System.Collections;

public class Warrior : Character {

    public override CharacterAlignment alignment {
        get {
            return CharacterAlignment.Player;
        }
    }
}
