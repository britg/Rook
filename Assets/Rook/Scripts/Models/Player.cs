using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : Character {

    public override CharacterAlignment alignment {
        get {
            return CharacterAlignment.Player;
        }
    }

	public Warrior warrior = new Warrior();
	public Thief thief = new Thief();
	public Mage mage = new Mage();

    public GameAction warriorAction {
        get {
            return warrior.action;
        }
    }

    public GameAction thiefAction {
        get {
            return thief.action;
        }
    }

    public GameAction mageAction {
        get {
            return mage.action;
        }
    }

    public bool isRotating {
        get {
            return controlMode == PlayerControlMode.Rotate;
        }
    }

    public bool isMoving {
        get {
            return controlMode == PlayerControlMode.Move;
        }
    }

	public bool canStartAction {
		get {
			return controlMode == PlayerControlMode.Move;
		}
	}

	public Player (GameObject _go) : base(_go) {
	}


	public void Init () {
		isPlayer = true;
		warrior.player = this;
		thief.player = this;
		mage.player = this;
	}

	public void AssignWarriorAction (GameAction action) {
        warrior.action = action;
	}

	public void AssignThiefAction (GameAction action) {

	}

	public void AssignMageAction (GameAction action) {

	}

}
