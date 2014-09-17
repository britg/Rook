using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player {

    public PlayerControlMode controlMode;

	public Attribute hitPoints = new Attribute(seedValue: 100);
	public Attribute actionPoints = new Attribute(seedValue: 5);

	public Action warriorAction;
	public Action thiefAction;
	public Action mageAction;

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

	public bool warriorActionActive {
		get {
			return controlMode == PlayerControlMode.WarriorAction;
		}
	}

    public void EnterMode (PlayerControlMode mode) {
        Debug.Log("Entering mode " + mode);
        controlMode = mode;
    }

}
