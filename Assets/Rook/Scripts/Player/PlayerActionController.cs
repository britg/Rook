using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerActionController : GameController {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarriorActionButtonPressed () {
		StartAction(player.warriorAction);
    }

	public void WarriorActionButtonPointerEnter () {
		gridService.HighlightAction(player.warriorAction);
	}

	public void WarriorActionButtonPointerExit () {
		gridService.ResetColors();
	}

	public void StartAction (CharacterAction action) {
		if (action.requiresSelection) {
			PromptSelection(action);
		} else {
            action.ValidateTargets(TargetsInRange(action));
			PerformAction(action);
		}
	}

	public void PromptSelection (CharacterAction action) {
		Debug.Log ("Prompting selection for action " + action);
		playerController.EnterMode(PlayerControlMode.GridSelect);
		// prompt the selection and get the callback
	}

    // We assume here the action already has its targets
	public void PerformAction (CharacterAction action) {
		Debug.Log ("Performing action " + action);
		playerController.EnterMode (PlayerControlMode.Wait);

        if (!action.isValid) {
            Debug.Log("Not a valid target!");
            playerController.DefaultMode();
            return;
        }
	}

    List<IReceiveAction> TargetsInRange (CharacterAction action) {
        List<IReceiveAction> targetsInRange = new List<IReceiveAction>();
        // raycast and find targets in range
        List<Vector3> pointsToCheck = gridService.WorldPointsForAction(action);
        return targetsInRange;
    }

}
