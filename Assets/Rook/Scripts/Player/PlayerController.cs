using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gamelogic.Grids;

public class PlayerController : MonoBehaviour {

    public Player player;

    public bool isMoving {
        get {
            return player.isMoving;
        }
    }

    void Start () {
		NotificationCenter.AddObserver(this, Notifications.PlayerTurn);

		PlayerAction warriorAction = new PlayerAction();
		warriorAction.gridPoints = new List<FlatHexPoint>{ new FlatHexPoint(0, 1),
														   new FlatHexPoint(0, 2),
														   new FlatHexPoint(0, 3) };
		player.warriorAction = warriorAction;

		Debug.Log ("game colors " + GameColors.defaultCellColor);

    }

	public void EnterMode (PlayerControlMode mode) {
		player.EnterMode(mode);
		NotificationCenter.PostNotification(this, Notifications.EnterControlMode);
	}

	public void DefaultMode () {
		EnterMode(PlayerControlMode.Move);
	}

	void OnPlayerTurn () {
		DefaultMode();
		RefillActionPoints();
	}

	void RefillActionPoints () {
		player.actionPoints.currentValue = player.actionPoints.maxValue;
	}
}
