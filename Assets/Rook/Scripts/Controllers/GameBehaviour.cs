using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public abstract class GameBehaviour : MonoBehaviour {

    GameObject _gameObj;
    public virtual GameObject gameObj {
        get {
            if (_gameObj == null) {
                _gameObj = GameObject.Find("Game");
            }
            return _gameObj;
        }
    }

	TurnService _turnService;
	public virtual TurnService turnService {
		get {
			if (_turnService == null) {
				_turnService = GameObject.Find ("TurnManager").GetComponent<TurnProcessor>().turnService;
			}
			return _turnService;
		}
		set {
			_turnService = value;
		}
	}

    TurnController _turnController;
    public virtual TurnController turnController {
        get {
            if (_turnController == null) {
                _turnController = GameObject.Find("TurnManager").GetComponent<TurnController>();
            }
            return _turnController;
        }
    }

    MapController _mapController;
    public virtual MapController mapController {
        get {
            if (_mapController == null) {
                _mapController = GameObject.Find("MapGenerator").GetComponent<MapController>();
            }
            return _mapController;
        }
    }

	MapService.Map _map;
	public virtual MapService.Map map {
		get {
			if (_map == null) {
				_map = mapController.map;
			}
			return _map;
		}
		set {
			_map = value;
		}
	}

	GameObject _actionQueueObj;
	public virtual GameObject actionQueueObj {
		get {
			if (_actionQueueObj == null) {
				_actionQueueObj = GameObject.Find("ActionQueue");
			}
			return _actionQueueObj;
		}
	}

	ActionQueueController _aqController;
	public virtual ActionQueueController actionQueueController {
		get {
			if (_aqController == null) {
				_aqController = actionQueueObj.GetComponent<ActionQueueController>();
			}
			return _aqController;
		}
	}

	ActionQueue _actionQueue;
	public virtual ActionQueue actionQueue {
		get {
			if (_actionQueue == null) {
				_actionQueue = actionQueueController.actionQueue;
			}
			return _actionQueue;
		}
		set {
			_actionQueue = value;
		}
	}

	CombatService _combatService;
	public virtual CombatService combatService {
		get {
			if (_combatService == null) {
				_combatService = GameObject.Find("CombatManager").GetComponent<CombatController>().combatService;
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
		set {
			_player = value;
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

	GameObject _uiObj;
	public virtual GameObject uiObj {
		get {
			if (_uiObj == null) {
				_uiObj = GameObject.Find ("Canvas");
			}
			return _uiObj;
		}
	}

	MoveView _moveView; 
	public virtual MoveView moveView {
		get {
			if (_moveView == null) {
				_moveView = uiObj.GetComponent<MoveView>();
			}
			return _moveView;
		}
	}

	AgentRegistry _agentRegistry;
	public virtual AgentRegistry agentRegistry {
		get {
			if (_agentRegistry == null) {
				_agentRegistry = GameObject.Find ("AgentRegistry").GetComponent<AgentRegistryProcessor>().agentRegistry;
			}
			return _agentRegistry;
		}
		set {
			_agentRegistry = value;
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

	public virtual IReceiveAction actionReceiver {
		get {
			return null;
		}
	}

    protected virtual void SnapToGrid () {
        //Vector3 nearestGridPos = grid.NearestFaceW(transform.position);
        transform.position = gridService.NearestCellCenter(transform.position);
    }

	protected virtual bool GUIInteraction () {
		return EventSystem.current.IsPointerOverGameObject();
	}

	protected virtual void Post (string notificationName) {
		NotificationCenter.PostNotification(this, notificationName);
	}

	protected virtual void Observe (string notificationName) {
		NotificationCenter.AddObserver(this, notificationName);
	}

}
