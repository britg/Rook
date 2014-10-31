using UnityEngine;
using System.Collections;

public class CombatController : GameBehaviour {

	public new CombatService combatService;

    void Start () {
        combatService = new CombatService(player, agentRegistry);
		Observe(Notifications.ChangeMade);
        Observe(Notifications.PlayerTurn);
    }

    void OnChangeMade () {
        combatService.DetectCombat();
    }

	void OnPlayerTurn () {
        combatService.DetectCombat();
	}
}
