using UnityEngine;
using System.Collections;

public class PlayerMoveController : MonoBehaviour {

	void Start () {
	    
	}
	
	void Update () {
	    
	}

    public void UpdateMoveDestination (Vector3 pos) {
        Debug.Log("Move to " + pos);
    }
}
