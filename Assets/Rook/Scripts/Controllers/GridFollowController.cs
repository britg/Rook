using UnityEngine;
using System.Collections;

public class GridFollowController : GameController {

    public float lift = 0.1f;

	// Use this for initialization
	void Start () {
		Observe(Notifications.PlayerTurn);
		Observe(Notifications.ActionFinished);
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
        var pos = playerObj.transform.position;
        pos.y = lift;
        transform.position = pos;
		gridService.ResetMap(transform.position);
    }
}
