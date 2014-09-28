using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : Character {

    public override CharacterAlignment alignment {
        get {
            return CharacterAlignment.Player;
        }
    }

    public PlayerControlMode controlMode;

	public Warrior warrior = new Warrior();
	public Thief thief = new Thief();
	public Mage mage = new Mage();

    public CharacterAction warriorAction {
        get {
            return warrior.action;
        }
    }

    public CharacterAction thiefAction {
        get {
            return thief.action;
        }
    }

    public CharacterAction mageAction {
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

    public void EnterMode (PlayerControlMode mode) {
        Debug.Log("Entering mode " + mode);
        controlMode = mode;
    }

	public void AssignAction (CharacterAction action, PlayerCharacterType type) {

	}

	public void AssignWarriorAction (CharacterAction action) {
        warrior.action = action;
        action.character = warrior;
	}

	public void AssignThiefAction (CharacterAction action) {

	}

	public void AssignMageAction (CharacterAction action) {

	}

}
