using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerActionController : GameController {

	CharacterAction currentAction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarriorActionButtonPressed () {
		QueueWarriorAction();
//		currentAction = player.warriorAction;
//		Invoke ("StartAction", 0.1f);
    }

	void QueueWarriorAction () {
		actionQueueController.Add(player.warriorAction);
	}

	public void WarriorActionButtonPointerEnter () {
		gridService.HighlightAction(player.warriorAction);
	}

	public void WarriorActionButtonPointerExit () {
		gridService.ResetColors();
	}

}
