using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player {

    public PlayerControlMode controlMode;

	public Attribute hitPoints = new Attribute(seedValue: 100);
	public Attribute actionPoints = new Attribute(seedValue: 5);

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

}
