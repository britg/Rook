using UnityEngine;
using System.Collections;

public class CombatController : GameController {

	public new CombatService combatService;

    void Start () {
        combatService = new CombatService(player, enemyRegistry);
        NotificationCenter.AddObserver(this, Notifications.ChangeMade);
        NotificationCenter.AddObserver(this, Notifications.PlayerTurn);
    }

    void OnChangeMade () {
        combatService.DetectCombat();
    }

	void OnPlayerTurn () {
        combatService.DetectCombat();
	}
}
