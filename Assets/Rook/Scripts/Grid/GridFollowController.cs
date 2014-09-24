using UnityEngine;
using System.Collections;

public class GridFollowController : GameController {

	// Use this for initialization
	void Start () {
        NotificationCenter.AddObserver(this, Notifications.PlayerTurn);
        NotificationCenter.AddObserver(this, Notifications.ActionFinished);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPlayerTurn () {
        AlignToPlayer();
    }

	void OnActionFinished () {
		AlignToPlayer();
	}

    void AlignToPlayer () {
        transform.position = playerObj.transform.position;
		gridService.ResetMap(transform.position);
    }
}
