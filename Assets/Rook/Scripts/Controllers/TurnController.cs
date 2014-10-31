using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnController : GameBehaviour {

	TurnProcessor _turnProcessor;
	TurnProcessor turnProcessor {
		get {
			if (_turnProcessor == null) {
				_turnProcessor = GetComponent<TurnProcessor>();
			}
			return _turnProcessor;
		}
	}

	public void EndTurnButtonPressed () {
		actionQueueController.Add(new EndTurnAction());
	}

	public void ResetButtonPressed () {
		Application.LoadLevel(Application.loadedLevel);
	}


}
