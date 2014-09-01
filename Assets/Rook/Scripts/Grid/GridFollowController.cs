using UnityEngine;
using System.Collections;

public class GridFollowController : GameController {

	// Use this for initialization
	void Start () {
        NotificationCenter.AddObserver(this, Notifications.PlayerTurn);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPlayerTurn () {
        AlignToPlayer();
    }

    void AlignToPlayer () {
        transform.position = playerObj.transform.position;
    }
}
