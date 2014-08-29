using UnityEngine;
using System.Collections;

public class FollowPlayerController : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void LateUpdate () {
        FollowPlayer();
    }

    void FollowPlayer () {
        Vector3 playerPos = player.position;
        playerPos.y = transform.position.y;
        transform.position = playerPos;
    }
}
