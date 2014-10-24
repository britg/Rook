using UnityEngine;
using System.Collections;

public class WarriorController : GameBehaviour {

    public override IReceiveAction actionReceiver {
        get {
            return player.warrior;
        }
    }

}
