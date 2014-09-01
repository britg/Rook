using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Player player;

    void Start () {
        player.mode = PlayerMode.Move;
    }

    public void SetPlayerMode (PlayerMode mode) {
        player.mode = mode;
    }
}
