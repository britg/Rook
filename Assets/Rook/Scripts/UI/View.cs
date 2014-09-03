using UnityEngine;
using System.Collections;

public class View : MonoBehaviour {

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
}
