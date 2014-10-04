using UnityEngine;
using System.Collections;

public class Warrior : SubCharacter {

    public override void ReceiveAction (GameAction action) {
        Debug.Log("Warrior receiving action " + action);
    }

}
