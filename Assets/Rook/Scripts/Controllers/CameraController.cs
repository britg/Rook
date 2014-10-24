using UnityEngine;
using System.Collections;
using Vectrosity;

public class CameraController : GameBehaviour  {

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LateUpdate () {
		FollowPlayer();
	}
	
	void FollowPlayer () {
		Vector3 playerPos = playerObj.transform.position;
		playerPos.y = transform.position.y;
		transform.position = playerPos;
	}
}
