using UnityEngine;
using System.Collections;

public class CombatController : GameController {

	public new CombatService combatService;

    void Start () {
        combatService = new CombatService(player, enemyRegistry);
        NotificationCenter.AddObserver(this, Notifications.ChangeMade);
    }

    void OnChangeMade () {
        Debug.Log("Combat controller: Change made");
        combatService.DetectCombat();
    }
}
