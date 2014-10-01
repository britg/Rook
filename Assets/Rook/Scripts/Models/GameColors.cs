using UnityEngine;
using System.Collections;

[System.Serializable]
public class GameColors  {

	public static GameColors instance;
	public static GameColors Instance {
		get {
			if (instance == null) {
				instance = new GameColors();
			}
			return instance;
		}
	}

	public static Color defaultCellColor {
		get {
			return Instance._defaultCellColor;
		}
	}
	public Color _defaultCellColor;

	public static Color cursorCellColor {
		get {
			return Instance._cursorCellColor;
		}
	}
	public Color _cursorCellColor;

	public static Color warriorCellColor {
		get {
			return Instance._warriorCellColor;
		}
	}
	public Color _warriorCellColor;

	public static Color thiefCellColor {
		get {
			return Instance._thiefCellColor;
		}
	}
	public Color _thiefCellColor;

	public static Color mageCellColor {
		get {
			return Instance._mageCellColor;
		}
	}
	public Color _mageCellColor;

	public Color _moveLineColor;
	public static Color moveLineColor {
		get {
			return Instance._moveLineColor;
		}
	}

	public float _moveLineThickness;
	public static float moveLineThickness {
		get {
			return Instance._moveLineThickness;
		}
	}
}
