using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : Character {

    public PlayerControlMode controlMode;

	public Warrior warrior;
	public Thief thief;
	public Mage mage;

	public CharacterAction warriorAction;
	public CharacterAction thiefAction;
	public CharacterAction mageAction;

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

	public void ResetActionPoints () {
		actionPoints.SetToMax();
	}

	public void AssignAction (CharacterAction action, PlayerCharacterType type) {

	}

	public void AssignWarriorAction (CharacterAction action) {
		warriorAction = action;
		warriorAction.playerCharacterType = PlayerCharacterType.Warrior;
	}

	public void AssignThiefAction (CharacterAction action) {

	}

	public void AssignMageAction (CharacterAction action) {

	}

}
