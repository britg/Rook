using UnityEngine;
using System.Collections;

public class Thief : Character {

    public override CharacterAlignment alignment {
        get {
            return CharacterAlignment.Player;
        }
    }

}
