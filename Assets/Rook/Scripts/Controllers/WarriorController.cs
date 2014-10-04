using UnityEngine;
using System.Collections;

public class WarriorController : GameController {

    public override IReceiveAction actionReceiver {
        get {
            return player.warrior;
        }
    }

}
