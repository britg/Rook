using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerActionController : GameBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WarriorActionButtonPressed () {
		QueueWarriorAction();
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
