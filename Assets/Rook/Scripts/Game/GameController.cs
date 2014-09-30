using UnityEngine;
using System.Collections;

public abstract class GameController : MonoBehaviour {

    GameObject _gameObj;
    public virtual GameObject gameObj {
        get {
            if (_gameObj == null) {
                _gameObj = GameObject.Find("Game");
            }
            return _gameObj;
        }
    }

    TurnController _turnController;
    public virtual TurnController turnController {
        get {
            if (_turnController == null) {
                _turnController = gameObj.GetComponent<TurnController>();
            }
            return _turnController;
        }
    }

	CombatService _combatService;
	public virtual CombatService combatService {
		get {
			if (_combatService == null) {
				_combatService = turnController.combatService;
			}
			return _combatService;
		}
	}

    GameObject _playerObj;
    public virtual GameObject playerObj {
        get {
            if (_playerObj == null) {
                _playerObj = GameObject.Find("Player");
            }
            return _playerObj;
        }
    }

    PlayerController _playerController;
    public virtual PlayerController playerController {
        get {
            if (_playerController == null) {
                _playerController = playerObj.GetComponent<PlayerController>();
            }
            return _playerController;
        }
    }

    Player _player;
    public virtual Player player {
        get {
            if (_player == null) {
                _player = playerController.player;
            }
            return _player;
        }
    }

    GridController _gridController;
    public virtual GridController gridController {
        get {
            if (_gridController == null) {
                _gridController = GameObject.Find("Grid").GetComponent<GridController>();
            }
            return _gridController;
        }
    }

	GridService _gridService;
	public virtual GridService gridService {
		get {
			if (_gridService == null) {
				_gridService = gridController.gridService;
			}
			return _gridService;
		}
	}

	TileSelectionController _tileSelectionController;
	public virtual TileSelectionController tileSelectionController {
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
            return combatService.InCombat;
        }
    }

    protected virtual void SnapToGrid () {
        //Vector3 nearestGridPos = grid.NearestFaceW(transform.position);
        transform.position = gridService.NearestCellCenter(transform.position);
    }

    protected virtual void EndPlayerTurn () {
        turnController.EndTurn();
    }
}
