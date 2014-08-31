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

    protected void EndTurn () {
        turnController.EndTurn();
    }
}
