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
        Debug.Log("Aligning to player");
        transform.position = playerObj.transform.position;
    }
}
