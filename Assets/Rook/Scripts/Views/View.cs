using UnityEngine;
using System.Collections;

public class View : GameController {

    GameObject _canvasObj;
    protected virtual GameObject canvasObj {
        get {
            if (_canvasObj == null) {
                _canvasObj = GameObject.Find("Canvas");
            }
            return _canvasObj;
        }
    }
}
