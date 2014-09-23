using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    GameObject _gameObj;
    public GameObject gameObj {
        get {
            if (_gameObj == null) {
                _gameObj = GameObject.Find("Game");
            }
            return _gameObj;
        }
    }

    TurnController _turnController;
    public TurnController turnController {
        get {
            if (_turnController == null) {
                _turnController = gameObj.GetComponent<TurnController>();
            }
            return _turnController;
        }
    }

    GameObject _playerObj;
    public GameObject playerObj {
        get {
            if (_playerObj == null) {
                _playerObj = GameObject.Find("Player");
            }
            return _playerObj;
        }
    }

    PlayerController _playerController;
    public PlayerController playerController {
        get {
            if (_playerController == null) {
                _playerController = playerObj.GetComponent<PlayerController>();
            }
            return _playerController;
        }
    }

    Player _player;
    public Player player {
        get {
            if (_player == null) {
                _player = playerController.player;
            }
            return _player;
        }
    }

    //GFHexGrid _grid;
    //public GFHexGrid grid {
    //    get {
    //        if (_grid == null) {
    //            _grid = GameObject.Find("Hex Grid").GetComponent<GFHexGrid>();
    //        }
    //        return _grid;
    //    }
    //}

    GridController _gridController;
    public GridController gridController {
        get {
            if (_gridController == null) {
                _gridController = GameObject.Find("Grid").GetComponent<GridController>();
            }
            return _gridController;
        }
    }

	GridService _gridService;
	public GridService gridService {
		get {
			if (_gridService == null) {
				_gridService = gridController.gridService;
			}
			return _gridService;
		}
	}

	TileSelectionController _tileSelectionController;
	public TileSelectionController tileSelectionController {
		get {
			if (_tileSelectionController == null) {
				_tileSelectionController = GameObject.Find("Grid").GetComponent<TileSelectionController>();
			}
			return _tileSelectionController;
		}
	}


    public bool PlayerTurn {
        get {
            return turnController.PlayerTurn;
        }
    }

    public bool InCombat {
        get {
            return turnController.InCombat;
        }
    }

    protected void SnapToGrid () {
        //Vector3 nearestGridPos = grid.NearestFaceW(transform.position);
        transform.position = gridService.NearestCellCenter(transform.position);
    }

    protected void EndPlayerTurn () {
        turnController.EndTurn();
    }
}
