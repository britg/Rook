using UnityEngine;
using System.Collections;

public class TileSelectionController : GameController {

	public GFHexGrid grid;

	void Update () {
	}

	public void PromptSelection (TileSelection tileSelection) {
		Debug.Log ("Prompting selection of tiles " + tileSelection);

	}

}
