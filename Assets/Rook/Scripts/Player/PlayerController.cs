using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Player player;

    void Start () {
        player.controlMode = PlayerControlMode.Move;
    }

    public void SetPlayerMode (PlayerControlMode mode) {
        player.controlMode = mode;
    }
}
