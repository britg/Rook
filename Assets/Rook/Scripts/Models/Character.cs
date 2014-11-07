using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Character : Agent {

	public PlayerControlMode controlMode;

	public virtual bool isPlayer { get; set; }

	public virtual bool inCombat { get; set; }
    public virtual Character combatTarget { get; set; }


    GameAction _action;
	public virtual GameAction action {
        get {
            return _action;
        }
        set {
            _action = value;
            _action.agent = (Agent)this;
        }
    }

	public Character (GameObject _go) : base(_go) {
		isPlayer = false;
	}

	public void EnterMode (PlayerControlMode mode) {
		Debug.Log("Entering mode " + mode + " with game object " + go);
		controlMode = mode;
	}

}
