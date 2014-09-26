using UnityEngine;
using System.Collections;

public class TileSelectionController : GameController {

	public delegate void SelectionHandler(Vector2 selection);

	SelectionHandler handler;
	Vector2 selectedGridPoint;

	void Update () {
	}

	public void PromptSelectionForAction (CharacterAction action, SelectionHandler _handler) {
		Debug.Log ("Prompting selection of tiles for action" + action);
		handler = _handler;
		Invoke ("MakeSelection", 1f);
	}

	void MakeSelection (Vector2 gridPoint) {

	}

	void MakeSelection () {
		selectedGridPoint = Vector2.zero;
		handler(selectedGridPoint);
	}

}
