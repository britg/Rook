﻿using UnityEngine;
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

    GameObject _playerObj;
    public GameObject playerObj {
        get {
            if (_playerObj == null) {
                _playerObj = GameObject.Find("Player");
            }
            return _playerObj;
        }
    }

    protected void EndTurn () {
        turnController.EndTurn();
    }
}
