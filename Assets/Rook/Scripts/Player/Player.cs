using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player {

    public PlayerControlMode controlMode;

	public CharacterAttribute hitPoints = new CharacterAttribute(seedValue: 100);
	public CharacterAttribute actionPoints = new CharacterAttribute(seedValue: 5);

	public PlayerAction warriorAction;
	public PlayerAction thiefAction;
	public PlayerAction mageAction;

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

	public void AssignAction (PlayerAction action, PlayerCharacterType type) {

	}

	public void AssignWarriorAction (PlayerAction action) {
		warriorAction = action;
		warriorAction.playerCharacterType = PlayerCharacterType.Warrior;
	}

	public void AssignThiefAction (PlayerAction action) {

	}

	public void AssignMageAction (PlayerAction action) {

	}

}
